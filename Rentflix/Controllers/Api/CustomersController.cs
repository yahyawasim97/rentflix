using Rentflix.Dtos;
using Rentflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;


namespace Rentflix.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }
        //GET api/customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = db.Customers.Include(c => c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c=> c.Name.Contains(query));
            }
            var customerDtos = customersQuery.ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }
        //GET api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Single(c => c.Id == id);
            if (customer == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            customerDto.Id = customer.Id;
            db.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);

        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDB = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerInDB);
            db.SaveChanges();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Customers.Remove(customerInDB);
            db.SaveChanges();

        }
    }
}
