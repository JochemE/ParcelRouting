namespace ParcelRouting.Router.Departments
{
    public class HeavyDepartment : IDepartment
    {
        public string Name => "Heavy";

        public bool CanHandle(double parcelWeight)
        {
            return parcelWeight > 10;
        }
    }
}