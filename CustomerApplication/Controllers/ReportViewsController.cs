using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerApplication.Models;

namespace CustomerApplication.Controllers
{
    public class ReportViewsController : Controller
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: RepostViews
        public ActionResult Index()
        {
            return View(db.RepostView.ToList());
        }
    }
}
