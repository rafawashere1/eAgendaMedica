using eAgendaMedica.Domain.DoctorModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasOne(x => x.User)
            .WithMany()
            .IsRequired()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            Guid userId = Guid.Parse("E7944276-5214-46C7-2755-08DBEDE3DB7D");

            var doctor1 = new Doctor("04474-RS", "Rafael", null) { UserId = userId, Id = Guid.Parse("6f095f41-5503-42a2-8412-8d2bb95c0042") };

            var doctor2 = new Doctor("23456-SC", "João", null) { UserId = userId, Id = Guid.Parse("1cc3bb32-627c-4e79-9f4a-3fbff06bbbdf") };

            var doctor3 = new Doctor("82460-SC", "Rech", null) { UserId = userId, Id = Guid.Parse("6275b95e-03e9-4213-9303-f0745608f706") };

            var doctor4 = new Doctor("61458-SC", "Tiago", null) { UserId = userId, Id = Guid.Parse("c20e745a-da4c-4f8f-9f8f-7d5c74cafb6f") };

            var doctor5 = new Doctor("02457-SP", "Matheus", null) { UserId = userId, Id = Guid.Parse("ad42d17f-9f8d-4f5b-983e-6ad44906b347") };

            builder.HasData(doctor1, doctor2, doctor3, doctor4, doctor5);
        }
    }
}
