using eAgendaMedica.Domain.AuthModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.Orm.AuthModule
{
    public class AuthMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            Guid userId = Guid.Parse("E7944276-5214-46C7-2755-08DBEDE3DB7D");

            var admin = new User
            {
                Id = userId,
                Name = "Teste",
                UserName = "teste@gmail.com",
                NormalizedUserName = "TESTE@GMAIL.COM",
                Email = "teste@gmail.com",
                NormalizedEmail = "TESTE@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEEpbfL1sGZGAQmfY11et9nzZ5tdMmLv5uVMiv4xXugJLxfksPyB7aJgai6Yym57vFQ==",
                SecurityStamp = "NQY5DMARMJNDQ7CUQJP3U4O7SYXLNANC",
                ConcurrencyStamp = "6f07bdcf-9ff3-43da-9f8b-5e27808f81ab",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };

            builder.HasData(admin);
        }
    }
}
