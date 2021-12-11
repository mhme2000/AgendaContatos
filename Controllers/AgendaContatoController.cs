using AgendaContatos.Data.Interfaces;
using AgendaContatos.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers;

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

    // [HttpGet]
    // public IActionResult Get(int agendaContatoId)
    // {
    //     // _agendaContatoRepository.
    // }
}
