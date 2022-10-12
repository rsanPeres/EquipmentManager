using AutoFixture;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using EquipmentManager.Repository.Repositories;
using FluentAssertions;
using Moq;
using System.Data.Entity;
using System.Net.Sockets;
using Xunit;

namespace EquipmentManager.Tests.Repository
{
    public class UserRepositoryTests
    {
        private readonly Fixture _fixture;
        private Mock<IApplicationContext> _context;
        private readonly UserRepository _userRepository;
        private Mock<DbSet<User>> _dbSet;
        public UserRepositoryTests()
        {
            _fixture = new Fixture();
            _context = new Mock<IApplicationContext>();
            _dbSet = new Mock<DbSet<User>>();
        }
        [Fact]
        public void GivenAUser_ShouldSaveOnDataBase()
        {
            var user = _fixture.Create<User>();
            //_context.Setup(x => x.User).Returns(_dbSet.Object);
            //_userRepository = new UserRepository(_context.Object);
            //_userRepository.Create(user);

            //_dbSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            //_userRepository.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
