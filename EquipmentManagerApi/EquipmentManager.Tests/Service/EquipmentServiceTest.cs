using AutoFixture;
using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Services;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManagerApi.Mappers;
using Moq;
using Xunit;

namespace EquipmentManager.Tests.Service
{
    public class EquipmentServiceTest
    {
        private readonly Fixture _fixture;
        private Mock<IEquipmentRepository> _equipmentRepository;
        private Mock<IEquipmentModelRepository> _modelRepository;
        private Mock<IMapper> _mapper;
        public EquipmentServiceTest()
        {
            _fixture = new Fixture();
            _equipmentRepository = new Mock<IEquipmentRepository>();
            _modelRepository = new Mock<IEquipmentModelRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void GivenAValidEquipment_ShouldCreateOnRepository()
        {
            var userDto = _fixture.Create<UserDto>();
            //var service = new EquipmentService(_equipmentRepository.Object, _modelRepository.Object, AutomapperSingleton.Mapper);

         
        }

       
    }
}