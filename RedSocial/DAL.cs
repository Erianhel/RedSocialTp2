using System.Data;
using System.Data.SqlClient;

namespace RedSocial
{
    public class DAL
    {
        /*private List<Usuario> misUsuarios;
        private List<Post> misPosts;
        
         misComentarios;
         misTags;*/
        private string connectionDB;

        public DAL()
        {

            connectionDB = Properties.Resources.ConnectionString;
            /*misUsuarios = new List<Usuario>();
            List<Post> misPosts = new List<Post>(); 
            private List<Reaccion> misReacciones = new List<Reaccion>(); 
            private List<Comentario> misComentarios = new List<Comentario>();
            private List<Tag> misTags = new List<Tag>();*/


            /* inicializarUsuarios();
             inicializarAmigos();
             inicializarPost();
             inicializarReacciones();
             inicializarComentarios();
             inicializarTags();
             inicializarTagsPost();*/
        }

        //============================================MANEJO DE USUARIOS / AMIGOS=============================================
        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();
            //Cargo la cadena de conexión desde el archivo de properties
            string connectionString = connectionDB;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.USUARIO";

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
                    Usuario aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6), reader.GetBoolean(7), reader.GetInt32(8));

                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                inicializarAmigos(misUsuarios);
            }

            return misUsuarios;
        }

        public void inicializarAmigos(List<Usuario>misUsuarios)
        {
            //Cargo la cadena de conexión desde el archivo de properties
            string connectionString = connectionDB;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.AMIGO";

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
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        foreach (Usuario usuario in misUsuarios)
                        {
                            if (usuario.id == reader.GetInt32(2))
                            {
                                foreach (Usuario usuario2 in misUsuarios)
                                {
                                    if (usuario2.id == reader.GetInt32(1))
                                    {
                                        usuario.amigos.Add(usuario2);
                                        usuario2.amigos.Add(usuario);
                                    }
                                }
                            }
                        }
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

        public bool registrarAmigo(int idUsuario, int idAmigo)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;

            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[AMIGO] ([ID_AMIGO],[ID_USUARIO]) VALUES (@idamigo,@idusuario);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idamigo", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@idusuario", SqlDbType.NVarChar));


                command.Parameters["@idamigo"].Value = idAmigo;
                command.Parameters["@idusuario"].Value = idUsuario;
                ;


                Console.WriteLine(queryString + "hola");


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
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool eliminarAmigo(int idAmigo, int idUsuario)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[AMIGO] WHERE ID_AMIGO=@idAmigo AND ID_USUARIO=@idUsuario";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idAmigo", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));

                command.Parameters["@idAmigo"].Value = idAmigo;
                command.Parameters["@idUsuario"].Value = idUsuario;
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
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        /*public List<List<string>> obtenerUsuarios()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in misUsuarios)
                salida.Add(new List<string>() { u.id.ToString(), u.dni.ToString(), u.nombre, u.apellido, u.mail, u.pass, u.esAdmin.ToString(), u.intentosFallidos.ToString(), u.bloqueado.ToString() });
            return salida;
        }*/

        public int  registrarUsuario(string Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADM, bool Bloqueado, int IntentosFallidos)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[Usuario] ([DNI],[NOMBRE],[APELLIDO],[MAIL],[PASSWORD],[ES_ADMIN],[BLOQUEADO],[INTENTOS_FALLIDOS]) VALUES (@dni,@nombre,@apellido,@mail,@password,@esAdmin,@bloqueado,@intentosFallidos);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@esAdmin", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));

                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esAdmin"].Value = EsADM;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                command.Parameters["@intentosFallidos"].Value = IntentosFallidos;

                Console.WriteLine(queryString + "hola");


                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuario]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }

                return idNuevoUsuario;
            }
            
        }

        public int eliminarUsuario(int Id)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[Usuario] WHERE ID=@id";
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
                    return -1;
                }
            }
            return resultadoQuery;
        }

        public int modificarUsuario(int Id, string Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADM, bool Bloqueado, int IntentosFallidos)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[Usuario] SET NOMBRE=@nombre, APELLIDO=@apellido,MAIL=@mail,PASSWORD=@password, ES_ADMIN=@esAdmin, BLOQUEADO=@bloqueado, INTENTOS_FALLIDOS=@intentosFallidos WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {



                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@esAdmin", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));
                command.Parameters["@id"].Value = Id;
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esAdmin"].Value = EsADM;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                command.Parameters["@intentosFallidos"].Value = IntentosFallidos;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            return resultadoQuery;
        }

        //============================================MANEJO DE POSTS=============================================
        public List<Post> inicializarPost(List<Usuario>misUsuarios)
        {
            List<Post> misPosts = new List<Post>();
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

                //relaciono post con usuarios
                foreach (Post p in misPosts)
                {
                    foreach (Usuario u in misUsuarios)
                    {
                        if (p.idUsuario == u.id)
                        {
                            u.misPost.Add(p);
                            p.usuario = u;
                        }
                    }
                }
            }
            return misPosts;
        }

        public int Postear(string contenido, DateTime fecha, int idUsuario)
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

                command.Parameters["@contenido"].Value = contenido;
                command.Parameters["@fecha"].Value = fecha;
                command.Parameters["@id_usuario"].Value = idUsuario;

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
                    return -1;
                }
            }
            return idNuevoPost;
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
            return true;
        }

        public bool modificarPost(int id, string contenido)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[POST] SET CONTENIDO=@contenido WHERE ID=@id;";
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
            return true;
        }

        //============================================MANEJO DE REACCIONES=============================================
        public List<Reaccion> inicializarReacciones(List<Post>misPosts, List<Usuario> misUsuarios)
        {
            List<Reaccion> misReacciones = new List<Reaccion>();
            //Cargo la cadena de conexión desde el archivo de properties
            string connectionString = connectionDB;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from [dbo].[REACCION]";

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

                //Relaciono reacciones con post y usuarios
                foreach (Reaccion aux in misReacciones)
                {
                    foreach (Post p in misPosts)
                    {
                        if (aux.idPost == p.id)
                        {
                            aux.post = p;
                            p.reacciones.Add(aux);
                        }
                    }

                    foreach (Usuario u in misUsuarios)
                    {
                        if (aux.idUsuario == u.id)
                        {
                            aux.usuario = u;
                            u.misReacciones.Add(aux);
                        }
                    }
                }
            }
            return misReacciones;
        }

        public int Reaccionar(int tipo, int idPost, int idUsuario)
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
                    return -1;
                }
            }
            return idNuevaReaccion;
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
            return true;
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
            return true;
        }

        //============================================MANEJO DE COMENTARIOS=============================================

        public List<Comentario> inicializarComentarios(List<Post>misPosts,List<Usuario> misUsuarios)
        {
            List<Comentario> misComentarios = new List<Comentario>();
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
            foreach (Comentario c in misComentarios)
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

        public int registrarComentario(DateTime fecha, string contenido, int idUsuario, int idPost)
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
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idPost", SqlDbType.Int));

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
                    return -1;
                }
            }
            return idNuevoComentario;
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
            return true;
        }

        public bool modificarComentario(int id, string contenido)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[COMENTARIO] SET CONTENIDO=@contenido WHERE ID=@id;";
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
            return true;
        }

        //============================================MANEJO DE TAG=============================================
        public List<Tag> inicializarTags()
        {
            List<Tag> misTags = new List<Tag>();

            string queryString = "SELECT * from dbo.TAG";

            using (SqlConnection connection =
                new SqlConnection(connectionDB))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Tag aux;
                    while (reader.Read())
                    {
                        aux = new Tag(reader.GetInt32(0), reader.GetString(1));
                        misTags.Add(aux);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misTags;
        }

        public int altaTag(string palabra, int idPost)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoTag = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[TAG] ([Palabra]) VALUES (@palabra);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@palabra", SqlDbType.NVarChar));

                command.Parameters["@palabra"].Value = palabra;

                Console.WriteLine(queryString);
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[TAG]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoTag = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            return idNuevoTag;
        }

        public bool bajaTag(int Id)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[TAG] WHERE ID=@id";
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
                /*
                try
                {
                    //Ahora sí lo elimino en la lista
                    for (int i = 0; i < misTags.Count; i++)
                        if (misTags[i].id == Id)
                            misTags.RemoveAt(i);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }*/
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool modificarTags(int id, string palabra)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[TAG] SET palabra=@palabra WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@palabra", SqlDbType.NVarChar));
                command.Parameters["@palabra"].Value = palabra;

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
            /*
            if (resultadoQuery == 1)
            {
                try
                {
                    //Ahora sí lo MODIFICO en la lista
                    for (int i = 0; i < misTags.Count; i++)
                        if (misTags[i].id == id)
                        {
                            misTags[i].palabra = palabra;
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
            }*/
            return true;
        }
        //============================================MANEJO DE TAG-POST=============================================
        public void inicializarTagsPost(List<Post>misPosts, List<Tag> misTags)
        {

            string queryString = "SELECT * from dbo.TAG_POST";

            using (SqlConnection connection =
                new SqlConnection(connectionDB))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int idPost = reader.GetInt32(2);
                        int idTag = reader.GetInt32(1);
                        Post postAux = null;
                        foreach (Post post in misPosts)
                        {
                            if (post.id == idPost)
                            {
                                postAux = post;
                                break;
                            }
                        }

                        foreach (Tag tag in misTags)
                        {
                            if (tag.id == idTag)
                            {
                                postAux.tags.Add(tag);
                                tag.posts.Add(postAux);
                                break;
                            }
                        }
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public bool altaRelacionarTagPost(int id_post, int id_tag)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoTag_post = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[TAG_POST] ([ID_post],[ID_tag]) VALUES (@id_post,@id_tag);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_post", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@id_tag", SqlDbType.NVarChar));

                command.Parameters["@id_post"].Value = id_post;
                command.Parameters["@id_tag"].Value = id_tag;

                Console.WriteLine(queryString);
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[TAG_POST]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoTag_post = reader.GetInt32(0);
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
                /*
                Post postAux = null;
                foreach (Post post in misPosts)
                {
                    if (post.id == Int32.Parse(id_post))
                    {
                        postAux = post;
                        break;
                    }
                }

                foreach (Tag tag in misTags)
                {
                    if (tag.id == Int32.Parse(id_tag))
                    {
                        postAux.tags.Add(tag);
                        tag.posts.Add(postAux);
                        break;
                    }
                }
                */
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool bajaRelacionTag_post(int IdTag, int IdPost)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[TAG_POST] WHERE ID_post=@idTag AND ID_tag=@idPost";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idTag", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idPost", SqlDbType.Int));
                command.Parameters["@idTag"].Value = IdTag;
                command.Parameters["@idPost"].Value = IdPost;
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
                    /*
                    //Ahora sí lo elimino en la lista
                    Post postAux = null;
                    foreach (Post post in misPosts)
                    {
                        if (post.id == IdPost)
                        {
                            postAux = post;
                            break;
                        }
                    }

                    foreach (Tag tag in misTags)
                    {
                        if (tag.id == IdTag)
                        {
                            postAux.tags.Remove(tag);
                            tag.posts.Remove(postAux);
                            break;
                        }
                    }
                    */
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
