using AutoFixture;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Enums;
using Xunit;

namespace EquipmentManager.Tests.Domain.Entities
{
    public class UserTests
    {
        private readonly Fixture _fixture;
        public UserTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GivenAEmptyName_ShouldNotAssignValueToProperty()
        {
            var name = string.Empty;
            var password = _fixture.Create<string>();
            var role = _fixture.Create<RoleNames>();
            var cpf = "61711315630";

            var user = new User(name, password, role, cpf);

            Assert.Null(user.UserName);
            Assert.False(user.IsValid);
        }
    }
}
