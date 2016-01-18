using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BackboneSampe.Models;

namespace BackboneSampe.DAL
{
    public class ContextClass:DbContext
    {
        public ContextClass() :base("context")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}