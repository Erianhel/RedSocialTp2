using System.Data;
using System.Data.SqlClient;

namespace RedSocial
{
    class PostManager
    {
        private List<Post> misPosts;
        private string connectionDB = Properties.Resources.ConnectionString;

        public PostManager()
        {
            misPosts = new List<Post>();
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            //Cargo la cadena de conexión desde el archivo de properties
            string connectionString = connectionDB;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.POST";

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
                    Post aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Post(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3));
                        misPosts.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public bool Postear(string contenido, DateTime fecha, int idUsuario)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoPost = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[POST] ([FECHA],[CONTENIDO],[ID_USUARIO]) VALUES (@fecha,@contenido,@id_usuario);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));

                command.Parameters["@nombre"].Value = contenido;
                command.Parameters["@apellido"].Value = fecha;
                command.Parameters["@mail"].Value = idUsuario;

                Console.WriteLine(queryString + "hola");


                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[POST]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoPost = reader.GetInt32(0);
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
                Post nuevo = new Post(idNuevoPost,
                                            fecha,
                                            contenido,
                                            idUsuario);
                misPosts.Add(nuevo);
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool eliminarPost(int Id)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[POST] WHERE ID=@id";
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
                    for (int i = 0; i < misPosts.Count; i++)
                        if (misPosts[i].id == Id)
                            misPosts.RemoveAt(i);
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

        public bool modificarPost(int id, string contenido)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[POST] SET CONTENIDO=@contenido, WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {



                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));

                command.Parameters["@id"].Value = id;
                command.Parameters["@dni"].Value = contenido;

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
                    for (int i = 0; i < misPosts.Count; i++)
                        if (misPosts[i].id == id)
                        {
                            misPosts[i].contenido = contenido;

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
