namespace ParcelRouting.Router.Departments
{
    public class RegularDepartment : IDepartment
    {
        public string Name => "Regular";

        public bool CanHandle(double parcelWeight)
        {
            return parcelWeight > 1 && parcelWeight <=10;
        }
    }
}