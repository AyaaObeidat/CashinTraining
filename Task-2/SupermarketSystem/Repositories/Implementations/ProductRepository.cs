using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Data;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class ProductRepository :  GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SupermarketSystemDbContext _dbcontext) : base(_dbcontext)
        {
        }

       
    }
}
