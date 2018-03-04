using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Product> Products {
            get {
                return _context.Products;
            }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var entity = _context.Products.Find(product.ProductID);
                if (entity != null) {

                    entity.Name        = product.Name;
                    entity.Description = product.Description;
                    entity.Price       = product.Price;
                    entity.Category    = product.Category;
                }

            }

            _context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var entity = _context.Products.Find(productId);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                _context.SaveChanges();
            }
            
            return entity;
        }
    }
}
