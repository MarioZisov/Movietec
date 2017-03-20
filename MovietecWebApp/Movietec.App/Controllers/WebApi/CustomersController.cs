using Movietec.Data;
using Movietec.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Movietec.App.Controllers.WebApi
{
    public class CustomersController : ApiController
    {
        private MovietecContext context;

        public CustomersController()
        {
            this.context = new MovietecContext();
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return this.context.Customers.ToList();
        }

        [HttpGet]
        public Customer GetCustomers(int id)
        {
            var customer = this.context.Customers.Find(id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            this.context.Customers.Add(customer);
            this.context.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbCustomer = this.context.Customers.Find(id);
            if (dbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbCustomer.Name = customer.Name;
            dbCustomer.MembershipTypeId = customer.MembershipTypeId;
            dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            dbCustomer.BirthDate = customer.BirthDate;

            this.context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = this.context.Customers.Find(id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            this.context.Customers.Remove(customer);
            this.context.SaveChanges();
        }
    }
}
