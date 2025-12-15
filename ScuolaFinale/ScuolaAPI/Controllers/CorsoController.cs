using Microsoft.AspNetCore.Mvc;
using ScuolaAPI.Models;
using ScuolaAPI.Repositories;

namespace ScuolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorsoController : ControllerBase
    {
        private readonly IRepository<Corso> _repository;

        public CorsoController(IRepository<Corso> repository)
        {
            _repository = repository;
        }

        // GET: api/Corso
        [HttpGet]
        public ActionResult<IEnumerable<Corso>> GetAll()
        {
            var corsi = _repository.GetAll();
            return Ok(corsi);
        }

        // GET: api/Corso/5
        [HttpGet("{id}")]
        public ActionResult<Corso> GetById(int id)
        {
            var corso = _repository.GetById(id);
            if (corso == null)
                return NotFound();

            return Ok(corso);
        }

        // POST: api/Corso
        [HttpPost]
        public ActionResult<Corso> Create([FromBody] Corso corso)
        {
            if (corso == null)
                return BadRequest();

            _repository.Add(corso);
            _repository.Save();

            return CreatedAtAction(nameof(GetById), new { id = corso.Id }, corso);
        }

        // PUT: api/Corso/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Corso corso)
        {
            if (corso == null || id != corso.Id)
                return BadRequest();

            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Nome = corso.Nome;
            existing.CodiceId = corso.CodiceId;

            _repository.Update(existing);
            _repository.Save();

            return NoContent();
        }

        // DELETE: api/Corso/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var corso = _repository.GetById(id);
            if (corso == null)
                return NotFound();

            _repository.Delete(corso);
            _repository.Save();

            return NoContent();
        }
    }
}
