using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.Model
{
    public class AgendaContatoDTO 
    {
        public int Id { get; set; }
        public string NomeContato { get; set; }
        public string NumeroContato { get; set; }
        public Base64FormattingOptions FotoContato { get; set; }
        public string EnderecoContato { get; set; }
    }
}
