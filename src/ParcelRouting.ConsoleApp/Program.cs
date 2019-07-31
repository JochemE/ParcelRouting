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

            var parcelHandler = new ParcelHandler(new ParcelHandlerSettings());

            foreach (var parcelRoute in parcelHandler.GetParcelRoutes(parcelStore.GetAll().ToArray()))
            {
                Console.WriteLine("=========================");
                Console.WriteLine($"Parcel: {parcelRoute.PostalCode}-{parcelRoute.HouseNumber}-{parcelRoute.Id}");
                Console.WriteLine($"- weight: {parcelRoute.Weight}");
                Console.WriteLine($"- declared value: {parcelRoute.DeclaredValue}");
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
