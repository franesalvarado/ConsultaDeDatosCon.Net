using System.Data.SqlClient;

namespace ConsultaDeDatosCon
{
    public class LoginHandler : DbHandler
    {
        public Boolean GetLogin(string nombreUsuario, string contraseña)
        {
            Boolean ifLogin = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT NombreUsuario " +
                    "FROM Usuario " +
                    "WHERE NombreUsuario=@NombreUsuario AND Contraseña=@Contraseña", sqlConnection))
                {
                    sqlConnection.Open();

                    SqlParameter nombreUsuarioParametro = new SqlParameter();
                    SqlParameter contraseñaParametro = new SqlParameter();

                    nombreUsuarioParametro.ParameterName = "NombreUsuario";
                    nombreUsuarioParametro.SqlDbType = System.Data.SqlDbType.VarChar;
                    nombreUsuarioParametro.Value = nombreUsuario;

                    sqlCommand.Parameters.Add(nombreUsuarioParametro);

                    contraseñaParametro.ParameterName = "Contraseña";
                    contraseñaParametro.SqlDbType = System.Data.SqlDbType.VarChar;
                    contraseñaParametro.Value = contraseña;

                    sqlCommand.Parameters.Add(contraseñaParametro);


                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            ifLogin = true;
                        } else
                        {
                            ifLogin = false;
                        }
                    }
                }
            }
            return ifLogin;
        }
    }
}