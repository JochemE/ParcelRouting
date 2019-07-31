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
            var parcel = new Parcel("some Id", "1234 AB", "1 a", 0.2, 0);

            var parcelHandler = new ParcelHandler();

            parcelHandler.GetParcelRoutes(parcel)
                .Single()
                .Should().BeEquivalentTo(parcel);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1.0)]
        public void parcels_with_weight_up_to_1kg_should_be_routed_via_mail_department(double parcelWeight)
        {
            var parcelHandler = new ParcelHandler();

            parcelHandler.GetParcelRoutes(new Parcel("someId", "1234AB", "1a", parcelWeight, 0))
                .Single()
                .Departments.Should().BeEquivalentTo("Mail");
        }
        
        [Theory]
        [InlineData(1.01)]
        [InlineData(9.99)]
        public void parcel_with_weight_up_to_10kg_should_be_routed_via_regular_department(double parcelWeight)
        {
            var parcelHandler = new ParcelHandler();

            parcelHandler.GetParcelRoutes(new Parcel("someId", "1234AB", "1a", parcelWeight, 0))
                .Single()
                .Departments.Should().BeEquivalentTo("Regular");
        }

        [Theory]
        [InlineData(10.01)]
        public void parcel_with_weight_over_10kg_should_be_routed_via_heavy_department(double parcelWeight)
        {
            var parcelHandler = new ParcelHandler();

            parcelHandler.GetParcelRoutes(new Parcel("someId", "1234AB", "1a", parcelWeight, 0))
                .Single()
                .Departments.Should().BeEquivalentTo("Heavy");
        }

        [Fact]
        public void parcel_with_a_declared_value_over_1k_euro_should_be_routed_via_the_insurance_department_first()
        {
            var parcelHandler = new ParcelHandler();

            parcelHandler.GetParcelRoutes(new Parcel("someId", "1234AB", "1a", 10.01, 1000.01))
                .Single()
                .Departments.Should()
                .BeEquivalentTo(new [] {"Insurance", "Heavy"}, opt => opt
                    .WithStrictOrdering());
        }
    }
}
