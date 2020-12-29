using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Domain.AdminUser
{
    class AdminUserAdd
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; } //defaul - false
    }
}
