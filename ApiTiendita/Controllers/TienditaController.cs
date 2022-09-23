using ApiTiendita.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendita.Controllers
{
    [ApiController]
    [Route("api/producto")]

    public class TienditaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public TienditaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        //Sobreescribimos las rutas del controlador
        [HttpGet]
        [HttpGet("Listado")] // api/producto/Listado
        [HttpGet("/Listados")] // /Listados 
        //Quitamos la programacion ascincrona
        public List<Producto> Get()
        {
            return dbContext.Producto.Include(x => x.Proovedor).ToList();
        }

        //Obtenemos el primer producto api/producto/primero
        [HttpGet("primero")]
        public Producto PrimerProducto([FromHeader] int valor, [FromQuery] string producto)
        {
            return dbContext.Producto.FirstOrDefault();
        }

        //Buscando un id por parametros
        [HttpGet("{id:int}/{param=Donitas}")]
        public ActionResult<Producto> Get(int id,string param)
        {
            var productos = dbContext.Producto.FirstOrDefault(x => x.Id == id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        //Buscando un nombre
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Producto>> Get(string nombre)
        {
            var productos = await dbContext.Producto.FirstOrDefaultAsync(x => x.NameP == nombre);
            
            if(productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            dbContext.Add(producto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Producto producto, int id)
        {
            if(producto.Id != id)
            {
                return BadRequest("El Id del producto no coinside.");
            }

            dbContext.Update(producto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
