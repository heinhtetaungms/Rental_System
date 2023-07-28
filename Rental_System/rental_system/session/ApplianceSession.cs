using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_System.rental_system.session
{
    class ApplianceSession
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brandName { get; set; }
        public string model { get; set; }
        public string dimensions { get; set; }
        public string color { get; set; }
        public string energyConsumption { get; set; }
        public decimal monthlyFee { get; set; }
        public int minimumRentalPeriod { get; set; }
        public string typicalUsage { get; set; }
        public decimal estimatedAnnualCost { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }
        public int applianceTypeId { get; set; }

        //additional fields for checkout process
        public int rentedMonths { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        
    }
}
