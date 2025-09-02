using Microsoft.AspNetCore.Mvc;
using MyLeasing.Common.Entities;
using MyLeasing.Web.Repositories;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository _repo;

        public OwnersController(IOwnerRepository repo)
        {
            _repo = repo;
        }

        // GET: Owners
        public async Task<IActionResult> Index()
        {
            var owners = await _repo.GetAllAsync();
            return View(owners);
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var owner = await _repo.GetByIdAsync(id.Value);
            if (owner == null) return NotFound();

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create() => View();

        // POST: Owners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Document,FirstName,LastName,FixedPhone,CellPhone,Address")] Owner owner)
        {
            if (!ModelState.IsValid) return View(owner);

            await _repo.AddAsync(owner);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var owner = await _repo.GetByIdAsync(id.Value);
            if (owner == null) return NotFound();

            return View(owner);
        }

        // POST: Owners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Document,FirstName,LastName,FixedPhone,CellPhone,Address")] Owner owner)
        {
            if (id != owner.Id) return BadRequest();
            if (!ModelState.IsValid) return View(owner);

            await _repo.UpdateAsync(owner);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var owner = await _repo.GetByIdAsync(id.Value);
            if (owner == null) return NotFound();

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _repo.GetByIdAsync(id);
            if (owner != null)
            {
                await _repo.DeleteAsync(owner);
                await _repo.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
