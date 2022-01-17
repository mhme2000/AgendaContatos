using AgendaContatos.Data.Interfaces;
using AgendaContatos.Model;
using Microsoft.EntityFrameworkCore;

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
            _context.AgendaContato?.Add(agendaContato);
            _context.SaveChanges();
        }

        public AgendaContatoModel? GetById(int agendaContatoId)
        {
            return _context.AgendaContato?.AsNoTracking().FirstOrDefault(t => t.AgendaContatoId == agendaContatoId);
        }

        public IEnumerable<AgendaContatoModel>? GetAll()
        {
            return _context.AgendaContato?.Where(t => t.AgendaContatoId > 0);
        }

        public void Update(AgendaContatoModel agendaContato)
        {
            _context.AgendaContato?.Update(agendaContato);
            _context.SaveChanges();
        }

        public void Delete(AgendaContatoModel agendaContato)
        {
            _context.AgendaContato?.Remove(agendaContato);
            _context.SaveChanges();
        }
    }
}
