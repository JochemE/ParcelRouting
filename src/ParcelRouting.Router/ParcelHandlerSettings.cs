using System.Collections.Generic;

namespace ParcelRouting.Router
{
    public class ParcelHandlerSettings
    {
        public IReadOnlyCollection<string> Departments { get; set; }
        public GetParcels GetParcels { get; set; }
    }
}