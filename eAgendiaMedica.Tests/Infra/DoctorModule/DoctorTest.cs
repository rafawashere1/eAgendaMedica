using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;

namespace eAgendiaMedica.Tests.Infra.DoctorModule
{
    [TestClass]
    public class DoctorTest
    {
        private DoctorValidator _doctorValidator;
        private Doctor _doctor;

        [TestInitialize]
        public void Setup()
        {
            _doctorValidator = new DoctorValidator();
            _doctor = new Doctor("12345-SP", "Dr. Teste", DateTime.Now, new Activity());
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}