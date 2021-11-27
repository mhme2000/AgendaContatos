using AgendaContatos.Data.Mappings;
using AgendaContatos.Model;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Data
{
    public class AgendaContatoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {   //ALTERAR PARA MÁQUINA DE VOCÊS DATA SOURCE e senha//
            options.UseSqlServer(connectionString: "Data Source=HELLDER-01;Initial Catalog=AgendaContatos;User ID=sa;Password=123456");
        }
        public DbSet<AgendaContatoModel> AgendaContato { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendaContatoMapping());
        }
    }

}
