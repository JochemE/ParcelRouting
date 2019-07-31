using System.Collections.Generic;
using System.Linq;
using ParcelRouting.Router.Departments;

namespace ParcelRouting.Router
{
    public class ParcelHandler
    {
        private readonly ParcelHandlerSettings settings;

        public ParcelHandler(ParcelHandlerSettings settings)
        {
            this.settings = settings;
            this.settings.Departments = new IDepartment[]
            {
                new MailDepartment(),
                new RegularDepartment()
            };
        }

        public IReadOnlyCollection<ParcelRoute> GetParcelRoutes(params Parcel[] parcels)
        {
            var parcelRoutes = parcels
                .Select(p => new ParcelRoute(p.Id, p.PostalCode, p.HouseNumber, p.Weight, p.DeclaredValue))
                .ToArray();

            foreach (var parcelRoute in parcelRoutes)
            {
                var applicableDepartments = settings.Departments.Where(d => d.CanHandle(parcelRoute.Weight));
                foreach (var department in applicableDepartments)
                {
                    parcelRoute.RouteVia(department.Name);    
                }
            }

            return parcelRoutes;
        }
    }
}
