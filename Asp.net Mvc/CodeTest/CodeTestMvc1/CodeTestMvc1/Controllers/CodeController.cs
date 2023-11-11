using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeTestMvc1.Models;

namespace CodeTestMvc1.Controllers
{
    

    public class CodeController : Controller
    {
        // GET: Code
        private NorthwindEntities1 db = new NorthwindEntities1();

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }

        //public ActionResult CustomerWithOrderId(int orderId = 10248)
        //{
        //    var customerDetails = (from c in db.Customers
        //                           join o in db.Orders on c.CustomerID equals o.CustomerID
        //                           where o.OrderID == 10248
        //                           select new details
        //                           {
        //                               customer = c,
        //                               order = o
        //                           }).FirstOrDefault();

        //    return View(customerDetails);
        //}
        public ActionResult CustomerWithOrderId(int orderId = 10248)
        {
            var customer = db.Customers
                .Where(c => c.Orders.Any(o => o.OrderID == orderId))
                .SingleOrDefault();

            if (customer == null)
            {
                return HttpNotFound(); // Return a 404 status code if the customer is not found.
            }

            return View(customer);
        }
    }
}