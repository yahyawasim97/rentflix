using Rentflix.Models;
using Rentflix.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rentflix.Controllers
{

    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
        
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = db.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = db.MembershipTypes.ToList();
            var viewModelCustomer = new CustomerFormViewModel
            {   Customer = new Customer(),
                MembershipTypes = membershipTypes   
            };
            return View("CustomerForm",viewModelCustomer);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = db.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customer.Id == 0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                var customerInDb = db.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;

            }
            
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}