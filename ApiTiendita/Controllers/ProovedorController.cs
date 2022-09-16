using ApiTiendita.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendita.Controllers    
{
    [ApiController]
    [Route("api/Proovedor")]
    public class ProovedorController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        
        public ProovedorController (ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proovedor>>> GetAll()
        {
            return await dbContext.Proovedor.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Proovedor>> GetById(int id)
        {
            return await dbContext.Proovedor.FirstOrDefaultAsync(x => x.Id == id);
        }
        //Servicios para crear y actualizar un proovedor
        [HttpPost]
        public async Task<ActionResult> Post(Proovedor proovedor)
        {
            var existeProovedor = await dbContext.Proovedor.AnyAsync(x => x.Id == proovedor.Id);
            if (!existeProovedor)
            {
                return BadRequest($"No exxiste el proovedor con el id: {proovedor.Id}");
            }

            dbContext.Add(proovedor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Proovedor proovedor, int id)
        {
            var exist = await dbContext.Proovedor.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El proovedor que ingreso no existe");
            }

            if(proovedor.Id != id)
            {
                return BadRequest("El id ingresado no coinside con el establecido");
            }

            dbContext.Update(proovedor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //Servicio para eliminar proovedores
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Proovedor.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado.");
            }

            dbContext.Remove(new Proovedor { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
