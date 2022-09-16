namespace ApiTiendita.Entidades
{
    public class Proovedor
    {

        public int Id { get; set; }

        public string Name { get; set; }  

        public string Telefono { get; set; }  

        public Producto Producto { get; set; } 
    }
}
