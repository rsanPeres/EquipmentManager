using AutoFixture;
using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Services;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Enums;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManagerApi.Mappers;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace EquipmentManager.Tests.Service
{
    public class UserServiceTests
    {
        private readonly Fixture _fixture;
        private Mock<IUserRepository> _repository;
        private Mock<IMapper> _mapper;
        public UserServiceTests()
        {
            _fixture = new Fixture();
            _repository = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void GivenAValidUser_ShouldCreateOnRepository()
        {
            var userDto = _fixture.Create<UserDto>();
            var service = new UserService(AutomapperSingleton.Mapper, _repository.Object);

            service.Create(userDto);

            Assert.True(service.IsValid);
            Assert.NotNull(userDto);
            _repository.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void GivenInvalidUser_ShouldNotCreate()
        {
            var userDto = _fixture.Build<UserDto>()
                .Without(x => x.UserName).With(x => x.UserName, "xp").Create();
            var service = new UserService(AutomapperSingleton.Mapper, _repository.Object);

            service.Create(userDto);

            Assert.NotNull(userDto);
            Assert.False(service.IsValid);
            _repository.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public void GivenAnInvalidId_ShoulReturnNull()
        {
            var user = _fixture.Build<User>().Create();
            user.SetEmployeeCpf(string.Empty);
            _repository.Setup(x => x.Get(It.Is<string>(x => x.Equals(user.Cpf)))).Returns(value : null);
            var service = new UserService(AutomapperSingleton.Mapper, _repository.Object);

            var result = service.Get(user.Cpf);

            _repository.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
            result.Should().Be(null);
        }

        [Fact]
        public void GivenAValidId_ShouldReturnAnUser()
        {
            var user = _fixture.Create<User>();
            _repository.Setup(x => x.Get(It.Is<string>(x => x.Equals( user.Cpf)))).Returns(user);
            var service = new UserService(AutomapperSingleton.Mapper, _repository.Object);

            var result = service.Get(user.Cpf);

            Assert.True(service.IsValid);
            Assert.True(user.IsValid);
            _repository.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
            result.Should().BeOfType(typeof(UserDto));
        }

        [Fact]
        public void GivenANewRole_ShouldUpdadeUser()
        {
            var user = _fixture.Create<User>();
            var userDto = _fixture.Build<UserDto>().With(x => x.Role, RoleNames.Manager).Create();
            _repository.Setup(x => x.Get(It.IsAny<string>())).Returns(user);
            var service = new UserService(AutomapperSingleton.Mapper, _repository.Object);

            service.Update(userDto);

            Assert.True(service.IsValid);
            Assert.True(user.IsValid);
            Assert.NotNull(userDto);
            _repository.Verify(x => x.Update(It.IsAny<User>()), Times.Once);

        }

        [Fact]
        public void GivenAnInvalidUser_ShouldNotDelete()
        {
            var user = _fixture.Build<User>().Create();
            user.SetEmployeeCpf("");
            user.SetUserName("xp");
            user.SetPassword("pass");
            var userDto = _fixture.Build<UserDto>().With(x => x.Cpf, user.Cpf).With(x => x.UserName, user.UserName).Create();
            _repository.Setup(x => x.Get(It.Is<string>(x => x.Equals(user.Cpf)))).Returns(user);
            var service = new UserService(AutomapperSingleton.Mapper, _repository.Object);

            service.Delete(userDto);
            Assert.False(user.IsValid);
            Assert.True(service.IsValid);
            _repository.Verify(x => x.Delete(It.IsAny<string>()), Times.Never);
            _repository.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Fact]
        public void GivenAValidUser_ShouldDelete()
        {
            var user = _fixture.Create<User>();
            var userDto = _fixture.Build<UserDto>().With(x => x.Cpf, user.Cpf).With(x => x.UserName, user.UserName).Create();
            _repository.Setup(x => x.Get(It.Is<string>(x => x.Equals(user.Cpf)))).Returns(user);
            _repository.Setup(x => x.Delete(It.IsAny<string>()));
            var service = new UserService(AutomapperSingleton.Mapper, _repository.Object);

            service.Delete(userDto);

            Assert.True(user.IsValid);
            Assert.True(service.IsValid);
            _repository.Verify(x => x.Delete(It.Is<string>(x => x.Equals(user.Cpf))), Times.Once);
            _repository.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
