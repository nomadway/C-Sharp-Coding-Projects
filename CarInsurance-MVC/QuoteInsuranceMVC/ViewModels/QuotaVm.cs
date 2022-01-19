using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteInsuranceMVC.ViewModels
{
    public class QuotaVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DoB { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public bool DUI { get; set; }
        public int Ticket { get; set; }
        public string Coverage { get; set; }
        public double Quote { get; set; }
    }
}