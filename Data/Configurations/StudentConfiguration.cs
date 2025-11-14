using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder.HasKey(student => student.Id);

        builder.HasOne(student => student.StudyGroup)
               .WithMany(group => group.Students)
               .HasForeignKey(student => student.GroupId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
