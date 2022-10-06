using AutoFixture;
using EquipmentManager.Domain.Entities;
using Xunit;

namespace EquipmentManager.Tests.Domain.Entities
{
    public class EquipmentTests
    {
        private readonly Fixture _fixture;
        public EquipmentTests(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void DadoUmNomeInvalido_NaoDeveAtribuirPropriedade()
        {
            var equipmentModel = _fixture.Create<EquipmentModel>();
            var name = string.Empty;
            var equipment = new Equipment(name, equipmentModel);

            Assert.False(equipment.IsValid);
            Assert.Null(equipment.Name);
        }

        [Fact]
        public void DadoUmNomeComTamanhoInvalido_NaoDeveAtribuirPropriedade()
        {
            var equipmentModel = _fixture.Create<EquipmentModel>();
            var name = "xp";
            var equipment = new Equipment(name, equipmentModel);

            Assert.False(equipment.IsValid);
            Assert.Null(equipment.Name);
        }
    }
}
