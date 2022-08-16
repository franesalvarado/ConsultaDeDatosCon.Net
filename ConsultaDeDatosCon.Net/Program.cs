using ConsultaDeDatosCon;

namespace ProbarObjectos
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.GetProductos();
        }
    }
}
