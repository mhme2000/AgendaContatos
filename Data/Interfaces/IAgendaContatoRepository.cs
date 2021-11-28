using AgendaContatos.Model;

namespace AgendaContatos.Data.Interfaces
{
    public interface IAgendaContatoRepository
    {
        void Add(AgendaContatoModel agendaContato);
    }
}
