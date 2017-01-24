using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TinyPOC.Accessor;
using TinyPOC.Models;

namespace TinyPOC.Controllers
{
    public class HomeController : Controller
    {
        private TinyAccessor _tinyAccessor;

        public TinyAccessor TinyAccessor
        {
            get { return _tinyAccessor ?? (_tinyAccessor = new TinyAccessor()); }
            set { _tinyAccessor = value; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTemplate()
        {
            var model = new Template();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateTemplate(Template template)
        {
            
            return RedirectToAction("Index");
        }

        public ActionResult SelectTemplate()
        {
            return View();
        }

        public ActionResult CreateLetter(int templateId)
        {
            return View();
        }

        public ActionResult SelectLetter()
        {
            return View();
        }

        public ActionResult ViewLetter(int letterId)
        {
            return View();
        }
        
    }
}