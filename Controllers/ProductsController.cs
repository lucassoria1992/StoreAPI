
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Datos;
using StoreAPI.Modelo;

namespace StoreAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ModelProducts>>> Get()
        {
            var funcion = new DatosProductos();
            var lista = await funcion.VerProducto();
            return lista;
        }
        [HttpPost]
        public async Task Post ([FromBody] ModelProducts parametros)
        {
            var funcion = new DatosProductos();
            await funcion.insertarProducto(parametros);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody] ModelProducts parametros)
        {
            var funcion = new DatosProductos();
            parametros.id = id;
            await funcion.EditarProducto(parametros);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var funcion = new DatosProductos();
            var parametros = new ModelProducts();
            parametros.id = id;
            await funcion.eliminarProducto(parametros);
            return NoContent();
        }
    }
}
 