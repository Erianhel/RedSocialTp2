using System.Data;
using System.Data.SqlClient;

namespace RedSocial
{
    internal class TagManager
    {

        private string connectionDB = Properties.Resources.ConnectionString;
        private List<Tag> misTags;

        public List<Tag> inicializarTags()
        {
            List<Tag> misTags = new List<Tag>();

            string queryString = "SELECT * from dbo.Tag";

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

        public bool altaTag(string palabra)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoTag = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[Tag] ([Palabra]) VALUES (@palabra);";
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
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Tag]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoTag = reader.GetInt32(0);
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
                //Tag tag = new Tag(idNuevoUsuario, palabra);

                misTags.Add(tag);
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        public bool bajaTag(int Id)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "DELETE FROM [dbo].[Tag] WHERE ID=@id";
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
                    for (int i = 0; i < misTags.Count; i++)
                        if (misTags[i].id == Id)
                            misTags.RemoveAt(i);
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

        public bool modificarTags(int id, string palabra)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            string connectionString = connectionDB;
            string queryString = "UPDATE [dbo].[Tag] SET palabra=@palabra WHERE ID=@id;";
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
            }
        }



    }
}
