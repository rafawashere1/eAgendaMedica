using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.ActivityModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using eAgendaMedica.Tests.Shared;
using FizzWare.NBuilder;

namespace eAgendaMedica.Tests.Infra.DoctorModule
{
    [TestClass]
    public class DoctorRepositoryTest
    {
        private ActivityRepositoryOrm _activityRepository;
        private DoctorRepositoryOrm _doctorRepository;

        private eAgendaMedicaDbContext _dbContext;

        private Guid _userId;

        [TestInitialize]
        public async Task Setup()
        {
            BaseTest.DeleteData();

            _userId = BaseTest.RegisterUser();

            _dbContext = new eAgendaMedicaDesignFactory().CreateDbContext(null);

            _activityRepository = new ActivityRepositoryOrm(_dbContext);
            _doctorRepository = new DoctorRepositoryOrm(_dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Activity>(_activityRepository.Add);
            BuilderSetup.SetCreatePersistenceMethod<Doctor>(_doctorRepository.Add);
        }

        [TestMethod]
        public async Task Should_add_a_Doctor()
        {
            Doctor doctor = Builder<Doctor>.CreateNew().With(x => x.UserId = _userId).Persist();

            await _dbContext.SaveChangesAsync();

            var doctor2 = await _doctorRepository.GetByIdAsync(doctor.Id);

            doctor2.Should().Be(doctor);
        }

        [TestMethod]
        public async Task Should_update_a_Doctor()
        {
            Doctor doctor = Builder<Doctor>.CreateNew().With(x => x.UserId = _userId).Persist();
            await _dbContext.SaveChangesAsync();

            var doctor2 = await _doctorRepository.GetByIdAsync(doctor.Id);
            doctor2.CRM = "99999-XX";

            _doctorRepository.Update(doctor2);
            await _dbContext.SaveChangesAsync();

            var selectedDoctor = await _doctorRepository.GetByIdAsync(doctor.Id);
            _doctorRepository.GetAll().Should().HaveCount(1);
            selectedDoctor.Should().Be(doctor2);
        }

        [TestMethod]
        public async Task Should_remove_a_Doctor()
        {
            Doctor doctor = Builder<Doctor>.CreateNew().With(x => x.UserId = _userId).Persist();
            await _dbContext.SaveChangesAsync();
            var selectedDoctor = await _doctorRepository.GetByIdAsync(doctor.Id);

            _doctorRepository.Remove(selectedDoctor);
            _dbContext.SaveChangesAsync();

            _doctorRepository.GetAll().Should().HaveCount(0);
        }

        [TestMethod]
        public async Task Should_get_a_Doctor_by_Id()
        {
            Doctor doctor = Builder<Doctor>.CreateNew().With(x => x.UserId = _userId).Persist();
            _dbContext.SaveChangesAsync();

            var selectedDoctor = await _doctorRepository.GetByIdAsync(doctor.Id);

            selectedDoctor.Should().Be(doctor);
        }

        [TestMethod]
        public async Task Should_get_all_Doctors()
        {
            Doctor doctor1 = Builder<Doctor>.CreateNew().With(x => x.UserId = _userId).Persist();
            Doctor doctor2 = Builder<Doctor>.CreateNew().With(x => x.UserId = _userId).Persist();
            _dbContext.SaveChangesAsync();

            var doctors = await _doctorRepository.GetAllAsync();

            doctors[0].Should().Be(doctor1);
            doctors[1].Should().Be(doctor2);
            doctors.Should().HaveCount(2);
        }
    }
}
