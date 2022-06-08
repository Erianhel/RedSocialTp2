using System.Data;
using System.Data.SqlClient;

namespace RedSocial
{
    internal class ReaccionManager
    {
        private List<Reaccion> misReacciones;
        private string connectionDB = Properties.Resources.ConnectionString;

        public ReaccionManager()
        {
            misReacciones = new List<Reaccion>();
            inicializarAtributos();
        }

        public List<Reaccion> inicializarAtributos()
        {
            //Cargo la cadena de conexión desde el archivo de properties
            string connectionString = connectionDB;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.REACCION";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Reaccion aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Reaccion(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                        misReacciones.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misReacciones;
        }

        public bool Reaccionar(int tipo, int idPost, int idUsuario)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevaReaccion = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[REACCION] ([TIPO],[ID_POST],[ID_USUARIO]) VALUES (@tipo,@id_post,@id_usuario);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@tipo", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_post", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));

                command.Parameters["@tipo"].Value = tipo;
                command.Parameters["@id_post"].Value = idPost;
                command.Parameters["@id_usuario"].Value = idUsuario;

                Console.WriteLine(queryString + "hola");


                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[REACCION]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaReaccion = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            if (resultadoQuery == 1)
            {

                //Ahora sí lo agrego en la lista
                Reaccion nuevo = new Reaccion(idNuevaReaccion,
                                            tipo,
                                            idPost,
                                            idUsuario);
                misReacciones.Add(nuevo);
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool eliminarReaccion(int Id)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[REACCION] WHERE ID=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = Id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            if (resultadoQuery == 1)
            {
                try
                {
                    //Ahora sí lo elimino en la lista
                    for (int i = 0; i < misReacciones.Count; i++)
                        if (misReacciones[i].id == Id)
                            misReacciones.RemoveAt(i);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool modificarReaccion(int id, int tipo)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[REACCION] SET TIPO=@tipo, WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {



                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@tipo", SqlDbType.Int));

                command.Parameters["@id"].Value = id;
                command.Parameters["@tipo"].Value = tipo;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            if (resultadoQuery == 1)
            {
                try
                {
                    //Ahora sí lo MODIFICO en la lista
                    for (int i = 0; i < misReacciones.Count; i++)
                        if (misReacciones[i].id == id)
                        {
                            misReacciones[i].tipo = tipo;

                        }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }
    }
}
