using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Geoportal.Controllers
{//controller to manage login
    public class AccountController : Controller
    {
        
        private IConfiguration _configuration;
        private IConnectionString _connectionString;
        
        public static string Current_user { get; private set; }
      

        public AccountController(IConfiguration configuration, IConnectionString connectionString)
        {
            _configuration = configuration;
            _connectionString = connectionString;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Login = model.Login,
                    Password = model.Password

                };
                // _configuration["DefaultConnection"]=connn.;
                _connectionString.SetConnectionString(user);
                //try to connect to database with user's login and password
                try
                {
                    var connString =_connectionString.GetConnectionString();

                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();


                        using (var cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT rolname FROM pg_roles;";

                             

                        }
                        conn.Close();

                    }
                }
                catch (Exception exception)

                {
                    //fail-message to user
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    return Content(exception.Message);

                }

                await Authenticate(model.Login); // authecation
                //
               
                //give user permission to work with  database
                Give_Permission();
                Current_user = model.Login;
                
                //redirect to file transfer page
                return RedirectToAction("Send", "File");
            }

           


            return View(model);
        }
       

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

        public async Task<IActionResult> Logout()
        {
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
                        cmd.CommandText = "ALTER USER " + (User.FindFirst(ClaimTypes.Name).Value) + " WITH NOSUPERUSER;";
                        cmd.ExecuteNonQuery();
                       
                    }
                    conn.Close();

                }
            }
            catch (Exception exception)

            {

                ModelState.AddModelError("", "Ошибка в выдаче прав суперпользователя!");
                return Content(exception.Message);

            }
            if (string.IsNullOrEmpty((User.FindFirst(ClaimTypes.Name).Value)))
            {
                return Content("Сначала необходимо войти в систему!");
            }
            else
            {
              
                return RedirectToAction("Index", "Home");

            }
            
        }

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
                        cmd.CommandText = "ALTER USER " + User.FindFirst(ClaimTypes.Name).Value + " WITH SUPERUSER;";
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();

                }
            }
            catch (Exception exception)

            {

                ModelState.AddModelError("", "Ошибка в выдаче прав суперпользователя!");
               // return Content(exception.Message);

            }
        }
    }

}
