using Movietec.App.Models;
using Movietec.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movietec.App.Controllers
{
    public class CustomersController : Controller
    {
        private MovietecContext context;
        
        public CustomersController()
        {
            this.context = new MovietecContext();
        }

        public ActionResult All()
        {
            var customers = this.context.Customers.ToList();
            return this.View(customers);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return this.HttpNotFound();

            var customers = this.context.Customers;
            if (!customers.Any(c => c.Id == id))
                return this.HttpNotFound();

            var customer = customers.Find(id);

            return this.View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            this.context.Dispose();
        }
    }
}