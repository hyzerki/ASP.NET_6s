using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionaryLib
{
    public class AppContext : DbContext
    {
        public DbSet<PhoneEntry> phones { get; set; }

        public AppContext() : base()
        {
            Database.CreateIfNotExists();
        }
    }
}
