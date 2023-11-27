using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.ActivityModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using eAgendaMedica.Tests.Shared;
using FizzWare.NBuilder;

namespace eAgendaMedica.Tests.Infra.ActivityModule
{
    [TestClass]
    public class ActivityRepositoryTest
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
        public async Task Should_add_an_Activity()
        {
            Activity activity = Builder<Activity>.CreateNew().With(x => x.UserId = _userId).Persist();

            await _dbContext.SaveChangesAsync();

            var activity2 = await _activityRepository.GetByIdAsync(activity.Id);

            activity2.Should().Be(activity);
        }

        [TestMethod]
        public async Task Should_update_an_Activity()
        {
            Activity activity = Builder<Activity>.CreateNew().With(x => x.UserId = _userId).Persist();
            await _dbContext.SaveChangesAsync();

            var activity2 = await _activityRepository.GetByIdAsync(activity.Id);
            activity2.Theme = "warn";

            _activityRepository.Update(activity2);
            await _dbContext.SaveChangesAsync();

            var selectedActivity = await _activityRepository.GetByIdAsync(activity.Id);
            _activityRepository.GetAll().Should().HaveCount(1);
            selectedActivity.Should().Be(activity2);
        }

        [TestMethod]
        public async Task Should_remove_an_Activity()
        {
            Activity activity = Builder<Activity>.CreateNew().With(x => x.UserId = _userId).Persist();
            await _dbContext.SaveChangesAsync();
            var selectedActivity = await _activityRepository.GetByIdAsync(activity.Id);

            _activityRepository.Remove(selectedActivity);
            _dbContext.SaveChangesAsync();

            _activityRepository.GetAll().Should().HaveCount(0);
        }

        [TestMethod]
        public async Task Should_get_an_Activity_by_Id()
        {
            Activity activity = Builder<Activity>.CreateNew().With(x => x.UserId = _userId).Persist();
            _dbContext.SaveChangesAsync();

            var selectedActivity = await _activityRepository.GetByIdAsync(activity.Id);

            selectedActivity.Should().Be(activity);
        }

        [TestMethod]
        public async Task Should_get_all_Activities()
        {
            Activity activity1 = Builder<Activity>.CreateNew().With(x => x.UserId = _userId).Persist();
            Activity activity2 = Builder<Activity>.CreateNew().With(x => x.UserId = _userId).Persist();
            _dbContext.SaveChangesAsync();

            var activities = await _activityRepository.GetAllAsync();

            activities[0].Should().Be(activity1);
            activities[1].Should().Be(activity2);
            activities.Should().HaveCount(2);
        }
    }
}
