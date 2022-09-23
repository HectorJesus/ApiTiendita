namespace ApiTiendita.Entidades
{
    public class Producto
    {

        public int Id { get; set; } 

        public string NameP { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int ProovedorId { get; set; }

        public Proovedor Proovedor { get; set; }
    }
}
