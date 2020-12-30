using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopWebAPI.Core.Models
{
    class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
