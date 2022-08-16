using System.Data.SqlClient;

namespace ConsultaDeDatosCon
{
    public class VentaHandler : DbHandler
    {
        public List<Venta> GetVenta()
        {
            List<Venta> Ventas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta Venta = new Venta();

                                Venta.Id = Convert.ToInt32(dataReader["Id"]);
                                Venta.Comentarios = dataReader["Comentarios"].ToString();

                                Ventas.Add(Venta);

                            }
                        }
                    }
                }
            }
            return Ventas;
        }
    }
}