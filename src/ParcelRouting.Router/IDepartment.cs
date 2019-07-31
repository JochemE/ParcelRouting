namespace ParcelRouting.Router
{
    public interface IDepartment
    {
        string Name { get; }

        bool CanHandle(double parcelWeight);
    }
}