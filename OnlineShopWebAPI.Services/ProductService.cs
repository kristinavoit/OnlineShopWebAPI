using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products
                .GetAllAsync();
        }
        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.Products
                .GetById(id);
        }
        public async Task Insert(Product newProduct)
        {
            _unitOfWork.Products.Add(newProduct);
            await _unitOfWork.CommitAsync();
        }
        public async Task Update(Product product)
        {
            _unitOfWork.Products.Update(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Product product)
        {
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.CommitAsync();
        }
    }
}
