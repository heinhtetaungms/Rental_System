using Rental_System.rental_system.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rental_System.RentalDBDataSet;

namespace Rental_System.rental_system.service
{
    class AppliancesService
    {
        RentalDBDataSetTableAdapters.APPLIANCESTableAdapter appliancesTableAdapter = new RentalDBDataSetTableAdapters.APPLIANCESTableAdapter();

        public void save(AppliancesModel appliancesModel)
        {
            appliancesTableAdapter.Insert(appliancesModel.name, appliancesModel.brandName, appliancesModel.model, appliancesModel.dimensions, appliancesModel.color,
                                            appliancesModel.energyConsumption, Convert.ToDecimal(appliancesModel.monthlyFee), appliancesModel.minimumRentalPeriod,appliancesModel.typicalUsage,
                                            Convert.ToDecimal(appliancesModel.estimatedAnnualCost), appliancesModel.description, appliancesModel.imagePath, appliancesModel.applianceTypeId);
        }
        public void update(string name, string brandName, string model, string dimensions, string color, 
            string energyConsumption,string monthlyFee, string minimumRentalPeriod, string typicalUsage,string estimatedAnnualCost, string description, string imagePath,
            int applianceTypeId, string id)
        {
            appliancesTableAdapter.update(name, brandName, model, dimensions, color,
                energyConsumption, Convert.ToDecimal(monthlyFee), Convert.ToInt32(minimumRentalPeriod), typicalUsage, Convert.ToDecimal(estimatedAnnualCost), description, imagePath, 
                applianceTypeId, Convert.ToInt32(id));
        }
        public APPLIANCESDataTable GET_DATA()
        {
            return appliancesTableAdapter.GetData();
        }

        public DataTable findLatestRecord()
        {
            APPLIANCESDataTable table = new APPLIANCESDataTable();
            appliancesTableAdapter.findLatestRecord(table);
            return table;
        }
        public DataTable findByApplianceTypeId(int applianceTypeId)
        {
            APPLIANCESDataTable table = new APPLIANCESDataTable();
            appliancesTableAdapter.findByApplianceTypeID(table, applianceTypeId);
            return table;
        }
        public DataTable findById(int id)
        {
            APPLIANCESDataTable table = new APPLIANCESDataTable();
            appliancesTableAdapter.findByID(table, id);
            return table;
        }
        public void deleteById(int id)
        {
            appliancesTableAdapter.deleteById(id);
        }
    }
}
