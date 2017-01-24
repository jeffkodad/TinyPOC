using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TinyPOC.Models
{
    public class CreateLetterViewModel
    {
        public Template Template { get; set; }

        public Letter Letter { get; set; }

        public CreateLetterViewModel()
        {
            Letter = new Letter();
        }

        public CreateLetterViewModel(Template template)
        {
            Letter = new Letter();
            Template = template;
            Letter.Body = Template.Body;
        }
    }
}