using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab3.Models
{
    public class AppContext:DbContext
    {
        public DbSet<PhoneEntry> phones { get; set; }

        public AppContext():base()
        {
            Database.CreateIfNotExists();
        }
    }
}