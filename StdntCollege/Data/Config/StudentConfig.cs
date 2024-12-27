using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace StdntCollege.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(("Student"));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(n =>n.StudentName).IsRequired().HasMaxLength(250);
            builder.Property(n =>n.StudentAddress).IsRequired(false).HasMaxLength(500);
            builder.Property(n =>n.StudentEmail).IsRequired().HasMaxLength(250);

            builder.HasData(new List<Student>()
            {
                new Student
                {
                    Id = 1,
                    StudentName = "IreOlu",
                    StudentAddress = "Festac1",
                    StudentEmail = "ireolu@gmail.com",
                    DOB = new DateTime(2024, 12, 07)
                },
                {
                new Student {
                    Id = 2,
                    StudentName = "IreOba",
                    StudentAddress = "Festac2",
                    StudentEmail = "ireoba@gmail.com",
                    DOB = new DateTime(2025, 12, 07)
                }
                }

            });
        }
    }
}
