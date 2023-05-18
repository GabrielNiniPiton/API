using EVENTS.API.Data;
using EVENTS.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EVENTS.API.Controllers
{
    [ApiController]
    [Route("v1/events")]
    public class EventosController : ControllerBase
    {
        private readonly EventosDbContext _context;

        public EventosController(EventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var eventos = _context.Eventos;

            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.Id == id);

            if (evento == null) return NotFound();

            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento evento)
        {
            var eventoExistente = _context.Eventos.SingleOrDefault(e => e.Id == id);

            if (eventoExistente == null) return NotFound();

            eventoExistente.Update(evento.Titulo, evento.Descricacao, evento.DataInicio, evento.DataFim);

            _context.Eventos.Update(eventoExistente);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.Id == id);

            if (evento == null) return NotFound();

            _context.Eventos.Remove(evento);
            _context.SaveChanges();

            return NoContent();
        }
    }
}