using Microsoft.AspNetCore.Mvc;
using ScuolaAPI.Models;
using ScuolaAPI.Repositories;

namespace ScuolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly IRepository<Docente> _repository;

        public DocenteController(IRepository<Docente> repository)
        {
            _repository = repository;
        }

        // GET: api/Docente
        [HttpGet]
        public ActionResult<IEnumerable<Docente>> GetAll()
        {
            var docenti = _repository.GetAll();
            return Ok(docenti);
        }

        // GET: api/Docente/5
        [HttpGet("{id}")]
        public ActionResult<Docente> GetById(int id)
        {
            var docente = _repository.GetById(id);
            if (docente == null)
                return NotFound();

            return Ok(docente);
        }

        // POST: api/Docente
        [HttpPost]
        public ActionResult<Docente> Create([FromBody] Docente docente)
        {
            if (docente == null)
                return BadRequest();

            _repository.Add(docente);
            _repository.Save();

            return CreatedAtAction(nameof(GetById), new { id = docente.Id }, docente);
        }

        // PUT: api/Docente/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Docente docente)
        {
            if (docente == null || id != docente.Id)
                return BadRequest();

            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Nome = docente.Nome;
            existing.Materia = docente.Materia;

            _repository.Update(existing);
            _repository.Save();

            return NoContent();
        }

        // DELETE: api/Docente/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var docente = _repository.GetById(id);
            if (docente == null)
                return NotFound();

            _repository.Delete(docente);
            _repository.Save();

            return NoContent();
        }
    }
}
