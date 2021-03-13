using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Wep.App.DTO;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.Controllers.API
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/customers/
        public IHttpActionResult GetCustomers()
        {
          var customerDtos = _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
          return Ok(customerDtos);

        }

        //Get /api/customers/id
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            
        }

         //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id ), customerDto);
        }

        //Put /api/customers
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerinDb);
            //customerinDb.BirthDate = customerDto.BirthDate;
            //customerinDb.IsSubscribedToCustomer = customerDto.IsSubscribedToCustomer;
            //customerinDb.MembershipTypeId = customerDto.MembershipTypeId;
            //customerinDb.Name = customerDto.Name;
            _context.SaveChanges();

        }

        //Delete /api/customers
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerinDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerinDb);
            _context.SaveChanges();
        }

    }
}
