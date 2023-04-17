using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.Models
{
    public class PhoneEntry
    {
        public int Id { get; set ; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public PhoneEntry() 
        {
            Id = -1;
            Name = string.Empty;
            Phone = string.Empty;
        }
        public PhoneEntry(int Id, string Name, string Phone)
        {
            this.Id = Id;
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.Phone = Phone ?? throw new ArgumentNullException(nameof(Phone));
        }

        public PhoneEntry(string Name, string Phone)
        {
            Id = -1;
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.Phone = Phone ?? throw new ArgumentNullException(nameof(Phone));
        }
    }
}