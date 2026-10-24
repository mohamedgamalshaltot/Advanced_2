using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMasterSystem
{
    public class ProductService
    {
        // 1. SearchProducts Method: Uses Func<Product, bool>
        // Why: Because we need to pass a condition (criteria) that inspects a product and returns a boolean (true/false) to filter the list.
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> criterial)
        {
            List<Product> result = new List<Product>();
            foreach (var product in products)
            {
                if (criterial(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        public static void PrintReport(List<Product> products, Action<Product> printAction)
        {
            // 2. PrintReport Method: Uses Action<Product>
            // Why: Because we want to perform an operation (like printing to the console) on each product without returning any value (void).
            foreach (var product in products)
            {
                printAction(product); // تنفيذ شكل الطباعة المحدد لكل منتج
            }
        }
        public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transformer)
        {
            // 3. TransformProducts Method: Uses Func<Product, TResult>
            // Why: Because we need to map/transform each product object into a different type (like a string summary or label) and return the resulting value.
            List<TResult> result = new List<TResult>();
            foreach (var product in products)
            {
                result.Add(transformer(product));
            }
            return result;
        }
        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> predicate)
        {
            // 4. FilterProducts Method: Uses Predicate<Product>
            // Why: Because Predicate is a specialized built-in delegate that explicitly represents a method matching a set of criteria and returning a boolean.
            List<Product> result = new List<Product>();
            foreach (var product in products)
            {
                if (predicate(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }
    }
}