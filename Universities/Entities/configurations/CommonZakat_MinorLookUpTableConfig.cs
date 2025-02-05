using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Universities.Entities.configurations
{
    public partial class CommonZakat_MinorLookUpTableConfig : IEntityTypeConfiguration<CommonZakat_MinorLookUpTable>
    {
        public void Configure(EntityTypeBuilder<CommonZakat_MinorLookUpTable> entity)
        {
            entity.HasKey(e => e.minorid);
            entity.Property(e => e.minorid).UseIdentityColumn(1,1);

            entity.Property(e => e.descs).HasMaxLength(250).IsRequired(true);

           entity.ToTable("CommonZakat_MinorLookUpTable");
           OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CommonZakat_MinorLookUpTable> entity);
    }
}
