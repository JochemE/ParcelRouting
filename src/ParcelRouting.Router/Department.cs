using System;

namespace ParcelRouting.Router.Departments
{
    public class Department : IDepartment
    {
        private readonly Func<ParcelRoute, bool> parcelRestrictions;

        public Department(string name, Func<ParcelRoute, bool> parcelRestrictions)
        {
            this.parcelRestrictions = parcelRestrictions;

            Name = name;
        }

        public string Name { get; }

        public bool CanHandle(ParcelRoute parcel)
        {
            return parcelRestrictions(parcel);
        }
    }
}