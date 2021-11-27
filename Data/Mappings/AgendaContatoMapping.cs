using AgendaContatos.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaContatos.Data.Mappings
{
    public class AgendaContatoMapping : IEntityTypeConfiguration<AgendaContatoModel>
    {
        public void Configure(EntityTypeBuilder<AgendaContatoModel> builder)
        {
            builder.ToTable("AgendaContato");

            builder.HasKey(c => c.AgendaContatoId);
            builder.Property(c => c.NomeContato).IsRequired().HasMaxLength(50);
            builder.Property(c => c.NumeroContato).IsRequired().HasMaxLength(20);
            builder.Property(c => c.FotoContato);
            builder.Property(c => c.EnderecoContato).HasMaxLength(50);
        }
    }
}
