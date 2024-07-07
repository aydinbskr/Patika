using SiteManagementSystem.Repository.Apartments;
using SiteManagementSystem.Repository.Bills;
using SiteManagementSystem.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Payments
{
    public class Payment:BaseEntity<int>
    {
        public string PaymentMethod { get; set; } // "CreditCard" or "Cash"
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; } // "Dues" or "Bill" ("Electricity", "Water", "Gas")
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public Apartment Apartment { get; set; }
        public User User { get; set; }
        public  Bill Bill { get; set; }

        public Payment()
        {
        }

        public Payment(string paymentMethod, DateTime paymentDate, string paymentType, decimal amount, int year, int month, int apartmentId, int userId, Apartment apartment, User user, Bill bill)
        {
            PaymentMethod = paymentMethod;
            PaymentDate = paymentDate;
            PaymentType = paymentType;
            Amount = amount;
            Year = year;
            Month = month;
            ApartmentId = apartmentId;
            UserId = userId;
            Apartment = apartment;
            User = user;
            Bill = bill;
        }
    }
}
