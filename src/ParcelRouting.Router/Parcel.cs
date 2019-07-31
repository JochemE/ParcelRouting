namespace ParcelRouting.Router
{
    public class Parcel
    {
        public Parcel(string id, string postalCode, string houseNumber, double weight, double declaredValue)
        {
            Id = id;
            PostalCode = postalCode;
            HouseNumber = houseNumber;
            Weight = weight;
            DeclaredValue = declaredValue;
        }

        public string Id { get; }
        public string PostalCode { get; }
        public string HouseNumber { get; }
        public double Weight { get; }
        public double DeclaredValue { get; }
    }
}
