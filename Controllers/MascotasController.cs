using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdopcionMascotas.Data;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Controllers
{
    public class MascotasController : Controller
    {
        private readonly ILogger<MascotasController> _logger;
        private readonly ApplicationDbContext _context;

        public MascotasController(ILogger<MascotasController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create
        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create([Bind("Nombre,Edad,Tipo,EstadoAdopcion")] Mascota mascota)
{
    if (!ModelState.IsValid)
    {
        foreach (var error in ModelState)
        {
            if (error.Value.Errors.Count > 0)
            {
                Console.WriteLine($"Error en el campo {error.Key}: {error.Value.Errors[0].ErrorMessage}");
            }
        }
        return View(mascota);
    }

    _context.Mascotas.Add(mascota);
    _context.SaveChanges();
    TempData["SuccessMessage"] = "🐾 ¡Mascota registrada exitosamente!";
    return RedirectToAction(nameof(Index));
}

        // GET: Mascotas
        public IActionResult Index()
        {
            var mascotas = _context.Mascotas.ToList();
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(mascotas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
