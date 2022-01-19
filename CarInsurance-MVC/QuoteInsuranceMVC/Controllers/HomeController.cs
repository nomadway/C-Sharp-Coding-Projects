using QuoteInsuranceMVC.Models;
using QuoteInsuranceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuoteInsuranceMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quote(string FirstName, string LastName, string EmailAddress, DateTime DoB, int CarYear, string CarMake, string CarModel, bool DUI, int Ticket, string Coverage)
        {
          
            QuoteVm quote = new QuoteVm();
            quote.Quote = 50d;
            int age = Convert.ToInt32(DateTime.Today.Year - DoB.Year);
            if (age <= 18)
            {
                quote.Quote += 100d;
            }
            if (age >= 19 && age <=25 )
            {
                quote.Quote += 50d;
            }
            if (age > 25)
            {
                quote.Quote += 25d;
            }
            if (CarYear < 2000)
            {
                quote.Quote += 25d;
            }
            if (CarYear > 2015)
            {
                quote.Quote += 25d;
            }
            if (CarMake == "Porsche")
            {
                quote.Quote += 25d;
            }
            if (CarModel == "911 Carrera")
            {
                quote.Quote += 25d;
            }
            for (int i = 0; i < Ticket; i++)
            {
                quote.Quote += 10d;
            }
            if (DUI)
            {
                double percent = quote.Quote * .25d;
                quote.Quote += percent;
            }
            Coverage = Coverage.ToLower();
            if (Coverage == "coverage")
            {
                double percent = quote.Quote * .50d;
                quote.Quote += percent;
            }
            
            using (InsuranceEntities database = new InsuranceEntities())
            {
                var customer = new Customer();
                customer.Quote = Convert.ToDecimal(quote.Quote);
                customer.FirstName = FirstName;
                customer.LastName = LastName;
                customer.EmailAddress = EmailAddress;
                customer.DoB = DoB;
                customer.CarYear = CarYear;
                customer.CarMake = CarMake;
                customer.CarModel = CarModel;
                customer.DUI = DUI;
                customer.Ticket = Ticket;
                customer.Coverage = Coverage;
                database.Customers.Add(customer);
                database.SaveChanges();
            }
            return View("Success");
        }

        public ActionResult Success()
        {

            return View();
        }
       
        public ActionResult Admin()
        {
            using (InsuranceEntities dataBase = new InsuranceEntities())
            {
                var customers = dataBase.Customers.ToList();
                var QuotaVms = new List<QuotaVm>();
                foreach (var customer in customers)
                {
                    var QuotaVm = new QuotaVm();
                    QuotaVm.Quote = Convert.ToDouble(customer.Quote);
                    QuotaVm.FirstName = customer.FirstName;
                    QuotaVm.LastName = customer.LastName;
                    QuotaVm.EmailAddress = customer.EmailAddress;
                    QuotaVms.Add(QuotaVm);
                }
                return View(QuotaVms);
            }
        }
    }
}



