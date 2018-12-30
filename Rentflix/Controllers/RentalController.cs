using Rentflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rentflix.Controllers
{
    [Authorize(Roles = "CanManageMovie")]
    public class RentalController : Controller
    {
        ApplicationDbContext db;
        // GET: Rental
        public RentalController() {
            db = new ApplicationDbContext(); 
        }
        public ActionResult New()
        {
            return View();
        }
    }
}