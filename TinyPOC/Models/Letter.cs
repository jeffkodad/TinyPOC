using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyPOC.Models
{
    public class Letter
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        public string Title { get; set; }
    }
}