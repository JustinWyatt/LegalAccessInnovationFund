using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models
{
    public class Contribution
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
    }
}