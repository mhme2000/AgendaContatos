using AgendaContatos.Data.Interfaces;
using AgendaContatos.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaContatoController : ControllerBase
    {
        private readonly IAgendaContatoRepository _agendaContatoRepository;
        private readonly IMapper _mapper;
        public AgendaContatoController(IAgendaContatoRepository agendaContatoRepository, IMapper mapper)
        {
            _agendaContatoRepository = agendaContatoRepository;
            _mapper = mapper;
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
            var result = _mapper.Map<IEnumerable<AgendaContatoDTO>>(model);
            
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
        public IActionResult Delete([FromQuery] int agendaContatoId)
        {
            var agendaContato = _agendaContatoRepository.GetById(agendaContatoId);
            if (agendaContato == null)
                return NotFound("Contato não encontrado.");
            _agendaContatoRepository.Delete(agendaContato);
            return Ok();

        }
    }
}