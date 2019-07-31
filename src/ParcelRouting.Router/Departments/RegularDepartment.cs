﻿namespace ParcelRouting.Router.Departments
{
    public class RegularDepartment : IDepartment
    {
        public string Name => "Regular";

        public bool CanHandleWeight(double parcelWeight)
        {
            return parcelWeight > 1 && parcelWeight <=10;
        }

        public bool CanHandleDeclaredValue(double parcelValue)
        {
            return true;
        }
    }
}