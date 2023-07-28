using Rental_System.rental_system.model;
using System.Data;
using static Rental_System.RentalDBDataSet;

namespace Rental_System.rental_system.service
{
    class ApplianceTypeService
    {
        RentalDBDataSetTableAdapters.APPLIANCE_TYPETableAdapter applianceTypeTableAdapter = new RentalDBDataSetTableAdapters.APPLIANCE_TYPETableAdapter();

        public void save(ApplianceType applianceType)
        {
            applianceTypeTableAdapter.Insert(applianceType.name, applianceType.usageTips, applianceType.description, applianceType.imagePath);
        }
        public void update(string name, string usageTips, string description, string imagePath, int id)
        {
            applianceTypeTableAdapter.update(name, usageTips, description, imagePath, id);
        }
        public APPLIANCE_TYPEDataTable GET_DATA()
        {
            return applianceTypeTableAdapter.GetData();
        }

        public DataTable findLatestRecord()
        {
            APPLIANCE_TYPEDataTable table = new APPLIANCE_TYPEDataTable();
            applianceTypeTableAdapter.findLatestRecord(table);
            return table;
        }
        public void deleteById(int id)
        {
            applianceTypeTableAdapter.deleteById(id);
        }
    }
}
