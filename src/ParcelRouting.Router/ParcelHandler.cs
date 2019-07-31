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
                new InsuranceDepartment(),
                new MailDepartment(),
                new RegularDepartment(),
                new HeavyDepartment()
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
                    .Where(d => d.CanHandleWeight(parcelRoute.Weight))
                    .Where(d => d.CanHandleDeclaredValue(parcelRoute.DeclaredValue));

                foreach (var department in applicableDepartments)
                {
                    parcelRoute.RouteVia(department.Name);    
                }
            }

            return parcelRoutes;
        }
    }
}
