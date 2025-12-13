using Microsoft.AspNetCore.Mvc;
using ScuolaMVC.Models;
using ScuolaMVC.Repositories;

namespace ScuolaMVC.Controllers
{
    public class StudenteController : Controller
    {
        private readonly IRepository<Studente> _repository;

        public StudenteController(IRepository<Studente> repository)
        {
            _repository = repository;
        }

        // GET: /Studente/
        public IActionResult Index()
        {
            var studenti = _repository.GetAll();
            return View(studenti);
        }

        // GET: /Studente/Details/5
        public IActionResult Details(int id)
        {
            var studente = _repository.GetById(id);
            if (studente == null)
                return NotFound();

            return View(studente);
        }

        // GET: /Studente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Studente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Studente studente)
        {
            if (!ModelState.IsValid)
                return View(studente);

            _repository.Add(studente);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Studente/Edit/5
        public IActionResult Edit(int id)
        {
            var studente = _repository.GetById(id);
            if (studente == null)
                return NotFound();

            return View(studente);
        }

        // POST: /Studente/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Studente studente)
        {
            if (!ModelState.IsValid)
                return View(studente);

            var existing = _repository.GetById(studente.Id);
            if (existing == null)
                return NotFound();

            existing.Nome = studente.Nome;
            existing.Cognome = studente.Cognome;
            existing.Matricola = studente.Matricola;

            _repository.Update(existing);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Studente/Delete/5
        public IActionResult Delete(int id)
        {
            var studente = _repository.GetById(id);
            if (studente == null)
                return NotFound();

            return View(studente);
        }

        // POST: /Studente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var studente = _repository.GetById(id);
            if (studente == null)
                return NotFound();

            _repository.Delete(studente);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
