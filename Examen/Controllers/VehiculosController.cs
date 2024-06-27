using Examen.datos;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Examen.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Crear()
        {
            
           var marcas= _context.Marca.ToList();
            var vm = new Exa_men
            {
                MarcaList = marcas,
            };
            return View(vm);    
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ObtenerModelos(int marcaId)
        {
            var modelos = _context.Modelos.Where(m => m.MarcaId == marcaId).ToList();
            return Json(modelos);
        }
        [HttpGet]
        public JsonResult ObtenerMarcas()
        {
            var result = _context.Marca.ToList();
            return Json(result);
        }
    }
}
