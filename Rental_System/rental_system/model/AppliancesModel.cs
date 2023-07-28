using System;
using System.Collections.Generic;
using System.Data;

namespace Rental_System.rental_system.model
{
    public class AppliancesModel
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
        public int rentedMonths { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public AppliancesModel() { }
        public AppliancesModel(int id, string name, string brandName, string model, 
            string dimensions,string color, string energyConsumption, decimal monthlyFee, int minimumRentalPeriod,
            string typicalUsage, decimal estimatedAnnualCost, string description, string imagePath, int applianceTypeId)
        {
            this.id = id;
            this.name = name;
            this.brandName = brandName;
            this.model = model;
            this.dimensions = dimensions;
            this.color = color;
            this.energyConsumption = energyConsumption;
            this.monthlyFee = monthlyFee;
            this.minimumRentalPeriod = minimumRentalPeriod;
            this.typicalUsage = typicalUsage;
            this.estimatedAnnualCost = estimatedAnnualCost;
            this.description = description;
            this.imagePath = imagePath;
            this.applianceTypeId = applianceTypeId;
        }

        public static List<AppliancesModel> extractAppliancesModelFromDataTable(DataTable dataTable)
        {
            List<AppliancesModel> appliancesModelList = new List<AppliancesModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                int id = row.Field<int>("ID");
                string name = row.IsNull("NAME") ? null : row.Field<string>("NAME");
                string brandName = row.IsNull("BRANDNAME") ? null : row.Field<string>("BRANDNAME");
                string model = row.IsNull("MODEL") ? null : row.Field<string>("MODEL");
                string dimensions = row.IsNull("DIMENSIONS") ? null : row.Field<string>("DIMENSIONS");
                string color = row.IsNull("COLOR") ? null : row.Field<string>("COLOR");
                string energyConsumption = row.IsNull("ENERGY_CONSUMPTION") ? null : row.Field<string>("ENERGY_CONSUMPTION");
                decimal? monthlyFee = row.IsNull("MONTHLY_FEE") ? 0 : row.Field<decimal>("MONTHLY_FEE");
                int? minimumRentalPeriod = row.IsNull("MINIMUM_RENTAL_PERIOD") ? 0 : row.Field<int>("MINIMUM_RENTAL_PERIOD");
                string typicalUsage = row.IsNull("TYPICAL_USAGE") ? null : row.Field<string>("TYPICAL_USAGE");
                decimal? estimatedAnnualCost = row.IsNull("ESTIMATED_ANNUAL_COST") ? 0 : row.Field<decimal>("ESTIMATED_ANNUAL_COST");
                string description = row.IsNull("DESCRIPTION") ? null : row.Field<string>("DESCRIPTION");
                string imagePath = row.IsNull("IMAGEPATH") ? null : row.Field<string>("IMAGEPATH");
                int applianceTypeId = row.Field<int>("APPLIANCE_TYPE_ID");

                AppliancesModel appliancesModel = new AppliancesModel(
                    id,
                    name,
                    brandName,
                    model,
                    dimensions,
                    color,
                    energyConsumption,
                    monthlyFee ?? 0, // Set default value if null
                    minimumRentalPeriod ?? 0, // Set default value if null
                    typicalUsage,
                    estimatedAnnualCost ?? 0, // Set default value if null
                    description,
                    imagePath,
                    applianceTypeId
                );

                appliancesModelList.Add(appliancesModel);
            }

            return appliancesModelList;
        }


    }
}
