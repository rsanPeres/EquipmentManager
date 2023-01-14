using AutoFixture;
using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Services;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManagerApi.Mappers;
using Moq;
using System.Threading.Tasks;
using System;
using Xunit;

namespace EquipmentManager.Tests.Service
{
    public class EquipmentServiceTest
    {
        private readonly Fixture _fixture;
        private Mock<IEquipmentRepository> _equipmentRepository;
        private Mock<IEquipmentModelRepository> _modelRepository;
        private Mock<IEquipmentStateHistoryRepository> _stateHistoryRepository;
        private Mock<IEquipmentPositionHistoryRepository> _positionHistoryRepository;
        private Mock<IMapper> _mapper;
        private readonly EquipmentService _equipmentService;
        public EquipmentServiceTest()
        {
            _fixture = new Fixture();
            _equipmentRepository = new Mock<IEquipmentRepository>();
            _modelRepository = new Mock<IEquipmentModelRepository>();
            _stateHistoryRepository = new Mock<IEquipmentStateHistoryRepository>();
            _positionHistoryRepository = new Mock<IEquipmentPositionHistoryRepository>();
            _mapper = new Mock<IMapper>();
            _equipmentService = new EquipmentService(_equipmentRepository.Object, _modelRepository.Object,
                AutomapperSingleton.Mapper, _stateHistoryRepository.Object, _positionHistoryRepository.Object);
        }

        [Fact]
        public void GivenAValidEquipment_ShouldCreateOnRepository()
        {
            //testarei equipment service - create
            // testarei o create
            //testar se o equipment é null
            //instanciar equipment service e passar equipment null
            //arrange
            _equipmentRepository.Setup(x => x.Create(It.IsAny<Equipment>()));
            //act
            var ex = Assert.Throws<NullReferenceException>(() => _equipmentService.Create(null));
            //asset
            Assert.Equal("Equipment model must not be null", ex.Message);
            _equipmentRepository.Verify(x => x.Create(It.IsAny<Equipment>()), Times.Never());
            _positionHistoryRepository.Verify(x => x.Create(It.IsAny<EquipmentPositionHistory>()), Times.Never);
        }

       
    }
}