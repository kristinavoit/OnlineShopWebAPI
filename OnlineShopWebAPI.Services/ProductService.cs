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
        public void Insert(Product newProduct)
        {
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Commit();
        }
        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);

            _unitOfWork.Commit();
        }

        public void Delete(Product product)
        {
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Commit();
        }
    }
}
