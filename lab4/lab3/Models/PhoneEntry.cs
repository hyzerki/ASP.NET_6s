using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Models
{
    public class PhoneEntry
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set ; }
        [Required]
        [MinLength(2)]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^(\+375|80)(29|33)\d{7}$")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        public PhoneEntry() 
        {
            Id = -1;
            //Name = string.Empty;
            //Phone = string.Empty;
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