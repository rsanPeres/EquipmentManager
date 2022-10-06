using AutoFixture;
using EquipmentManager.Domain.Entities;
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
        public void DadoUmNomeInvalido_NaoDeveAtribuirPropriedade()
        {
            var latitude = string.Empty;
            var longitude = _fixture.Create<string>();

            var equipmentPositionHistory = new EquipmentPositionHistory(latitude, longitude);

            Assert.False(equipmentPositionHistory.IsValid);
            Assert.Null(equipmentPositionHistory.Latitude);
            Assert.Null(equipmentPositionHistory.Longitude);
        }

        [Fact]
        public void DadoUmNomeComTamanhoInvalido_NaoDeveAtribuirPropriedade()
        {
            var latitude = "xp";
            var longitude = _fixture.Create<string>();

            var equipmentPositionHistory = new EquipmentPositionHistory(latitude, longitude);

            Assert.False(equipmentPositionHistory.IsValid);
            Assert.Null(equipmentPositionHistory.Latitude);
            Assert.Null(equipmentPositionHistory.Longitude);
        }

        [Fact]
        public void DadoUmNomeValido_DeveAtribuirPropriedade()
        {
            var longitude = _fixture.Create<string>();
            var latitude = _fixture.Create<string>();
            var equipmentPositionHistory = new EquipmentPositionHistory(latitude, longitude);

            Assert.True(equipmentPositionHistory.IsValid);
            Assert.NotEmpty(equipmentPositionHistory.Latitude);
            Assert.NotEmpty(equipmentPositionHistory.Longitude);
        }
    }
}
