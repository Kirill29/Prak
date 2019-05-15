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
{
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

                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    return Content(exception.Message);

                }





                await Authenticate(model.Login); // аутентификация
                current_user = model.Login;
                current_user_password = model.Password;
                Give_Administration();




                return RedirectToAction("Create", "File");


            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            List<string> roles = new List<string>();
            List<string> passwords = new List<string>();
            if (ModelState.IsValid)
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
                          
                            
                                cmd.CommandText = "CREATE USER " + model.Login + " WITH PASSWORD " + "'" + model.Password + "';";
                               cmd.ExecuteNonQuery();

                            await Authenticate(model.Login); // аутентификация
                                current_user = model.Login;
                            current_user_password = model.Password;
                            Give_Administration();
                        

                        }
                        conn.Close();

                    }
                }
                catch (Exception exception)

                {

                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    return Content(exception.Message);

                }





                return RedirectToAction("Create", "File");
            }
            else { ModelState.AddModelError("", "Некорректные логин и(или) пароль"); }
                
        
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
                        cmd.CommandText = "ALTER USER " + current_user + " NOWITH SUPERUSER;";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "ALTER USER postgres WITH SUPERUSER;";
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





        public void Give_Administration()
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
