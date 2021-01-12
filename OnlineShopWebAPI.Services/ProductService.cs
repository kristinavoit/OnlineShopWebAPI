using System;
using System.Collections.Generic;
using OnlineShopWebAPI.Core;
using OnlineShopWebAPI.Core.Models;
using OnlineShopWebAPI.Core.Repositories;

namespace OnlineShopWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Products
                .GetAll();
        }
        public Product GetById(int id)
        {
            return _unitOfWork.Products
                .GetById(id);
        }
        public Product Add(Product newProduct)
        {
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Commit();
            return newProduct;
        }
        public void Update(Product productToUpdate, Product product)
        {
            productToUpdate.Id = product.Id;
            productToUpdate.CategoryId = product.CategoryId;

            _unitOfWork.Commit();
        }

        public void Delete(Product product)
        {
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Commit();
        }
    }
}
