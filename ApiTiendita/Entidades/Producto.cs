namespace ApiTiendita.Entidades
{
    public class Producto
    {

        public int Id { get; set; }

        public string Name { get; set; }


        //Relacionamos los proovedores con los productos
        public List<Proovedor> Proovedor { get; set; }

    }
}
