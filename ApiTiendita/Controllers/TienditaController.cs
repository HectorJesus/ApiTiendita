using ApiTiendita.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendita.Controllers
{
    [ApiController]
    [Route("producto")]

    public class TienditaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public TienditaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await dbContext.Productos.Include(x => x.Proovedor).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Producto producto)
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
