using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopWebAPI.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; } //defaul - false
        public int CartItemId { get; set; } //1:1
        public Product Product { get; set; }
    }
}
