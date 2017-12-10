using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter4_LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this ShoppingCart cartParam) {
            decimal total = 0;

            foreach (Product prod in cartParam.Products)
            {
                total += prod.Price;
            }

            return total;
        }

        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;

            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> prodEnum, string categoryParam) {
            foreach (var prod in prodEnum)
            {
                if (prod.Category == categoryParam) {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> prodEnum, Func<Product, bool> selectorParam) {
            foreach (var prod in prodEnum)
            {
                if (selectorParam(prod))
                {
                    yield return prod;
                }
            }
        }

    }
}