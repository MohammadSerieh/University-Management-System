using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Universities.Entities.configurations
{
    public partial class UniversityApplicationReserveConfig : IEntityTypeConfiguration<UniversityApplicationReserve>
    {
        public void Configure(EntityTypeBuilder<UniversityApplicationReserve> entity)
        {
            entity.HasKey(e => e.Appno);


            entity.Property(e => e.Appno).UseIdentityColumn(1, 1);
            entity.Property(e => e.Appno).HasColumnType("numeric(10,0)");

            entity.Property(e => e.StudentName).HasMaxLength(255);
            entity.Property(e => e.StudentNameEn).HasMaxLength(255);
            entity.Property(e => e.ApplicationID).HasMaxLength(15);
            entity.Property(e => e.UniNumber).HasMaxLength(255);
            entity.Property(e => e.SemesterRate).HasColumnType("numeric(5, 2)").HasPrecision(5,2);
            entity.Property(e => e.CommulativeRate).HasColumnType("numeric(5, 2)").HasPrecision(5, 2);
            entity.Property(e => e.HighSchoolGrade).HasColumnType("numeric(5, 2)").HasPrecision(5, 2);
            entity.Property(e => e.UniGrantID).HasMaxLength(100);
            entity.Property(e => e.UniGrantRateLimit).HasColumnType("numeric(5, 2)").HasPrecision(5, 2);
            entity.Property(e => e.UniGrantDate).HasColumnType("DateTime");
            entity.Property(e => e.HighSchoolGraduate).HasColumnType("DateTime");


 


            entity.HasOne(x=>x.CommonZakat_MinorLookUpTable_UniID_nav)
                .WithMany(x=>x.UniversityApplicationReserve_UniID_nav)
                .HasForeignKey(x=>x.UniID)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(x => x.CommonZakat_MinorLookUpTable_UniCollege_nav)
                .WithMany(x => x.UniversityApplicationReserve_UniCollege_nav)
                .HasForeignKey(x => x.UniCollege)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(x => x.CommonZakat_MinorLookUpTable_UniMajor_nav)
               .WithMany(x => x.UniversityApplicationReserve_UniMajor_nav)
               .HasForeignKey(x => x.UniMajor)
               .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(x => x.CommonZakat_MinorLookUpTable_nationalCategory_nav)
               .WithMany(x => x.UniversityApplicationReserve_nationalCategory_nav)
               .HasForeignKey(x => x.nationalityCategory)
               .OnDelete(DeleteBehavior.Restrict);


            
            entity.ToTable("UniversityApplicationReserve");
            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<UniversityApplicationReserve> entity);
    }
}
