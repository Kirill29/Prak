using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{
	public class Shape_WKT : Shape
	{
		private string name;

		private string geometry;

		private string dbconn;

		public Shape_WKT(string name, string geom, string dbconn)
		{
			this.name = name;
			geometry = geom;
			this.dbconn = dbconn;
		}

		public override string Add_shape()
		{
			string Cmr_Id;
			try
			{
				using (var conn = new NpgsqlConnection(dbconn))
				{
					conn.Open();
					using (var cmd = new NpgsqlCommand())
					{
						cmd.Connection = conn;
						cmd.CommandText =
							"INSERT INTO data.cmr(cmr_ident,cmr_name, geom,date_make) VALUES ('2',@name, ST_GeomFromText(@geometry,4326),'now') RETURNING cmr_id;";
						cmd.Parameters.AddWithValue("@name", name);
						cmd.Parameters.AddWithValue("@geometry", geometry);
						Cmr_Id = Convert.ToString(cmd.ExecuteScalar());
					}
					conn.Close();
				}
			}
			catch (Exception exception)
			{
				return exception.Message;
			}

			return Cmr_Id;
		}
	}
}