using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models
{
    public class DonationLevel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Campaign Campaign { get; set; }
        
    }
}