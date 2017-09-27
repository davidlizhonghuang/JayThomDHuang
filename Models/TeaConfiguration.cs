using System.Data.Entity.ModelConfiguration;

namespace WebJayThomDhuang.Models
{
    public class TeaConfiguration: EntityTypeConfiguration<Tea>
    {
        public TeaConfiguration()
        {
            ToTable("Teas");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Price).IsRequired().HasPrecision(8, 2);
            Property(g => g.CategoryID).IsRequired();
        }
    }
}