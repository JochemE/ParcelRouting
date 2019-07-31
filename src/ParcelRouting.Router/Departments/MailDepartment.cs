namespace ParcelRouting.Router.Departments
{
    public class MailDepartment : IDepartment
    {
        public string Name => "Mail";

        public bool CanHandleWeight(double parcelWeight)
        {
            return parcelWeight <= 1;
        }

        public bool CanHandleDeclaredValue(double parcelValue)
        {
            return true;
        }
    }
}