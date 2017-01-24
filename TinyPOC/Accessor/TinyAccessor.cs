using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TinyPOC.Models;

namespace TinyPOC.Accessor
{
    public class TinyAccessor
    {
        internal TinyPOCDbContext TinyPOCDbContextInstance { get; set; }

        public Template GetTemplate(int templateId)
        {
            return new Template();
        }

        public Template AddTemplate(Template template)
        {
            using (var context = CreateTinyPocDbContext())
            {
                var dbTemplate = context.Templates.FirstOrDefault(x => x.Id == template.Id);
                if (dbTemplate == null)
                {
                    context.Templates.Add(template);
                }
                context.SaveChanges();
            }

            return template;
        }

        public Letter GetLetter(int letterId)
        {
            return new Letter();
        }

        public Letter AddLetter(Letter letter)
        {
            return new Letter();
        }

        internal TinyPOCDbContext CreateTinyPocDbContext()
        {
            return TinyPOCDbContextInstance ?? CreateNewTinyPOCDbContext();
        }

        private TinyPOCDbContext CreateNewTinyPOCDbContext()
        {
            var result = new TinyPOCDbContext();

            return result;
        }
    }
}