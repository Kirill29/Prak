using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Geoportal.Models;
using Geoportal.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Geoportal.Services;
using Geoportal.Services.Logging;

namespace Geoportal.Controllers
{//контроллер для авторизации пользователей
    public class AccountController : Controller
    {
        Serilog.Core.Logger _log;
        //конфигурация приложения в файле appsettings.json
        private IConfiguration _configuration;
        private ILogger_custom _logger;
        //получаем строку подключения к базе данных
        private IConnectionString _connectionString;
   

        //текущее имя пользователя
        public static string Current_user { get; private set; }
      
        //DI(внедряем зависимости)
        public AccountController(IConfiguration configuration, IConnectionString connectionString, ILogger_custom logger)
        {
            _configuration = configuration;
            _connectionString = connectionString;
            _logger = logger;
           
          
        }

        //View Login-авторизация пользователя
        [HttpGet]
        public IActionResult Login()
        {
            return View();
            
        }
       
        /* метод по авторизации пользователя
        на вход принимает модель USER(логин и пароль)
        при успешной авторизации пересылает на страницу отправки файлов
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            Current_user = "";
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Login = model.Login,
                    Password = model.Password

                };
              //после проверки логина и пароля -формируем строку для подключения к бд
                _connectionString.SetConnectionString(user);
                //пытаемся авторизироваться при помощи введенных логина и пароля 
                try
                {
                    var connString =_connectionString.GetConnectionString();

                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();


                        using (var cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = conn;
                         
                        }
                        conn.Close();

                    }
                    await Authenticate(model.Login); // авторизация
                }
                catch(Exception ex) 

                {
                    //в случае ошибки авторизации 
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    _logger.LogFatal(ex, "Некорректные логин и(или) пароль");
                    return Content( "Некорректные логин и(или) пароль");
                   
                }

                
                                                 
                Current_user = model.Login;
                //даем пользователю права на работу с бд
                Give_Permission();
                _logger.LogInfo($"User {Current_user} logged in");

                
                return RedirectToAction("Send", "File");
            }

           


            return View(model);
        }
       
        /*авторизация пользователя на основе куки
          на вход принимает имя пользователя*/
        private async Task Authenticate(string userName)
        {

            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        /*выход пользователя из системы
         при выходе забираем доступ к данным бд*/
        public async Task<IActionResult> Logout()
        {
           
            if (string.IsNullOrEmpty((Current_user)))
            {
                return Content("Сначала необходимо войти в систему!");
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            try
            {
               

                var connString =_configuration["Admin"];

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();


                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $"REVOKE ALL PRIVILEGES ON archive.files_demand_archive_ers,archive.demand_archive_ers,archive.dem_arc_sts,archive.files_dem_arc_sts  FROM  {Current_user} ;";
                       
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"REVOKE ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA archive FROM {Current_user} ;";
                       
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"REVOKE ALL PRIVILEGES ON Schema  archive  FROM {Current_user} ;";

                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"REVOKE ALL PRIVILEGES ON Schema  data  FROM  {Current_user} ;";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"REVOKE ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA data  FROM {Current_user} ;";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"REVOKE ALL PRIVILEGES ON table data.cmr,data.files_cmr   FROM  {Current_user} ;";
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    Current_user = "";
                }
            }
            catch (Exception exception)

            {

                ModelState.AddModelError("", "Ошибка в в получении доступа!");
                _logger.LogFatal(exception, "Error in revoking privileges!");
                return Content(exception.Message);

            }

            _logger.LogInfo($"User {Current_user} logged out");
            return RedirectToAction("Index", "Home");

           
            
        }
        /*метод по выдаче прав на работу с базой данных */
        public void Give_Permission()
        {
            try
            {


                var connString =_configuration["Admin"];

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();


                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "GRANT USAGE ON SCHEMA archive TO "+Current_user +";";
                      
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA archive TO {Current_user} ;";
                      
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"GRANT SELECT, INSERT  ON   archive.files_demand_archive_ers,archive.demand_archive_ers,archive.dem_arc_sts,archive.files_dem_arc_sts  TO {Current_user} ;";
                      
                        cmd.ExecuteNonQuery();
                       
                        cmd.CommandText = $"GRANT USAGE ON SCHEMA data TO {Current_user} ;";
                       
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA data TO {Current_user} ;";
                       
                        cmd.ExecuteNonQuery();
                       
                       
                        cmd.CommandText =$"GRANT SELECT, INSERT  ON   data.cmr,data.files_cmr    TO {Current_user} ;";
                       
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();

                }
            }
            catch (Exception ex)

            {

                ModelState.AddModelError("", "Ошибка в выдаче прав суперпользователя!");
                _logger.LogFatal(ex, "Error in grant user permission to work with database");

            }
        }
    }

}
