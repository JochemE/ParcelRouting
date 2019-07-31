using System.Linq;

namespace ParcelRouting.Router
{
    public class ParcelRoute
    {
        public ParcelRoute(string id, string postalCode, string houseNumber, double weight, double declaredValue)
        {
            Id = id;
            PostalCode = postalCode;
            HouseNumber = houseNumber;
            Weight = weight;
            DeclaredValue = declaredValue;
            Departments = new string[0];
        }

        public string Id { get; }
        public string PostalCode { get; }
        public string HouseNumber { get; }
        public double Weight { get; }
        public double DeclaredValue { get; }
        public string[] Departments { get; private set; }

        public void RouteVia(string department)
        {
            Departments = Departments
                .Union(new [] { department })
                .ToArray();
        }
    }
}