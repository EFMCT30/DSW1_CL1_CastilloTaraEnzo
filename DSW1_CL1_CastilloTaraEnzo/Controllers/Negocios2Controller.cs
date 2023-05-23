using Microsoft.AspNetCore.Mvc;
using DSW1_CL1_CastilloTaraEnzo.Models;
using DSW1_CL1_CastilloTaraEnzo.Modulos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSW1_CL1_CastilloTaraEnzo.Controllers
{
    public class Negocios2Controller : Controller
    {
        insumoDAO _insumo=new insumoDAO();
        categoriaDAO _cate=new categoriaDAO();

        //LISTADO
        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(()=>_insumo.listado()));
        }
        //CREAR
        public async Task<IActionResult> Create()
        {
            ViewBag.categorias = new SelectList(_cate.listado(), "codiCate", "nombreCate");
            ViewBag.insumos = _insumo.listado();
            return View(await Task.Run(() => new Insumo()));
        }
        [HttpPost]
        public async Task<IActionResult>Create(Insumo reg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categorias = new SelectList(_cate.listado(), "codiCate", "nombreCate",reg.codCate);
                return View(await Task.Run(()=>reg));
            }
            ViewBag.mensaje = _insumo.agregar(reg);

            ViewBag.insumos = _insumo.listado();
            ViewBag.categorias = new SelectList(_cate.listado(), "codiCate", "nombreCate",reg.codCate);
            return View(await Task.Run(() => reg));
        }
        
    }
}
