using Microsoft.AspNetCore.Mvc;
using MvcExamenValen.Models;
using MvcExamenValen.Services;

namespace MvcExamenValen.Controllers
{
    public class PersonajesController : Controller
    {
        private ServicePersonajes service;

        public PersonajesController(ServicePersonajes service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }
        public async Task<IActionResult> Details(int id)
        {
            Personaje personaje = await this.service.FindPersonajeAsync(id);
            return View(personaje);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeletePersonajeAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Personaje person)
        {
            await this.service.InsertPersonajeAsync(person);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
            Personaje person = await this.service.FindPersonajeAsync(id);
            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Personaje person)
        {
            await this.service.UpdatePersonajeAsync(person);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> PersonajesSerie()
        {
            ViewData["SERIES"] = await this.service.GetSeriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PersonajesSerie(string serie)
        {
            List<Personaje> personajes = await this.service.GetPersonajesSeriesAsync(serie);
            ViewData["SERIES"] = await this.service.GetSeriesAsync();
            return View(personajes);
        }
    }
}
