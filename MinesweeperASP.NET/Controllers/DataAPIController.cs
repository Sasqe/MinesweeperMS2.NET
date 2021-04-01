
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinesweeperASP.NET.Models;
using MinesweeperASP.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Description;

namespace ASPCoreFirstApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataAPIController : ControllerBase
    {
        DataDAO repository = new DataDAO();
        public DataAPIController()
        {
            repository = new DataDAO();
        }
        [HttpGet]
        [ResponseType(typeof(List<gridDTO>))]
        public IEnumerable<gridDTO> Index()
        {
            
            List<gridDTO> list = repository.retrieveData();
            //translate structure into DTO
            //= foreach ProductModel p in list,
            //push to list new product DTO w data
            IEnumerable<gridDTO> dtolist = from d in list select new gridDTO(d.ID, d.JSONString, d.date, d.userID);
            return dtolist;
        }

        [HttpGet("getone/{Id}")]
        [ProducesDefaultResponseType(typeof(gridDTO))]
        public ActionResult<gridDTO> getOne(int Id)
        {
            gridDTO grid = repository.load(Id);
            //create new DTO using product data
            gridDTO griddto = new gridDTO(grid.ID, grid.JSONString, grid.date, grid.userID);
            //return DTO instead of product.
            return griddto;
        }
        [HttpGet("delete/{Id}")]
        [ResponseType(typeof(List<gridDTO>))]
        public IEnumerable<gridDTO> delete(int Id)
        {
            repository.delete(Id);
            //create new DTO using product data
            List<gridDTO> list = repository.retrieveData();
            //translate structure into DTO
            //= foreach ProductModel p in list,
            //push to list new product DTO w data
            IEnumerable<gridDTO> dtolist = from d in list select new gridDTO(d.ID, d.JSONString, d.date, d.userID);
            return dtolist;
        }

    }
}

/*public IActionResult showOneJSON(int Id)
{
    return Json(repository.getProductByID(Id));

}

public IActionResult SearchForm()
{
    return View();

}
public IActionResult Message()
{
    return View();
}
public IActionResult Welcome()
{
    ViewBag.name = "Chris";
    ViewBag.secretNumber = 13;
    return View();
}
public IActionResult showEditForm(int Id)
{
    return View(repository.getProductByID(Id));

}

public IActionResult processDelete(ProductModel product)
{
    repository.Delete(product);
    return View("Index", repository.getAllProducts());
}

}
}
*/
