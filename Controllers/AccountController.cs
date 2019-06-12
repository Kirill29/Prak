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

namespace Geoportal.Controllers
{//controller to manage login
    public class AccountController : Controller
    {
        public static string current_user="";
        public static string current_user_password = "";
       
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
                //try to connect to database with user's login and password
                try
                {
                    var connString = "Host=localhost;Database=i;Username=" + model.Login + ";Password=" + model.Password + ";";

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
                current_user = model.Login;
                current_user_password = model.Password;
                //give user permission to work with  database
                Give_Permission();
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


                var connString = "Host=localhost;Database=i;Username="+current_user+"; Password="+current_user_password+";";

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();


                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "ALTER USER " + current_user + " WITH NOSUPERUSER;";
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
            if (current_user == "")
            {
                return Content("Сначала необходимо войти в систему!");
            }
            else
            {
                current_user = "";
                return RedirectToAction("Index", "Home");

            }
            
        }

        public void Give_Permission()
        {
            try
            {


                var connString = "Host=localhost;Database=i;Username=postgres;Password=0-0-0-";

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();


                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "ALTER USER " + current_user + " WITH SUPERUSER;";
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
