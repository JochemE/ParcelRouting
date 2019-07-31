namespace ParcelRouting.Router.Departments
{
    public class MailDepartment : IDepartment
    {
        public string Name => "Mail";

        public bool CanHandle(double parcelWeight)
        {
            return parcelWeight <= 1;
        }
    }
}