using ApiTiendita.Services;
using ApiTiendita.Controllers;
using ApiTiendita.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiTiendita.Controllers    
{
    [ApiController]
    [Route("api/proovedor")]
    public class ProovedorController : ControllerBase
    {
    
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IService service;
        private readonly ILogger<ProovedorController> logger;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        public ProovedorController(ApplicationDbContext context,
                                   IService service,
                                   ServiceTransient serviceTransient,
                                   ServiceScoped serviceScoped,
                                   ServiceSingleton serviceSingleton,
                                   ILogger<ProovedorController> logger)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet]
        [ResponseCache(Duration = 10)]
        public async Task<ActionResult<List<Proovedor>>> GetAll()
        {
            logger.LogInformation("Obteniendo listado de proovedores");
            logger.LogWarning("No apagar el equipo");
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
            //Ejemplo para validar desde el controlador con la BD con ayuda del dbContext

            var existeProovedorMismoNombre = await dbContext.Proovedor.AnyAsync(x => x.Name == proovedor.Name);

            if (existeProovedorMismoNombre)
            {
                return BadRequest($"Ya existe un proovedor con el nombre {proovedor.Name}");
            }
           
            var Proovedor = mapper.Map<Proovedor>(proovedor);
            
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
            var exist = await dbContext.Proovedor .AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado.");
            }

            dbContext.Remove(new Proovedor { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }

    internal interface IService
    {
    }

    internal interface IMapper
    {
        object Map<T>(T proovedor);
    }
}
