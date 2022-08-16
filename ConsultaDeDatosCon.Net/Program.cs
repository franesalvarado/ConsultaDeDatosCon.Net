using ConsultaDeDatosCon;

namespace ProbarObjectos
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();
            LoginHandler loginHandler = new LoginHandler();
            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();
            UsuarioHandler usuarioHandler = new UsuarioHandler();
            VentaHandler ventaHandler = new VentaHandler();

            loginHandler.GetLogin("tcasazza", "SoyTobiasCasazza");
            productoHandler.GetProductos();
            productoVendidoHandler.GetProductosVendidos();
            usuarioHandler.GetUsuarios();
            ventaHandler.GetVenta();
        }
    }
}
