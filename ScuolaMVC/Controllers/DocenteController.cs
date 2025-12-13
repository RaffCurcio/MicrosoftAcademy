using Microsoft.AspNetCore.Mvc;
using ScuolaMVC.Models;
using ScuolaMVC.Repositories;

namespace ScuolaMVC.Controllers
{
    public class DocenteController : Controller
    {
        private readonly IRepository<Docente> _repository;

        public DocenteController(IRepository<Docente> repository)
        {
            _repository = repository;
        }

        // GET: /Docente/
        public IActionResult Index()
        {
            var docenti = _repository.GetAll();
            return View(docenti);
        }

        // GET: /Docente/Details/5
        public IActionResult Details(int id)
        {
            var docente = _repository.GetById(id);
            if (docente == null)
                return NotFound();

            return View(docente);
        }

        // GET: /Docente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Docente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Docente docente)
        {
            if (!ModelState.IsValid)
                return View(docente);

            _repository.Add(docente);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Docente/Edit/5
        public IActionResult Edit(int id)
        {
            var docente = _repository.GetById(id);
            if (docente == null)
                return NotFound();

            return View(docente);
        }

        // POST: /Docente/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Docente docente)
        {
            if (!ModelState.IsValid)
                return View(docente);

            var existing = _repository.GetById(docente.Id);
            if (existing == null)
                return NotFound();

            existing.Nome = docente.Nome;
            existing.Materia = docente.Materia;

            _repository.Update(existing);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Docente/Delete/5
        public IActionResult Delete(int id)
        {
            var docente = _repository.GetById(id);
            if (docente == null)
                return NotFound();

            return View(docente);
        }

        // POST: /Docente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var docente = _repository.GetById(id);
            if (docente == null)
                return NotFound();

            _repository.Delete(docente);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
