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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return this.context.Customers
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        [HttpGet]
        public CustomerDto GetCustomers(int id)
        {
            var customer = this.context.Customers.Find(id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return customerDto;
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            this.context.Customers.Add(customer);
            this.context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbCustomer = this.context.Customers.Find(id);
            if (dbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, dbCustomer);

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
