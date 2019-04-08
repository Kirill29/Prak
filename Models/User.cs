using System;
namespace Geoportal.Models
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
