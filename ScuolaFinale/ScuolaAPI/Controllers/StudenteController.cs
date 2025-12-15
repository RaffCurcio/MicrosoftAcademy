using Microsoft.AspNetCore.Mvc;
using ScuolaAPI.Models;
using ScuolaAPI.Repositories;

namespace ScuolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudenteController : ControllerBase
    {
        private readonly IRepository<Studente> _repository;

        public StudenteController(IRepository<Studente> repository)
        {
            _repository = repository;
        }

        // GET: api/Studente
        [HttpGet]
        public ActionResult<IEnumerable<Studente>> GetAll()
        {
            var studenti = _repository.GetAll();
            return Ok(studenti);
        }

        // GET: api/Studente/5
        [HttpGet("{id}")]
        public ActionResult<Studente> GetById(int id)
        {
            var studente = _repository.GetById(id);
            if (studente == null)
                return NotFound();

            return Ok(studente);
        }

        // POST: api/Studente
        [HttpPost]
        public ActionResult<Studente> Create([FromBody] Studente studente)
        {
            if (studente == null)
                return BadRequest();

            _repository.Add(studente);
            _repository.Save();

            return CreatedAtAction(nameof(GetById), new { id = studente.Id }, studente);
        }

        // PUT: api/Studente/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Studente studente)
        {
            if (studente == null || id != studente.Id)
                return BadRequest();

            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Nome = studente.Nome;
            existing.Cognome = studente.Cognome;
            existing.Matricola = studente.Matricola;

            _repository.Update(existing);
            _repository.Save();

            return NoContent();
        }

        // DELETE: api/Studente/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var studente = _repository.GetById(id);
            if (studente == null)
                return NotFound();

            _repository.Delete(studente);
            _repository.Save();

            return NoContent();
        }
    }
}
