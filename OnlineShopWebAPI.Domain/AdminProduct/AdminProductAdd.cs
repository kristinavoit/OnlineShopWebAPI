using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Domain.AdminProduct
{
    class AdminProductAdd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
