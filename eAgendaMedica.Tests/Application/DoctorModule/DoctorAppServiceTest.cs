using eAgendaMedica.Application.ActivityModule;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using Moq;

namespace eAgendaMedica.Tests.Application.DoctorModule
{
    [TestClass]
    public class DoctorAppServiceTest
    {
        private Mock<IDoctorRepository> _repositoryMoq;
        private Mock<IActivityRepository> _activityRepositoryMoq;
        private Mock<IDoctorValidator> _validatorMoq;
        private Mock<IPersistenceContext> _contextMoq;
        private DoctorAppService _service;
        private Doctor _doctor;

        [TestInitialize]
        public async Task Setup()
        {
            _repositoryMoq = new Mock<IDoctorRepository>();
            _activityRepositoryMoq = new Mock<IActivityRepository>();
            _validatorMoq = new Mock<IDoctorValidator>();
            _contextMoq = new Mock<IPersistenceContext>();

            _service = new DoctorAppService(_repositoryMoq.Object, _activityRepositoryMoq.Object, _contextMoq.Object);

            var activity = new Activity("Atividade Teste", TypeActivity.Surgery, DateTime.Now, DateTime.Now.AddDays(1), TimeSpan.FromHours(8),
            TimeSpan.FromHours(12), new List<Doctor>(), "primary");
            var activities = new List<Activity> { activity };

            _doctor = new Doctor("12345-RS", "Rafael", activities);
        }

        [TestMethod]
        public async Task Shoud_Add_a_Doctor_when_valid()
        {
            var result = await _service.AddAsync(_doctor);

            result.Should().BeSuccess();
            _repositoryMoq.Verify(x => x.AddAsync(_doctor), Times.Once());
        }

        [TestMethod]
        public async Task Should_not_Add_a_Doctor_when_invalid()
        {
            _doctor.Name = "";

            _validatorMoq.Setup(x => x.Validate(It.IsAny<Doctor>())).Returns(() =>
            {
                var result = new ValidationResult();
                result.Errors.Add(new ValidationFailure("error", "error"));
                return result;
            });

            var result = await _service.AddAsync(_doctor);

            result.Should().BeFailure();
            _repositoryMoq.Verify(x => x.AddAsync(_doctor), Times.Never());
        }

        [TestMethod]
        public async Task Shoud_Update_a_Doctor_when_valid()
        {

            var result = await _service.UpdateAsync(_doctor);

            result.Should().BeSuccess();
            _repositoryMoq.Verify(x => x.Update(_doctor), Times.Once());
        }

        [TestMethod]
        public async Task Should_not_Update_a_Doctor_when_invalid()
        {
            _doctor.Name = "";

            _validatorMoq.Setup(x => x.Validate(It.IsAny<Doctor>())).Returns(() =>
            {
                var result = new ValidationResult();
                result.Errors.Add(new ValidationFailure("error", "error"));
                return result;
            });

            var result = await _service.UpdateAsync(_doctor);

            result.Should().BeFailure();
            _repositoryMoq.Verify(x => x.Update(_doctor), Times.Never());
        }

        [TestMethod]
        public async Task Should_Remove_a_Doctor()
        {
            _repositoryMoq.Setup(x => x.GetByIdAsync(_doctor.Id))
                .ReturnsAsync(_doctor);

            var result = await _service.RemoveAsync(_doctor.Id);

            result.Should().BeSuccess();

            _repositoryMoq.Verify(x => x.Remove(_doctor), Times.Once());
        }
    }
}
