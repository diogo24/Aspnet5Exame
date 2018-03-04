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
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products {
            get {
                return context.Products;
            }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                var entity = context.Products.Find(product.ProductID);
                if (entity != null) {

                    entity.Name        = product.Name;
                    entity.Description = product.Description;
                    entity.Price       = product.Price;
                    entity.Category    = product.Category;
                }

            }

            context.SaveChanges();
        }
    }
}
