using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
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
            return View(new Template());
        }

        [HttpPost]
        public ActionResult CreateTemplate(Template template)
        {
            if (!ModelState.IsValid)
            {
                return View(template);
            }

            var res = TinyAccessor.AddTemplate(template);

            return RedirectToAction("Index");
        }

        public ActionResult SelectTemplate()
        {
            var model = new SelectTemplateViewModel
            {
                Templates = TinyAccessor.GetTemplates()
            };

            return View(model);
        }

        public ActionResult CreateLetter(int templateId)
        {
            var model = new CreateLetterViewModel(TinyAccessor.GetTemplateById(templateId));
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateLetter(CreateLetterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var res = TinyAccessor.AddLetter(model.Letter);

            return RedirectToAction("Index");
        }

        public ActionResult SelectLetter()
        {
            var model = new SelectLetterViewModel
            {
                Letters = TinyAccessor.GetLetters()
            };
            return View(model);
        }

        public ActionResult ViewLetter(int letterId)
        {
            var model = TinyAccessor.GetLetter(letterId);
            return View(model);
        }
        
    }
}