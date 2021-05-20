using Microsoft.AspNetCore.Mvc;
using my_tv_shows.Models;
using my_tv_shows.Service;
using System.Threading.Tasks;

namespace my_tv_shows.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ISerieService _service;

        public SeriesController(ISerieService service)
        {
            _service = service;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Series/Details/{id}
        [HttpGet("Series/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.GetAsync(id);

                if (response == null)
                {
                    return NotFound();
                }
                return View(response);
            }
            return NotFound();
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gener,Description")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(serie);
                return RedirectToAction(nameof(Index));
            }
            return View(serie);
        }

        // GET: Series/Edit/{id}
        [HttpGet("Series/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                var serie = await _service.GetAsync(id);
                return View(serie);
            }
            return NotFound();
        }

        // POST: Series/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gener,Description")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, serie);
                return RedirectToAction(nameof(Index));
            }
            return View(serie);
        }

        // GET: Series/Delete/{id}
        [HttpGet("Series/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var serie = await _service.GetAsync(id);
                return View(serie);
            }
            return NotFound();
        }

        // POST: Series/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
