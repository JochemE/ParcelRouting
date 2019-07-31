using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ParcelRouting.Router;

namespace ParcelRouting.ConsoleApp
{
    /// <summary>
    /// Store that reads and parses the raw-xml from an embedded resource stream.
    /// </summary>
    internal class EmbeddedResourceParcelStore
    {
        internal IReadOnlyCollection<Parcel> GetAll()
        {
            var currentAssembly = typeof(Program).GetTypeInfo().Assembly;

            string manifestName = currentAssembly
                .GetManifestResourceNames()
                .Single(n => n.EndsWith("Container_68465468.xml"));

            using (var stream = currentAssembly.GetManifestResourceStream(manifestName))
            {
                var doc = XDocument.Load(stream);

                return doc
                    .Root
                    .Element("parcels")
                    .Elements("Parcel")
                    .Select((e, index) =>
                    {
                        string postalCode = e.Element("Receipient").Element("Address").Element("PostalCode").Value;
                        string houseNumber = e.Element("Receipient").Element("Address").Element("HouseNumber").Value;

                        return new Parcel(
                            id: $"{(index + 1).ToString("D3")}",
                            postalCode: postalCode,
                            houseNumber: houseNumber,
                            weight: double.Parse(e.Element("Weight").Value, 
                                NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture),
                            declaredValue: double.Parse(e.Element("Value").Value, 
                                NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture));
                    })
                    .ToArray();
            }
        }
    }
}
