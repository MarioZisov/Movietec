using AutoMapper;
using Movietec.Data;
using Movietec.Models.DbModels;
using Movietec.Models.Dtos;
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
        public IHttpActionResult GetCustomers()
        {
            var customersDto = this.context.Customers
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return this.Ok(customersDto);
        }

        [HttpGet]
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = this.context.Customers.Find(id);
            if (customer == null)
                return this.NotFound();

            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return this.Ok(customerDto);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return this.BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            this.context.Customers.Add(customer);
            this.context.SaveChanges();

            customerDto.Id = customer.Id;
            return this.Created(new Uri(this.Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return this.BadRequest();

            var dbCustomer = this.context.Customers.Find(id);
            if (dbCustomer == null)
                return this.NotFound();

            Mapper.Map(customerDto, dbCustomer);

            this.context.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = this.context.Customers.Find(id);
            if (customer == null)
                return this.NotFound();

            this.context.Customers.Remove(customer);
            this.context.SaveChanges();

            return this.Ok();
        }
    }
}
