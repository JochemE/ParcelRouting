using System;
using System.Linq;
using ParcelRouting.Router;

namespace ParcelRouting.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parcelStore = new EmbeddedResourceParcelStore();
            var parcelHandler = new ParcelHandler(new ParcelHandlerSettings()
            {
                Departments = new []{ "Mail", "Regular", "Heavy", "Insurance" },
                GetParcels = () => parcelStore.GetAll().ToArray()
            });

            foreach (var parcelRoute in parcelHandler.GetParcelRoutes())
            {
                Console.WriteLine("=========================");
                Console.WriteLine($"Parcel: {parcelRoute.PostalCode}-{parcelRoute.HouseNumber}-{parcelRoute.Id}");
                Console.WriteLine($"Is routed (with strict order):");
                foreach (var department in parcelRoute.Departments)
                {
                    Console.WriteLine($"- {department}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
