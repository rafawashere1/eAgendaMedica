using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;

namespace eAgendaMedica.Tests.Domain.AcitivityModule
{
    [TestClass]
    public class ActivityTest
    {
        private ActivityValidator _validator;
        private Activity _activity;

        [TestInitialize]
        public void Setup()
        {
            _validator = new ActivityValidator();

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
        public void Show_accept_valid_Activity()
        {
            //action
            ValidationResult result = _validator.Validate(_activity);

            //assert
            result.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Should_not_accept_Title_null()
        {
            //arrange
            _activity.Title = null;

            //action
            ValidationResult result = _validator.Validate(_activity);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_Title_empty()
        {
            //arrange
            _activity.Title = "";

            //action
            ValidationResult result = _validator.Validate(_activity);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_end_Day_bigger_than_start_Day()
        {
            //arrange
            _activity.StartDay = DateTime.Now.AddDays(1);
            _activity.EndDay = DateTime.Now;

            //action
            ValidationResult result = _validator.Validate(_activity);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_end_Time_bigger_than_start_Time()
        {
            //arrange
            _activity.StartTime = TimeSpan.FromHours(12);
            _activity.EndTime = TimeSpan.FromHours(8);

            //action
            ValidationResult result = _validator.Validate(_activity);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_Doctors_null()
        {
            //arrange
            _activity.Doctors = null;

            //action
            ValidationResult result = _validator.Validate(_activity);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Should_not_accept_more_than_one_Doctor_if_Appointment()
        {
            //arrange
            var doctor1 = new Doctor();
            var doctor2 = new Doctor();
            _activity.Type = TypeActivity.Appointment;
            _activity.Doctors = new List<Doctor> { doctor1, doctor2 };

            //action
            ValidationResult result = _validator.Validate(_activity);

            //assert
            result.IsValid.Should().BeFalse();
        }
    }
}
