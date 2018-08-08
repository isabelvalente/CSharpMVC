using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class LanguagesController : Controller
    {
        // GET: Languages
        
        public ActionResult Index()
        {
            ViewBag.Message = "Languages are the spice of life!";

            return View();
        }

        [Route("Languages/Ruby")]
        public ActionResult Ruby()
        {
            ViewBag.Message = "Ruby is the language of the people!";

            return View();
        }

        [Route("Languages/C#")]
        public ActionResult CSharp()
        {
            ViewBag.Message = "C Sharp can be tricky.";

            return View();
        }

        [Route("Languages/Javascript")]
        public ActionResult Javascript()
        {
            ViewBag.Message = "Build powerful games with Javascript.";

            return View();
        }
    }
}