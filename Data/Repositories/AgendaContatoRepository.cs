using AgendaContatos.Data.Interfaces;
using AgendaContatos.Model;

namespace AgendaContatos.Data.Repositories
{
    public class AgendaContatoRepository : IAgendaContatoRepository
    {
        private readonly AgendaContatoContext _context;
        public AgendaContatoRepository(AgendaContatoContext context)
        {
            _context = context;
        }
        public void Add(AgendaContatoModel agendaContato)
        {
            _context.Add(agendaContato);
            _context.SaveChanges();
        }
    }
}
