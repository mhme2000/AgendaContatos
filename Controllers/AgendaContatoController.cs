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

        [HttpGet("GetId/{agendaContatoId}")]
        public IActionResult Get(int agendaContatoId)
        {
            var model = _agendaContatoRepository.GetById(agendaContatoId);
            if (model == null)
                return NotFound("Contato não encontrado.");
            return Ok(model);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _agendaContatoRepository.GetAll();
            if (model == null)
                return NotFound("Nenhum contato cadastrado.");
            var result = new List<AgendaContatoDTO>() { };
            foreach (var item in model)
            {
                var temp = new AgendaContatoDTO()
                {
                    Id = item.AgendaContatoId,
                    NomeContato = item.NomeContato,

                };
                result.Add(temp);
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] AgendaContatoModel model)
        {
            var agendaContato = _agendaContatoRepository.GetById(model.AgendaContatoId);
            if (agendaContato == null)
                return NotFound("Contato não encontrado.");
            _agendaContatoRepository.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int agendaContatoId)
        {
            var agendaContato = _agendaContatoRepository.GetById(agendaContatoId);
            if (agendaContato == null)
                return NotFound("Contato não encontrado.");
            _agendaContatoRepository.Delete(agendaContato);
            return Ok();

        }
    }
}