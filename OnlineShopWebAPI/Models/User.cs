using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopWebAPI.Core.Models
{
    class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; } //defaul - false
    }
}
