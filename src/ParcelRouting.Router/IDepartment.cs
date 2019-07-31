namespace ParcelRouting.Router
{
    public interface IDepartment
    {
        string Name { get; }

        bool CanHandleWeight(double parcelWeight);

        bool CanHandleDeclaredValue(double parcelValue);
    }
}