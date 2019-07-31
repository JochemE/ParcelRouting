using System.Collections.Generic;
using System.Linq;

namespace ParcelRouting.Router
{
    public class ParcelHandler
    {
        private readonly ParcelHandlerSettings settings;

        public ParcelHandler(ParcelHandlerSettings settings)
        {
            this.settings = settings;
        }

        public IReadOnlyCollection<ParcelRoute> GetParcelRoutes()
        {
            var parcelRoutes = settings
                .GetParcels()
                .Select(p => new ParcelRoute(p.Id, p.PostalCode, p.HouseNumber, p.Weight, p.DeclaredValue))
                .ToArray();

            foreach (var parcelRoute in parcelRoutes)
            {
                parcelRoute.RouteVia("Mail");
            }

            return parcelRoutes;
        }
    }
}
