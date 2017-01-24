using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using TinyPOC.Models;

namespace TinyPOC.Accessor
{
    public class TinyAccessor
    {
        internal TinyPOCDbContext TinyPOCDbContextInstance { get; set; }

        public List<Template> GetTemplates()
        {
            using (var context = CreateTinyPocDbContext())
            {
                return context.Templates.ToList();
            }
        }

        public Template GetTemplateById(int templateId)
        {
            using (var context = CreateTinyPocDbContext())
            {
                return context.Templates.FirstOrDefault(x => x.Id == templateId);
            }
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

        public List<Letter> GetLetters()
        {
            using (var context = CreateTinyPocDbContext())
            {
                return context.Letters.ToList();
            }
        }

        public Letter GetLetter(int letterId)
        {
            using (var context = CreateTinyPocDbContext())
            {
                return context.Letters.FirstOrDefault(x => x.Id == letterId);
            }
            return new Letter();
        }

        public Letter AddLetter(Letter letter)
        {
            using (var context = CreateTinyPocDbContext())
            {
                var dbLetter = context.Letters.FirstOrDefault(x => x.Id == letter.Id);
                if (dbLetter == null)
                {
                    context.Letters.Add(letter);
                }
                context.SaveChanges();
            }
            return letter;
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