﻿namespace OnlineShopWebAPI.API.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
