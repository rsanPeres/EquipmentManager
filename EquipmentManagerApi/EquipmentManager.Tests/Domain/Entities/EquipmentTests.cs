using EquipmentManager.Domain.Entities;
using Xunit;

namespace EquipmentManager.Tests.Domain.Entities
{
    public class EquipmentTests
    {
        [Fact]
        public void DadoUmNomeInvalido_NaoDeveAtribuirPropriedade()
        {
            var name = string.Empty;
            var equipment = new Equipment(name);

            Assert.False(equipment.IsValid);
            Assert.Null(equipment.Name);
        }

        [Fact]
        public void DadoUmNomeComTamanhoInvalido_NaoDeveAtribuirPropriedade()
        {
            var name = "xp";
            var equipment = new Equipment(name);

            Assert.False(equipment.IsValid);
            Assert.Null(equipment.Name);
        }
    }
}
