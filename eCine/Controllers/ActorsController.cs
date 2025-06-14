using eCine.Data;
using eCine.Data.Services;
using eCine.Data.Static;
using eCine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCine.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _service.GetAllAsync();
            return View(data);
        }

        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create ([Bind("ProfilePicture,FullName,Bio")]Actor actor)
        {
            ModelState.Remove("ActorsMovies");
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Info(int id)
        {
            var actor=await _service.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }


        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePicture,FullName,Bio")] Actor actor)
        {
            ModelState.Remove("ActorsMovies");
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(actor);
            }
            await _service.UpddateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
