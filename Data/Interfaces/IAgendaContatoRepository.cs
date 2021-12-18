using AgendaContatos.Model;

namespace AgendaContatos.Data.Interfaces
{
    public interface IAgendaContatoRepository
    {
        void Add(AgendaContatoModel agendaContato);
        AgendaContatoModel? GetById(int agendaContatoId);
        IEnumerable<AgendaContatoModel>? GetAll();
        void Delete(AgendaContatoModel agendaContato);
        void Update(AgendaContatoModel agendaContato);
    }
}
