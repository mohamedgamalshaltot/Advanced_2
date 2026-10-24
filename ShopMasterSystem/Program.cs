using System.Xml.Linq;

namespace ShopMasterSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new List<Product>()
        {
            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };
            //var electronics = ProductService.SearchProducts(catalog, p => p.Category == "Electronics");
            //var cheapProducts = ProductService.SearchProducts(catalog, p => p.Price < 50);
            //var inStockProducts = ProductService.SearchProducts(catalog, p => p.Stock > 0);
            //var cheapClothing = ProductService.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            // -------------------------------------------------------------
            // 1. All Electronics products
            // -------------------------------------------------------------
            Console.WriteLine("========================================");
            Console.WriteLine("-----Electroics-----");
            Console.WriteLine("========================================");
            var electronics = ProductService.SearchProducts(catalog, p => p.Category == "Electronics");
            PrintProducts(electronics);

            // -------------------------------------------------------------
            // 2. Products cheaper than $50
            // -------------------------------------------------------------
            Console.WriteLine("\n========================================");
            Console.WriteLine("-----Under $50 -----");
            Console.WriteLine("========================================");
            var cheapProducts = ProductService.SearchProducts(catalog, p => p.Price < 50);
            PrintProducts(cheapProducts);

            // -------------------------------------------------------------
            // 3. Products that are in stock (Stock > 0)
            // -------------------------------------------------------------
            Console.WriteLine("\n========================================");
            Console.WriteLine("-----In Stock-----");
            Console.WriteLine("========================================");
            var inStockProducts = ProductService.SearchProducts(catalog, p => p.Stock > 0);
            PrintProducts(inStockProducts);

            // -------------------------------------------------------------
            // 4. Clothing products under $100
            // -------------------------------------------------------------
            Console.WriteLine("\n========================================");
            Console.WriteLine("-----Clothing Under $100-----");
            Console.WriteLine("========================================");
            var cheapClothing = ProductService.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            PrintProducts(cheapClothing);



            // Scenario 1: Short Report (Name - $Price)
            Console.WriteLine("=== Short Report ===");
            ProductService.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}")); 
Console.WriteLine("\n========================================");

            // Scenario 2: Detailed Report ([Category] Name | Price: $X | Stock: Y)
            Console.WriteLine("=== Detailed Report ===");
            ProductService.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));


            // -------------------------------------------------------------
            // Scenario 3: Summary List (Name ($Price))
            // -------------------------------------------------------------
            Console.WriteLine("\n========================================");
            Console.WriteLine("=== Scenario 3: Summary List ===");
            Console.WriteLine("========================================");
            var summaryList = ProductService.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }

            // -------------------------------------------------------------
            // Scenario 4: Price Label (Expensive! / Affordable)
            // -------------------------------------------------------------
            Console.WriteLine("\n========================================");
            Console.WriteLine("=== Scenario 4: Price Label ===");
            Console.WriteLine("========================================");
            var priceLabels = ProductService.TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (var item in priceLabels)
            {
                Console.WriteLine(item);
            }

            // -------------------------------------------------------------
            // Scenario 5: Low-Stock Alert (Stock < 20)
            // -------------------------------------------------------------
            Console.WriteLine("\n========================================");
            Console.WriteLine("=== Scenario 5: Low-Stock Alert ===");
            Console.WriteLine("========================================");
            var lowStockProducts = ProductService.FilterProducts(catalog, p => p.Stock < 20);
            foreach (var item in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {item.Name}: only {item.Stock} left!");
            }

        }

        // دالة مساعدة لطباعة المنتجات بشكل منظم في الـ Console
        private static void PrintProducts(List<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($" {item.Name} - Category: {item.Category} | Price: ${item.Price} | Stock: {item.Stock}");
            }
        }
//        
     }
}
