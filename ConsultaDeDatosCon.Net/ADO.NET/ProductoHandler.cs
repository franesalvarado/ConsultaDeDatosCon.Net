using System.Data.SqlClient;

namespace ConsultaDeDatosCon
{
    public class ProductoHandler : DbHandler
    {
        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);

                                productos.Add(producto);

                            }
                        }
                    }
                }
            }
            return productos;
        }
        public void AbrirYCerrarConexion()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("" +
                    "SELECT * FROM Producto Where Id = 1", sqlConnection))
                {
                    sqlConnection.Open();
                    /*
                        int idProducto = 3;
                   
                        SqlParameter parametro = new SqlParameter();

                        parametro.ParameterName = "idProducto";
                        parametro.SqlDbType = System.Data.SqlDbType.Int;
                        parametro.Value = idProducto;

                        sqlCommand.Parameters.Add(parametro);
                    */
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string dato = dataReader.GetString(1);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

        }
    }
}