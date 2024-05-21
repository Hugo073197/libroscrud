using CrudEFCoreNet666.Datos;
using CrudEFCoreNet666.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CrudEFCoreNet666.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _contexto;
      

        public HomeController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
    
        }



        [HttpGet]

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuari.ToListAsync());
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuari usuari)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuari.Add(usuari);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuari);
        }

        [HttpGet]
        public IActionResult Editar(int? Ii)
        {
            if (Ii == null)
            {
                return NotFound();
            }
            var usuari = _contexto.Usuari.Find(Ii);
            if (usuari == null)
            {
                return NotFound();
            }
            return View(usuari);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuari usuari)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuari.Update(usuari);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detalle(int? Ii)
        {
            if (Ii == null)
            {
                return NotFound();
            }
            var usuari = _contexto.Usuari.Find(Ii);
            if (usuari == null)
            {
                return NotFound();
            }
            return View(usuari);
        }

        [HttpGet]
        public IActionResult Borrar(int? Ii)
        {
            if (Ii == null)
            {
                return NotFound();
            }
            var usuari = _contexto.Usuari.Find(Ii);
            if (usuari == null)
            {
                return NotFound();
            }
            return View(usuari);
        }
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarUsuario(int? ii)
        {
            var usuari = await _contexto.Usuari.FindAsync(ii);
            if (usuari == null)
            {
                return View();
            }
            _contexto.Usuari.Remove(usuari);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult inicio()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuari userModel)
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}