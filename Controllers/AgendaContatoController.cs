using AgendaContatos.Data.Interfaces;
using AgendaContatos.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AgendaContatoController : ControllerBase
    {
        private readonly IAgendaContatoRepository _agendaContatoRepository;
        public AgendaContatoController(IAgendaContatoRepository agendaContatoRepository)
        {
            _agendaContatoRepository = agendaContatoRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AgendaContatoModel model)
        {
            _agendaContatoRepository.Add(model);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int agendaContatoId)
        {
            var model = _agendaContatoRepository.GetById(agendaContatoId);
            return Ok(model);
        }


        [HttpPut]
        public IActionResult Update([FromBody] AgendaContatoModel model)
        {
            var agendaContato = _agendaContatoRepository.GetById(model.AgendaContatoId);
            if (agendaContato == null)
                return NotFound();
            _agendaContatoRepository.Update(model);
            return Ok();
        }
    }
}