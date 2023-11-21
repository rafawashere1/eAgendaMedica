using System.ComponentModel;

namespace eAgendaMedica.Domain.ActivityModule
{
    public enum TypeActivity
    {
        [Description("Cirurgia")]
        Surgery,
        [Description("Consulta")]
        Appointment
    }
}
