using eAgendaMedica.Application.ActivityModule;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using FizzWare.NBuilder;
using FluentResults;
using Moq;

namespace eAgendaMedica.Tests.Application
{
    [TestClass]
    public class ActivityAppServiceTest
    {
        private Mock<IActivityRepository> _repositoryMoq;
        private Mock<IActivityValidator> _validatorMoq;
        private Mock<IPersistenceContext> _contextMoq;
        private Mock<DoctorAppService> _doctorServiceMoq;
        private ActivityAppService _service;
        private Activity _activity;

        [TestInitialize]
        public async Task Setup()
        {
            _repositoryMoq = new Mock<IActivityRepository>();
            _validatorMoq = new Mock<IActivityValidator>();
            _contextMoq = new Mock<IPersistenceContext>();
            _doctorServiceMoq = new Mock<DoctorAppService>();

            _service = new ActivityAppService(_repositoryMoq.Object, _contextMoq.Object);

            var doctor = new Doctor
            {
                CRM = "23347-SP",
                Name = "Dr Exemplo4"
            };
            var doctors = new List<Doctor> { doctor };

            _activity = new Activity("Teste", TypeActivity.Surgery, DateTime.Now, DateTime.Now.AddDays(1), TimeSpan.FromHours(8),
                        TimeSpan.FromHours(12), doctors, "primary");
        }

        [TestMethod]
        public async Task Shoud_Add_an_Activity_when_valid()
        {
            var result = await _service.AddAsync(_activity);

            result.Should().BeSuccess();
            _repositoryMoq.Verify(x => x.AddAsync(_activity), Times.Once());
        }

        [TestMethod]
        public async Task Should_not_Add_an_Activity_when_invalid()
        {
            _activity.Title = "";

            _validatorMoq.Setup(x => x.Validate(It.IsAny<Activity>())).Returns(() =>
            {
                var result = new ValidationResult();
                result.Errors.Add(new ValidationFailure("error", "error"));
                return result;
            });

            var result = await _service.AddAsync(_activity);

            result.Should().BeFailure();
            _repositoryMoq.Verify(x => x.AddAsync(_activity), Times.Never());
        }

        [TestMethod]
        public async Task Shoud_Update_an_Activity_when_valid()
        {

            var result = await _service.UpdateAsync(_activity);

            result.Should().BeSuccess();
            _repositoryMoq.Verify(x => x.Update(_activity), Times.Once());
        }

        [TestMethod]
        public async Task Should_not_Update_an_Activity_when_invalid()
        {
            _activity.Title = "";

            _validatorMoq.Setup(x => x.Validate(It.IsAny<Activity>())).Returns(() =>
            {
                var result = new ValidationResult();
                result.Errors.Add(new ValidationFailure("error", "error"));
                return result;
            });

            var result = await _service.UpdateAsync(_activity);

            result.Should().BeFailure();
            _repositoryMoq.Verify(x => x.Update(_activity), Times.Never());
        }

        [TestMethod]
        public async Task Should_Remove_an_Activity()
        {
            _repositoryMoq.Setup(x => x.GetByIdAsync(_activity.Id))
                .ReturnsAsync(_activity);

            var result = await _service.RemoveAsync(_activity.Id);

            result.Should().BeSuccess();

            _repositoryMoq.Verify(x => x.Remove(_activity), Times.Once());
        }
    }
}
