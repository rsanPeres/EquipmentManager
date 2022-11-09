using AutoFixture;
using EquipmentManager.Domain.Entities;
using Xunit;

namespace EquipmentManager.Tests.Domain.Entities
{
    public class EquipmentTests
    {
        private readonly Fixture _fixture;
        public EquipmentTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GivenAnInvalidName_ShouldNotAssignValueToProperty()
        {
            var equipmentModel = _fixture.Create<EquipmentModel>();
            var name = string.Empty;
            var equipment = new Equipment(name, equipmentModel);

            Assert.False(equipment.IsValid);
            Assert.Null(equipment.Name);
        }//testando biblioteca

        [Fact]
        public void GivenAnInvalidLengthName_ShouldNotAssignValueToProperty()
        {
            var equipmentModel = _fixture.Create<EquipmentModel>();
            var name = "xp";
            var equipment = new Equipment(name, equipmentModel);

            Assert.False(equipment.IsValid);
            Assert.Null(equipment.Name);
        }

        [Fact]
        public void GivenAValidName_ShouldAssignValueToProperty()
        {
            var equipmentModel = _fixture.Create<EquipmentModel>();
            var name = _fixture.Create<string>();
            var equipment = new Equipment(name, equipmentModel);

            Assert.True(equipment.IsValid);
        }

        [Fact]
        public void GivenAnEquipmentModel_ShouldAssignValueToProperty()
        {
            EquipmentModel equipmentModel = _fixture.Create<EquipmentModel>();
            var name = _fixture.Create<string>();
            var equipment = new Equipment(name, equipmentModel);
            
            Assert.True(equipment.IsValid);
            Assert.NotEmpty(equipment.Name);
        }

        [Fact]
        public void GivenAnEquipmentModelNull_ShouldNotAssignValueToProperty()
        {
            EquipmentModel equipmentModel = null;
            var name = _fixture.Create<string>();
            var equipment = new Equipment(name, equipmentModel);

            Assert.False(equipment.IsValid);
            Assert.Null(equipment.Name);
        }
    }
}
