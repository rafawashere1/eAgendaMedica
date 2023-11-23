using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;

namespace eAgendaMedica.Tests.Domain.DoctorModule
{
    [TestClass]
    public class DoctorTest
    {
        private DoctorValidator _validator;
        private Doctor _doctor;

        [TestInitialize]
        public void Setup()
        {
            _validator = new DoctorValidator();

            var activity = new Activity("Atividade Teste", TypeActivity.Surgery, DateTime.Now, DateTime.Now.AddDays(1), TimeSpan.FromHours(8),
            TimeSpan.FromHours(12), new List<Doctor>(), "primary");
            var activities = new List<Activity> { activity };

            _doctor = new Doctor("12345-RS", "Rafael", DateTime.Now, activities);
        }

        [TestMethod]
        public void Show_accept_valid_Doctor()
        {
            //action
            ValidationResult result = _validator.Validate(_doctor);

            //assert
            result.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Should_not_accept_name_null()
        {
            //arrange
            _doctor.Name = null;

            //action
            ValidationResult result = _validator.Validate(_doctor);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_name_empty()
        {
            //arrange
            _doctor.Name = "";

            //action
            ValidationResult result = _validator.Validate(_doctor);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_with_special_character()
        {
            //arrange
            _doctor.Name = "!@#$";

            //action
            ValidationResult result = _validator.Validate(_doctor);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_name_with_less_than_3_character()
        {
            //arrange
            _doctor.Name = "12";

            //action
            ValidationResult result = _validator.Validate(_doctor);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_crm_bad_formatted()
        {
            //arrange
            _doctor.CRM = "xxxxx-xx";

            //action
            ValidationResult result = _validator.Validate(_doctor);

            //assert
            result.IsValid.Should().BeFalse();
        }
    }
}
