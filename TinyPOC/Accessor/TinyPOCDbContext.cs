using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TinyPOC.Models;

namespace TinyPOC.Accessor
{
    public class TinyPOCDbContext : DbContext
    {

        public TinyPOCDbContext()
            : base("name=TinyPOCDbContext") { }

        public virtual DbSet<Template> Templates { get; set; }

        public virtual DbSet<Letter> Letters { get; set; }
    }
}