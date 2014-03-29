using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestHtmlHelper.Models;

namespace TestHtmlHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var myModel = new MyModel { Name = "This is a test name" };
            return View(myModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}