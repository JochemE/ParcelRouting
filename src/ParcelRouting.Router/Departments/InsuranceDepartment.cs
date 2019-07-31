namespace ParcelRouting.Router.Departments
{
    public class InsuranceDepartment : IDepartment
    {
        public string Name => "Insurance";

        public bool CanHandleWeight(double parcelWeight)
        {
            return true;
        }

        public bool CanHandleDeclaredValue(double parcelValue)
        {
            return parcelValue > 1000;
        }
    }
}