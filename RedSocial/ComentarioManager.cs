using System.Data;
using System.Data.SqlClient;

namespace RedSocial
{
    public class ComentarioManager
    {
        private List<Comentario> misComentarios;
        private string connectionDB = Properties.Resources.ConnectionString;

        public ComentarioManager()
        {
            misComentarios = new List<Comentario>();
            inicializarAtributos();
        }

        public List<Comentario> inicializarAtributos()
        {
            //Cargo la cadena de conexión desde el archivo de properties
            string connectionString = connectionDB;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.COMENTARIO";

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
                    Comentario aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Comentario(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                        misComentarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            // relaciono las tablas con usuarios y posts
            foreach(Comentario c in misComentarios)
            {
                foreach (Usuario u in misUsuarios)
                {
                    if (u.id == c.idUsuario)
                    {
                        u.misComentarios.Add(c);
                        c.usuario = u;
                    }
                }

                foreach (Post p in misPosts)
                {
                    if (c.idPost == p.id)
                    {
                        c.post = p;
                        p.comentarios.Add(c);
                    }
                }
            }

            return misComentarios;
        }

        public bool registrarComentario(DateTime fecha, string contenido, int idUsuario, int idPost)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoComentario = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[COMENTARIO] ([FECHA],[CONTENIDO],[ID_USUARIO],[ID_POST]) VALUES (@fecha,@contenido,@idUsuario,@idPost);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@idPost", SqlDbType.NVarChar));

                command.Parameters["@fecha"].Value = fecha;
                command.Parameters["@contenido"].Value = contenido;
                command.Parameters["@idUsuario"].Value = idUsuario;
                command.Parameters["@idPost"].Value = idPost;

                Console.WriteLine(queryString + "hola");


                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[COMENTARIO]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoComentario = reader.GetInt32(0);
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
                Comentario nuevo = new Comentario(idNuevoComentario,
                                            fecha,
                                            contenido,
                                            idUsuario,
                                            idPost);
                misComentarios.Add(nuevo);
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool eliminarComentario(int id)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[COMENTARIO] WHERE ID=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
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
                    for (int i = 0; i < misComentarios.Count; i++)
                        if (misComentarios[i].id == id)
                            misComentarios.RemoveAt(i);
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

        public bool modificarComentario(int id, string contenido)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[Usuario] SET CONTENIDO=@contenido WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {



                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
     
                command.Parameters["@id"].Value = id;
                command.Parameters["@contenido"].Value = contenido;
         

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
                    for (int i = 0; i < misComentarios.Count; i++)
                        if (misComentarios[i].id == id)
                        {
                            misComentarios[i].contenido = contenido;
                            
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
