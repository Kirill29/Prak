﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoportal.file_streaming
{
	public static class FileStreamingHelper
	{
		private static readonly FormOptions _defaultFormOptions = new FormOptions();

		public static List<string> file_name;

		public static async Task<FormValueProvider> StreamFile(this HttpRequest request, Stream targetStream,
			string path)
		{
			file_name = new List<string>();
			if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType))
			{
				throw new Exception($"Expected a multipart request, but got {request.ContentType}");
			}

			// Used to accumulate all the form url encoded key value pairs in the 
			// request.
			var formAccumulator = new KeyValueAccumulator();
			// string targetFilePath = ;
			string targetFilePath = null;
			var boundary = MultipartRequestHelper.GetBoundary(
				MediaTypeHeaderValue.Parse(request.ContentType),
				_defaultFormOptions.MultipartBoundaryLengthLimit);
			var reader = new MultipartReader(boundary, request.Body);
			var section = await reader.ReadNextSectionAsync();
			//file_name.Clear();
			while (section != null)
			{
				ContentDispositionHeaderValue contentDisposition;
				var hasContentDispositionHeader =
					ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out contentDisposition);
				string rt = contentDisposition.FileName.ToString();
				file_name.Add(rt);
				if (hasContentDispositionHeader)
				{
					if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
					{
						FileMultipartSection currentFile = section.AsFileSection();
						string filePath = Path.Combine(path, currentFile.FileName);

						using (targetStream = File.Create(filePath))
						{
							await section.Body.CopyToAsync(targetStream).ConfigureAwait(false);
						}
					}
					else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
					{
						// Do not limit the key name length here because the 
						// multipart headers length limit is already in effect.
						var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name);
						var encoding = GetEncoding(section);
						using (var streamReader = new StreamReader(
							section.Body,
							encoding,
							detectEncodingFromByteOrderMarks: true,
							bufferSize: 1024,
							leaveOpen: true))
						{
							// The value length limit is enforced by MultipartBodyLengthLimit
							var value = await streamReader.ReadToEndAsync();
							if (String.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase))
							{
								value = String.Empty;
							}

							formAccumulator.Append(key.Value, value); // For .NET Core <2.0 remove ".Value" from key

							if (formAccumulator.ValueCount > _defaultFormOptions.ValueCountLimit)
							{
								throw new InvalidDataException(
									$"Form key count limit {_defaultFormOptions.ValueCountLimit} exceeded.");
							}
						}
					}
				}

				// Drains any remaining section body that has not been consumed and
				// reads the headers for the next section.
				section = await reader.ReadNextSectionAsync();
			}

			// Bind form data to a model
			var formValueProvider = new FormValueProvider(
				BindingSource.Form,
				new FormCollection(formAccumulator.GetResults()),
				CultureInfo.CurrentCulture);

			return formValueProvider;
		}

		private static Encoding GetEncoding(MultipartSection section)
		{
			MediaTypeHeaderValue mediaType;
			var hasMediaTypeHeader = MediaTypeHeaderValue.TryParse(section.ContentType, out mediaType);
			// UTF-7 is insecure and should not be honored. UTF-8 will succeed in 
			// most cases.
			if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
			{
				return Encoding.UTF8;
			}

			return mediaType.Encoding;
		}
	}
}