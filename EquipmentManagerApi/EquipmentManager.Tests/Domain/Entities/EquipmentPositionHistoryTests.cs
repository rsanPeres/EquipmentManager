using AutoFixture;
using EquipmentManager.Domain.Entities;
using System;
using Xunit;

namespace EquipmentManager.Tests.Domain.Entities
{
    public class EquipmentPositionHistoryTests
    {
        private readonly Fixture _fixture;
        public EquipmentPositionHistoryTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GivenAnInvalidName_ShouldNotAssignValueToProperty()
        {
            var latitude = string.Empty;
            var longitude = _fixture.Create<string>();
            var equipment = _fixture.Create<Equipment>();
            var positionDate = DateTime.UtcNow;

            var equipmentPositionHistory = new EquipmentPositionHistory(latitude, longitude,positionDate, equipment);

            Assert.False(equipmentPositionHistory.IsValid);
            Assert.Null(equipmentPositionHistory.Latitude);
            Assert.Null(equipmentPositionHistory.Length);
        }

        [Fact]
        public void GivenAnInvalidLengthName_ShouldNotAssignValueToProperty()
        {
            var latitude = "xp";
            var longitude = _fixture.Create<string>();
            var equipment = _fixture.Create<Equipment>();
            var positionDate = DateTime.UtcNow;

            var equipmentPositionHistory = new EquipmentPositionHistory(latitude, longitude, positionDate, equipment);

            Assert.False(equipmentPositionHistory.IsValid);
            Assert.Null(equipmentPositionHistory.Latitude);
            Assert.Null(equipmentPositionHistory.Length);
        }

        [Fact]
        public void GivenAValidName_ShouldAssignValueToProperty()
        {
            var longitude = _fixture.Create<string>();
            var latitude = _fixture.Create<string>();
            var equipment = _fixture.Create<Equipment>();
            var positionDate = DateTime.UtcNow;

            var equipmentPositionHistory = new EquipmentPositionHistory(latitude, longitude, positionDate, equipment);

            Assert.True(equipmentPositionHistory.IsValid);
            Assert.NotEmpty(equipmentPositionHistory.Latitude);
            Assert.NotEmpty(equipmentPositionHistory.Length);
        }
    }
}
