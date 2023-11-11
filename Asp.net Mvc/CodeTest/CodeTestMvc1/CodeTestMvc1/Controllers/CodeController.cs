using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTestMvc1.Controllers
{
    

    public class CodeController : Controller
    {
        // GET: Code
        private NorthwindEntities1 db = new NorthwindEntities1();

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany");
            return View(customers);
        }

        public ActionResult CustomerWithOrderId(int orderId)
        {
            var customerDetails = (from c in db.Customers
                                   join o in db.Orders on c.CustomerID equals o.CustomerID
                                   where o.OrderID == 10248
                                   select new details
                                   {
                                       customer = c,
                                       order = o
                                   }).FirstOrDefault();

            return View(customerDetails);
        }
    }
}