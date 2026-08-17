using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            List<OrderModel> orders = GetOrderDemoModels();
            Session["Orders"] = orders;
            Session["Customers"] = GetCustomerDemoModels();
            return View(orders);
        }

        private List<CustomerModel> GetCustomerDemoModels()
        {
            List<CustomerModel> customers = new List<CustomerModel>() {
                new CustomerModel{
                        CustomerID = 1, FirstName = "John", LastName = "Smith", Address = "123 Main St", City = "Anytown", State = "CA", PostalCode = "12345", PhoneNumber = "555-1234"
                    },

                new CustomerModel{
                        CustomerID = 2, FirstName = "Jane", LastName = "Doe", Address = "456 Elm St", City = "Othertown", State = "NY", PostalCode = "67890", PhoneNumber = "555-5678"
                }
                ,
                new CustomerModel{
                        CustomerID = 3, FirstName = "Alice", LastName = "Johnson", Address = "789 Oak St", City = "Sometown", State = "TX", PostalCode = "54321", PhoneNumber = "555-9876"
                }
            };
            
            return customers;
        }


        private List<OrderModel> GetOrderDemoModels()
        {
            List<OrderModel> orders = new List<OrderModel>() {
                new OrderModel{
                        OrderID = 1, CustomerID = 1, Item = "Widget", Quantity = 10, Price = 9.99m
                    },
                new OrderModel{
                        OrderID = 2, CustomerID = 2, Item = "Gadget", Quantity = 5, Price = 19.99m
                }
                ,
                new OrderModel{
                        OrderID = 3, CustomerID = 3, Item = "Thingamajig", Quantity = 2, Price = 29.99m
                }
            };

            return orders;
        }

        private void SetupCustomersList(List<CustomerModel> Customers)
        {
            IEnumerable<SelectListItem> items = Customers.Select(customer => new SelectListItem
            {
                Value = customer.CustomerID.ToString(),
                Text = $"{customer.FirstName} {customer.LastName}"
            });
            ViewBag.Selection = items;
        }

        public ActionResult Edit(int? id)
        {
            List<OrderModel> orders = Session["Orders"] as List<OrderModel>;
            OrderModel order = orders.Single(o => o.OrderID == id);
            if (order == null)
            {
                return HttpNotFound();
            }

            List<CustomerModel> customers = Session["Customers"] as List<CustomerModel>;
            SetupCustomersList(customers);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(OrderModel order)
        {
            return RedirectToAction("Index");
        }



    }
}