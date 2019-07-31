using System.Linq;
using FluentAssertions;
using ParcelRouting.Router;
using Xunit;

namespace ParcelRouting.Tests
{
    public class ParcelHandlerTests
    {
        [Fact]
        public void parcel_routes_should_contain_original_parcel_information()
        {
            var subject = new Parcel("someId", "1234AB", "1a", 0.2, 0);

            var parcelHandler = new ParcelHandler(new ParcelHandlerSettings
            {
                Departments = new string[0],
                GetParcels = () => new [] { subject }.ToArray()
            });

            parcelHandler.GetParcelRoutes().Single()
                .Should().BeEquivalentTo(subject);
        }

        [Fact]
        public void parcel_with_weight_up_to_1kg_should_be_routed_via_mail_department()
        {
            var parcelHandler = new ParcelHandler(new ParcelHandlerSettings
            {
                Departments = new []{ "Mail", "Regular", "Heavy", "Insurance" },
                GetParcels = () => new []
                {
                    new Parcel("someId", "1234AB", "1a", 1.0, 0)
                }.ToArray()
            });

            parcelHandler.GetParcelRoutes().Single().Departments.Should().BeEquivalentTo("Mail");
        }
    }
}
