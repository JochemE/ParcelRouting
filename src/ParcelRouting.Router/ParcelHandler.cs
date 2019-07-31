using System.Collections.Generic;
using System.Linq;
using ParcelRouting.Router.Departments;

namespace ParcelRouting.Router
{
    public class ParcelHandler
    {
        private readonly IDepartment[] departments;

        public ParcelHandler()
        {
            departments = new IDepartment[]
            {
                new Department("Insurance", parcel => parcel.DeclaredValue > 1000), 
                new Department("Mail", parcel => parcel.Weight <= 1), 
                new Department("Regular", parcel => parcel.Weight > 1 && parcel.Weight <=10), 
                new Department("Heavy", parcel => parcel.Weight > 10)
            };
        }

        public IReadOnlyCollection<ParcelRoute> GetParcelRoutes(params Parcel[] parcels)
        {
            var parcelRoutes = parcels
                .Select(p => new ParcelRoute(p.Id, p.PostalCode, p.HouseNumber, p.Weight, p.DeclaredValue))
                .ToArray();

            foreach (var parcelRoute in parcelRoutes)
            {
                var applicableDepartments = departments
                    .Where(d => d.CanHandle(parcelRoute));

                foreach (var department in applicableDepartments)
                {
                    parcelRoute.RouteVia(department.Name);    
                }
            }

            return parcelRoutes;
        }
    }
}
