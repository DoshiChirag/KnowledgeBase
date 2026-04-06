using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;
using System.Threading.Tasks;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
                return View("Thanks", guestResponse);
            else
                return View();
        }


        public ViewResult  AutoProperty()
        {
            Product myProduct = new Product();

            myProduct.Name = "Kayak";

            return View("Result", (object)string.Format("Product name :{0}", myProduct.Name ));

        }


        public ViewResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "WaterSports"

            };

            return View("Result", (object)string.Format("Category :{0}", myProduct.Category));


        }


        public ViewResult CreateCollection()
        {
            string[] stringarray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int>{
                {"apple",10}, {"orange", 20}, {"plum", 30}
            };

            System.Text.StringBuilder Builder = new System.Text.StringBuilder();
            foreach(string Key in stringarray)
            {
                Builder.Append(string.Format("{0}, {1}",Key,myDict[Key]));
                Builder.AppendLine();

            }

            return View("Result", (object)string.Format("Category :{0}", (object)Builder.ToString()));


        }

        public ViewResult UseExtension()
        {

             IEnumerable<Product> Products = new ShoppingCart {
                 Products = new List<Product>{
                     new Product{Name = "Kayak", Price = 275M},
                     new Product{Name = "Lifejacket", Price = 48.95M},
                      new Product{Name = "Soccer ball", Price = 19.50M},
                      new Product{Name = "Corner flag", Price = 34.95M}

                 }
             };


             Product[] productArray = {
                      new Product{Name = "Kayak", Price = 275M},
                     new Product{Name = "Lifejacket", Price = 48.95M},
                      new Product{Name = "Soccer ball", Price = 19.50M},
                      new Product{Name = "Corner flag", Price = 34.95M}
             };


             decimal cartTotal = Products.TotalPrices();
             decimal arrayTotal = Products.TotalPrices();
            
            return View("Result", (object)string.Format("Cart Total :{0:c}, Array Total = {1}",cartTotal,arrayTotal));


        }



        public ViewResult UseFilterExtension()
        {

            IEnumerable<Product> Products = new ShoppingCart
            {
                Products = new List<Product>{
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}

                 }
            };


         
            decimal Total = 0;
            foreach (Product prod in Products.FilterByCategory("Soccer"))
            {
                Total += prod.Price;
            }

            return View("Result", (object)string.Format("Total :{0:c}", Total));


        }


        public ViewResult UseFilterExtensionMethod()
        {

            IEnumerable<Product> Products = new ShoppingCart
            {
                Products = new List<Product>{
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}

                 }
            };


            //Func<Product, bool> categoryFilter = delegate(Product prod)
            //{
            //    return prod.Category == "WaterSports";
            //};

            //Func<Product, bool> categoryFilter = (Product => Product.Category == "Soccer");

            decimal Total = 0;
            foreach (Product prod in Products.Filter(Product => Product.Category == "Soccer" || Product.Price > 20))
            {
                Total += prod.Price;
            }

            return View("Result", (object)string.Format("Total :{0:c}", Total));


        }


        public ViewResult CreateAnonArray()
        {

            var oddsAndEnds = new[] {
                new {Name = "MVC", Category = "Pattern"},
                new {Name = "Hat" , Category = "Clothing"},
                new {Name = "Apple", Category = "Fruit"}
            };

            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }


            var myVariable = new Product { Name = "Kayak", Category = "WaterSports", Price = 275M };

            return View("Result", (object)myVariable.Name);


        }


        public ViewResult FindProducts()
        {
            Product[] products = {
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };


            Product[] foundProducts = new Product[3];
            Array.Sort(products, (item1, item2) => {
                return Comparer<decimal>.Default.Compare(item1.Price, item2.Price);
            });

            Array.Copy(products, foundProducts, 3);

            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (Product p in foundProducts)
                result.AppendFormat("Price: {0} ", p.Price);


            return View("Result", (object)result.ToString());


        }


        public ViewResult FindProductsQuery()
        {
            Product[] products = {
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };



            var foundProducts = from match in products
                                orderby match.Price descending
                                select new { match.Name, match.Price };



            int Count = 0;
            
           
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);
                if (++Count == 3) break;
            }


            return View("Result", (object)result.ToString());


        }


        public ViewResult FindProductsQueryByFunctions()
        {
            Product[] products = {
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };



            var foundProducts = products.OrderByDescending(e => e.Price).Take(3).Select(e => new { e.Name, e.Price });


          


            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);
                
            }


            return View("Result", (object)result.ToString());


        }


        public ViewResult FindProductsQueryByDeferredExtensions()
        {

            Product[] products = {
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };



            var foundProducts = products.OrderByDescending(e => e.Price).Take(3).Select(e => new { e.Name, e.Price });



            products[2] = new Product { Name = "Stadium", Price = 79600M };

            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);

            }


            return View("Result", (object)result.ToString());



        }
            

        public ViewResult SumProducts()
        {

            Product[] products = {
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };


            var results = products.Sum(e => e.Price);


            products[2] = new Product { Name = "Stadium", Price = 79600M };


            return View("Result", (object)string.Format("Sum {0:c}", results));


        }



        public ViewResult AsyncData()
        {

           Task<long> Result = MyAsyncMethods.GetPageLength();

            return View("Result", (object)string.Format("Content Length {0}", Result.Result));


        }


        public ViewResult AsyncPageLength()
        {

            Task<long> Result =  MyAsyncMethods.GetAsyncPageLength();

            return View("Result", (object)string.Format("Content Length {0}", Result.Result));


        }



        


	}
}