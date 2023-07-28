using Rental_System.rental_system.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_System.rental_system.session
{
    class Sessions
    {
        public static Session createSession<T>(T customer) where T : Customer
        {
            Session session = new Session();
            session.id = customer.id;
            session.firstName = customer.firstName;
            session.lastName = customer.lastName;
            session.username = customer.username;
            session.password = customer.password;
            session.email = customer.email;
            session.phoneNumber = customer.phoneNumber;
            session.dateOfBirth = customer.dateOfBirth;
            session.gender = customer.gender;
            session.address = customer.address;
            session.isActive = customer.isActive;
            session.role = customer.role;
            session.imagePath = customer.imagePath;

            return session;
        }
        public static ApplianceSession createApplianceSession<T>(T applinace) where T : AppliancesModel
        {
            ApplianceSession session = new ApplianceSession();
            session.id = applinace.id;
            session.name = applinace.name;
            session.brandName = applinace.brandName;
            session.model = applinace.model;
            session.dimensions = applinace.dimensions;
            session.color = applinace.color;
            session.energyConsumption = applinace.energyConsumption;
            session.monthlyFee = applinace.monthlyFee;
            session.minimumRentalPeriod = applinace.minimumRentalPeriod;
            session.typicalUsage = applinace.typicalUsage;
            session.estimatedAnnualCost = applinace.estimatedAnnualCost;
            session.description = applinace.description;
            session.imagePath = applinace.imagePath;
            session.applianceTypeId = applinace.applianceTypeId;

            //used for checkout process
            session.rentedMonths = applinace.rentedMonths;
            session.startDate = applinace.startDate;
            session.endDate = applinace.endDate;
            
            return session;
        }
    }
}
