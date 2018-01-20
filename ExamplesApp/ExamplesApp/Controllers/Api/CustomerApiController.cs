using AutoMapper;
using ExamplesApp.DTOs;
using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;


namespace ExamplesApp.Controllers.Api
{
    public class CustomerApiController : ApiController
    {
        // we defined Database object to access database data
        private ApplicationDbContext _db;

        public CustomerApiController()
        {
            _db = new ApplicationDbContext();
        }

        // GET()  /api/customer ---> to get all of customer
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            // here we mapped Customer model to CustomerDto
            var customerDto = _db.Customers
                .Include(c => c.MemberShipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDto);
        }

        // GET()  /api/customer/1 ---> to get single customer
        [HttpGet]
        public CustomerDto GetCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // also here we mapped single customer data type to CustomerDto
            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        // POST()  /api/customer/ ---> to post new customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                // when we use other return dataType we throw HttpRespomseException and Htpp Code
                // throw new HttpResponseException(HttpStatusCode.BadRequest);

                // But when we use IHttpActionResult type we dont have to use HttpResponseException
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _db.Customers.Add(customer);
            _db.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto );
        }

        // PUT()  /api/customer/1 ---> to put/update exist customer
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

            _db.SaveChanges();
            return Ok();
        }

        // DELETE() /api/customer/1 ---> to delete customer from Database
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb =  _db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _db.Customers.Remove(customerInDb);
            _db.SaveChanges();
            return Ok();
        }

    }
}
