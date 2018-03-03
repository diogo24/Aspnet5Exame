using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = _lineCollection
                .Where(CartLineProductFilter_Func(product))
                .FirstOrDefault();

            if (line == null)
            {
                _lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(CartLineProductFilter_Pred(product));
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(cl => cl.Quantity * cl.Product.Price);
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get {
                return _lineCollection;
            }
        }

        private Func<CartLine, bool> CartLineProductFilter_Func(Product product)
        {
            return cl => cl.Product.ProductID == product.ProductID;
        }

        private Predicate<CartLine> CartLineProductFilter_Pred(Product product)
        {
            return cl => CartLineProductFilter_Func(product)(cl);
        }
    }

    public class CartLine {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
