using AutoFixture;
using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Services;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
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
            var service = new UserService(_mapper.Object, _repository.Object);

            service.Create(userDto);

            Assert.True(service.IsValid);
            Assert.NotNull(userDto);
            _repository.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void GivenInvalidUser_ShouldNotCreate()
        {
            var xp = "xp";
            var userDto = _fixture.Build<UserDto>()
                .Without(x => x.UserName).Create();
            userDto.UserName = xp;
            var service = new UserService(_mapper.Object, _repository.Object);

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
            var service = new UserService(_mapper.Object, _repository.Object);

            var result = service.Get(user.Cpf);
            _repository.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
            result.Should().Be(null);
        }

        [Fact]
        public void GivenAValidId_ShouldReturnAnUser()
        {
            var userDto = _fixture.Create<UserDto>();
            var user = _fixture.Build<User>().Create();
            user.SetEmployeeCpf(userDto.Cpf); 
            _repository.Setup(x => x.Get(It.Is<string>(x => x.Equals(user.Cpf)))).Returns(user);
            var service = new UserService(_mapper.Object, _repository.Object);

            var result = service.Get(user.Cpf);
            _repository.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
            result.Should().BeOfType(typeof(UserDto));
        }

        [Fact]
        public void GivenANewRole_ShouldUpdadeUser()
        {

        }

        [Fact]
        public void GivenAnInvalidUser_ShouldNotDelete()
        {

        }

        [Fact]
        public void GivenAValidUser_ShouldDelete()
        {

        }
    }
}
