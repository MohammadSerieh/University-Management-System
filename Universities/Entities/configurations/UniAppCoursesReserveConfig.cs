using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Universities.Entities.configurations
{
    public partial class UniAppCoursesReserveConfig : IEntityTypeConfiguration<UniAppCoursesReserve>
    {
        public void Configure(EntityTypeBuilder<UniAppCoursesReserve> entity)
        {
            entity.HasKey(e => e.UniAppCoursesID);
            entity.Property(e => e.UniAppCoursesID).UseIdentityColumn(1, 1);
            entity.Property(e => e.CourseCenterID).HasMaxLength(255);
            entity.Property(e => e.CourseLocation).HasMaxLength(255);
            entity.Property(e => e.DocumentName).HasMaxLength(255);
            entity.Property(e => e.MimeType).HasMaxLength(255);
            entity.Property(e => e.Appno).HasColumnType("numeric(10,0)");

            entity.HasOne(x => x.UniversityApplicationReserve_Appno_nav)
                .WithMany(x => x.UniAppCoursesReserve_Appno_nav)
                .HasForeignKey(x => x.Appno)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.CommonZakat_MinorLookUpTable_CourseID_nav)
                .WithMany(x => x.UniAppCoursesReserve_CourseID_nav)
                .HasForeignKey(x => x.CourseID)
                .OnDelete(DeleteBehavior.Restrict);


            entity.ToTable("UniAppCoursesReserve");
            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<UniAppCoursesReserve> entity);
    }
}