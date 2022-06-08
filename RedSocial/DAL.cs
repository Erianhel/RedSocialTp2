using System.Data;
using System.Data.SqlClient;

namespace RedSocial
{
    public class DAL
    {
        private List<Usuario> misUsuarios;
        private List<Post> misPosts;
        private List<Reaccion> misReacciones;
        private List<Comentario> misComentarios;
        private string connectionDB = Properties.Resources.ConnectionString;

        public DAL()
        {
            misUsuarios = new List<Usuario>();
            misPosts = new List<Post>(); 
            misReacciones = new List<Reaccion>(); 
            misComentarios = new List<Comentario>();
            

            inicializarUsuarios();
            inicializarAmigos();
            inicializarPost();
            inicializarReacciones();
            inicializarComentarios();
        }

        //============================================MANEJO DE USUARIOS / AMIGOS=============================================
        public List<Usuario> inicializarUsuarios()
        {
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
                        aux = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6), reader.GetInt32(7), reader.GetBoolean(8));
                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return misUsuarios;
        }

        public void inicializarAmigos()
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

        public List<List<string>> obtenerUsuarios()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in misUsuarios)
                salida.Add(new List<string>() { u.id.ToString(), u.dni.ToString(), u.nombre, u.apellido, u.mail, u.pass, u.esAdmin.ToString(), u.intentosFallidos.ToString(), u.bloqueado.ToString() });
            return salida;
        }

        public bool registrarUsuario(string Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADM, int IntentosFallidos, bool Bloqueado)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[Usuario] ([DNI],[NOMBRE],[APELLIDO],[MAIL],[PASSWORD],[ES_ADMIN],[BLOQUEADO],[INTENTOS_FALLIDOS]) VALUES (@dni,@nombre,@apellido,@mail,@password,@esadm,@bloqueado,@intentosFallidos);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));

                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esadm"].Value = EsADM;
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
                    return false;
                }
            }
            if (resultadoQuery == 1)
            {

                //Ahora sí lo agrego en la lista
                Usuario nuevo = new Usuario(idNuevoUsuario,
                                            Dni,
                                            Nombre,
                                            Apellido,
                                            Mail,
                                            Password,
                                            EsADM,
                                            IntentosFallidos,
                                            Bloqueado);
                misUsuarios.Add(nuevo);
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool eliminarUsuario(int Id)
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
                    return false;
                }
            }
            if (resultadoQuery == 1)
            {
                try
                {
                    //Ahora sí lo elimino en la lista
                    for (int i = 0; i < misUsuarios.Count; i++)
                        if (misUsuarios[i].id == Id)
                            misUsuarios.RemoveAt(i);
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

        public bool modificarUsuario(int Id, string Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADM, int IntentosFallidos, bool Bloqueado)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[Usuario] SET NOMBRE=@nombre, APELLIDO=@apellido,MAIL=@mail,PASSWORD=@password, ES_ADMIN=@esadm, BLOQUEADO=@bloqueado, INTENTOS_FALLIDOS=@intentosFallidos WHERE ID=@id;";
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
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));
                command.Parameters["@id"].Value = Id;
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esadm"].Value = EsADM;
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
                    return false;
                }
            }
            if (resultadoQuery == 1)
            {
                try
                {
                    //Ahora sí lo MODIFICO en la lista
                    for (int i = 0; i < misUsuarios.Count; i++)
                        if (misUsuarios[i].id == Id)
                        {
                            misUsuarios[i].nombre = Nombre;
                            misUsuarios[i].apellido = Apellido;
                            misUsuarios[i].mail = Mail;
                            misUsuarios[i].pass = Password;
                            misUsuarios[i].esAdmin = EsADM;
                            misUsuarios[i].bloqueado = Bloqueado;
                            misUsuarios[i].intentosFallidos = IntentosFallidos;
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

        //============================================MANEJO DE POSTS=============================================
        public List<Post> inicializarPost()
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

        //============================================MANEJO DE REACCIONES=============================================
        public List<Reaccion> inicializarReacciones()
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

        //============================================MANEJO DE COMENTARIOS=============================================

        public List<Comentario> inicializarComentarios()
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
