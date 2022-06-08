using System.Data;
using System.Data.SqlClient;

namespace RedSocial
{
    internal class TagPostManager
    {
        private string connectionDB = Properties.Resources.ConnectionString;
        private List<Tag> misTags;
        private List<Post> misPost;
        public TagPostManager(List<Tag> misTags, List<Post> misPost)
        {
            this.misTags = misTags;
            this.misPost = misPost;
        }
        public void inicializarTagsPost()
        {

            string queryString = "SELECT * from dbo.Tag";

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
                        int idPost = reader.GetInt32(1);
                        int idTag = reader.GetInt32(2);
                        Post postAux = null;
                        foreach (Post post in misPost)
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

        public bool altaRelacionarTagPost(string id_post, string id_tag)
        {

            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoTag_post = -1;
            string connectionString = connectionDB;
            string queryString = "INSERT INTO [dbo].[Tag_post] ([ID_post],[ID_tag]) VALUES (@id_post,@id_tag);";
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
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Tag_post]";
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

                //Ahora sí lo agrego en la lista
                //Tag tag = new Tag(idNuevoUsuario, palabra);

                //misTags.Add(tag);
                Post postAux = null;
                foreach (Post post in misPost)
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
            string queryString = "DELETE FROM [dbo].[Tag_post] WHERE ID_post=@idTag AND ID_tag=@idPost";
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
                    //Ahora sí lo elimino en la lista
                    Post postAux = null;
                    foreach (Post post in misPost)
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
