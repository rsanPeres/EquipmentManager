using AutoFixture;
using EquipmentManager.Domain.Entities;
using Newtonsoft.Json.Linq;
using Xunit;

namespace EquipmentManager.Tests.Domain.Entities
{
    public class EquipmentModelTests
    {
        private readonly Fixture _fixture;
        public EquipmentModelTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GivenAnInvalidName_ShouldNotAssignValueToProperty()
        {
            var name = string.Empty;
            var equipmentModel = new EquipmentModel(name);

            Assert.False(equipmentModel.IsValid);
            Assert.Null(equipmentModel.ModelName);
        }

        [Fact]
        public void GivenAnInvalidLengthName_ShouldNotAssignValueToProperty()
        {
            var name = "xp";
            var equipmentModel = new EquipmentModel(name);

            Assert.False(equipmentModel.IsValid);
            Assert.Null(equipmentModel.ModelName);
        }

        [Fact]
        public void GivenAValidName_ShouldAssignValueToProperty()
        {
            var name = _fixture.Create<string>();
            var equipmentModel = new EquipmentModel(name);

            Assert.True(equipmentModel.IsValid);
            Assert.NotEmpty(equipmentModel.ModelName);
        }
    }
}
