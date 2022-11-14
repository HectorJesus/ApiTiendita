using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiTiendita.Validaciones;

namespace ApiTiendita.Entidades
{
    public class Proovedor
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(maximumLength:15, ErrorMessage = "El campo {0} solo puede tener 15 caracteres")]
        [PrimeraLetraMayusculaAttribute]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [NotMapped]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]

        //Relacionamos los proovedores con los productos
        public List<Producto> Productos { get; set; }

    }
}
