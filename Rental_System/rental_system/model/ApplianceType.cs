using System.Collections.Generic;
using System.Data;

namespace Rental_System.rental_system.model
{
    class ApplianceType
    {
        public int id { get; set; }
        public string name { get; set; }
        public string usageTips { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }

        public ApplianceType() { }

        public ApplianceType(int id, string name, string usageTips, string description, string imagePath)
        {
            this.id = id;
            this.name = name;
            this.usageTips = usageTips;
            this.description = description;
            this.imagePath = imagePath;
        }

        public static List<ApplianceType> extractApplianceTypeFromDataTable(DataTable dataTable)
        {
            List<ApplianceType> applianceTypeList = new List<ApplianceType>();

            foreach (DataRow row in dataTable.Rows)
            {
                int id = row.Field<int>("ID");
                string name = row.IsNull("NAME") ? null : row.Field<string>("NAME");
                string usageTips = row.IsNull("USAGE_TIPS") ? null : row.Field<string>("USAGE_TIPS");
                string description = row.IsNull("DESCRIPTION") ? null : row.Field<string>("DESCRIPTION");
                string imagePath = row.IsNull("IMAGEPATH") ? null : row.Field<string>("IMAGEPATH");

                ApplianceType applianceType = new ApplianceType(id, name, usageTips, description, imagePath);

                applianceTypeList.Add(applianceType);
            }

            return applianceTypeList;
        }
    }
}
