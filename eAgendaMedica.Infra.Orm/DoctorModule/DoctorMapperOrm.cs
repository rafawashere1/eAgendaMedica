using eAgendaMedica.Domain.DoctorModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace eAgendaMedica.Infra.Orm.DoctorModule
{
    public class DoctorMapperOrm : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("TBDoctor");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.CRM)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasMany(d => d.Activities)
            .WithMany(a => a.Doctors);

            builder.HasOne(x => x.User)
            .WithMany()
            .IsRequired()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
