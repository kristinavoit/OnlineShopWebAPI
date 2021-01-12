using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopWebAPI.Core.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Product> Products { get; set; } //1:n
        public double TotalPrice { get; set; }
        public User Users { get; set; }
    }
}
