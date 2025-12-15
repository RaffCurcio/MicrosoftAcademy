using Microsoft.AspNetCore.Mvc;
using ScuolaMVC.Models;
using ScuolaMVC.Repositories;

namespace ScuolaMVC.Controllers
{
    public class CorsoController : Controller
    {
        private readonly IRepository<Corso> _repository;

        public CorsoController(IRepository<Corso> repository)
        {
            _repository = repository;
        }

        // GET: /Corso/
        public IActionResult Index()
        {
            var corsi = _repository.GetAll();
            return View(corsi);
        }

        // GET: /Corso/Details/5
        public IActionResult Details(int id)
        {
            var corso = _repository.GetById(id);
            if (corso == null)
                return NotFound();

            return View(corso);
        }

        // GET: /Corso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Corso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Corso corso)
        {
            if (!ModelState.IsValid)
                return View(corso);

            _repository.Add(corso);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Corso/Edit/5
        public IActionResult Edit(int id)
        {
            var corso = _repository.GetById(id);
            if (corso == null)
                return NotFound();

            return View(corso);
        }

        // POST: /Corso/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Corso corso)
        {
            if (!ModelState.IsValid)
                return View(corso);

            var existing = _repository.GetById(corso.Id);
            if (existing == null)
                return NotFound();

            existing.Nome = corso.Nome;
            existing.CodiceId = corso.CodiceId;

            _repository.Update(existing);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Corso/Delete/5
        public IActionResult Delete(int id)
        {
            var corso = _repository.GetById(id);
            if (corso == null)
                return NotFound();

            return View(corso);
        }

        // POST: /Corso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var corso = _repository.GetById(id);
            if (corso == null)
                return NotFound();

            _repository.Delete(corso);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
