using Movietec.App.Models;
using Movietec.Data;
using Movietec.Models.DbModels;
using Movietec.Models.ViewModels;
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

        public ActionResult New()
        {
            var membershtipTypes = this.context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershtipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = this.context.MembershipTypes.ToList(),
                    Customer = customer
                };

                return this.View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                this.context.Customers.Add(customer);
            else
            {
                var dbCustomer = this.context.Customers.First(c => c.Id == customer.Id);

                dbCustomer.Name = customer.Name;
                dbCustomer.MembershipTypeId = customer.MembershipTypeId;
                dbCustomer.BirthDate = customer.BirthDate;
                dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            this.context.SaveChanges();

            return this.RedirectToAction("All");
        }

        public ActionResult Edit(int id)
        {
            var customer = this.context.Customers.Find(id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = this.context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
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