namespace ParcelRouting.Router.Departments
{
    public class HeavyDepartment : IDepartment
    {
        public string Name => "Heavy";

        public bool CanHandleWeight(double parcelWeight)
        {
            return parcelWeight > 10;
        }

        public bool CanHandleDeclaredValue(double parcelValue)
        {
            return true;
        }
    }
}