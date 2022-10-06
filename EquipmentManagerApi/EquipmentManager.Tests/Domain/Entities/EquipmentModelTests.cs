using AutoFixture;
using EquipmentManager.Domain.Entities;
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
        public void DadoUmNomeInvalido_NaoDeveAtribuirPropriedade()
        {
            var name = string.Empty;
            var equipmentModel = new EquipmentModel(name);

            Assert.False(equipmentModel.IsValid);
            Assert.Null(equipmentModel.ModelName);
        }

        [Fact]
        public void DadoUmNomeComTamanhoInvalido_NaoDeveAtribuirPropriedade()
        {
            var name = "xp";
            var equipmentModel = new EquipmentModel(name);

            Assert.False(equipmentModel.IsValid);
            Assert.Null(equipmentModel.ModelName);
        }

        [Fact]
        public void DadoUmNomeValido_DeveAtribuirPropriedade()
        {
            var name = _fixture.Create<string>();
            var equipmentModel = new EquipmentModel(name);

            Assert.True(equipmentModel.IsValid);
            Assert.NotEmpty(equipmentModel.ModelName);
        }
    }
}
