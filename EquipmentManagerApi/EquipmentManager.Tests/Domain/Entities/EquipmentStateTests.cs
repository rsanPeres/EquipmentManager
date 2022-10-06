using AutoFixture;
using EquipmentManager.Domain.Entities;
using Xunit;

namespace EquipmentManager.Tests.Domain.Entities
{
    public class EquipmentStateTests
    {
        private readonly Fixture _fixture;
        public EquipmentStateTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void DadoUmNomeInvalido_NaoDeveAtribuirPropriedade()
        {
            var stateName = string.Empty;
            var equipmentColor = _fixture.Create<string>();

            var equipmentState = new EquipmentState(stateName, equipmentColor);

            Assert.False(equipmentState.IsValid);
            Assert.Null(equipmentState.StateName);
            Assert.Null(equipmentState.EquipmentColor);
        }

        [Fact]
        public void DadoUmNomeComTamanhoInvalido_NaoDeveAtribuirPropriedade()
        {
            var stateName = "xp";
            var equipmentColor = _fixture.Create<string>();

            var equipmentState = new EquipmentState(stateName, equipmentColor);

            Assert.False(equipmentState.IsValid);
            Assert.Null(equipmentState.StateName);
            Assert.Null(equipmentState.EquipmentColor);
        }

        [Fact]
        public void DadoUmNomeValido_DeveAtribuirPropriedade()
        {
            var stateName = _fixture.Create<string>();
            var equipmentColor = _fixture.Create<string>();

            var equipmentState = new EquipmentState(stateName, equipmentColor);

            Assert.True(equipmentState.IsValid);
            Assert.NotEmpty(equipmentState.StateName);
            Assert.NotEmpty(equipmentState.EquipmentColor);
        }
    }
}
