using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial
{
    public class RedSocial
    {
        private List<Usuario> usuarios;
        public Usuario usuarioActual { get; set; }
        private List<Post> posts;
        private List<Tag> tags;
        private List<Comentario> comentarios;
        private DAL DB;
        public RedSocial()
        {
            usuarios = new List<Usuario>();
            posts = new List<Post>();
            tags = new List<Tag>();
            comentarios = new List<Comentario>();
            DB = new DAL();
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            usuarios = DB.inicializarUsuarios();
            posts = DB.inicializarPost(usuarios);
            DB.inicializarReacciones(posts, usuarios);
            comentarios = DB.inicializarComentarios(posts, usuarios);
            tags = DB.inicializarTags();
            DB.inicializarTagsPost(posts, tags);
            DB.inicializarReacciones(posts, usuarios);
        }

        public bool iniciarSesion(string user, string pass)
        {
            bool usuarioEncontrado = false;

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.intentosFallidos == 3)
                {
                    usuarios[usuario.id].bloqueado = true;
                    DB.modificarUsuario(usuario.id, usuario.dni, usuario.nombre, usuario.apellido, usuario.mail, usuario.pass, usuario.esAdmin, true, 3);
                }

                if (usuario.nombre.Equals(user) && usuario.pass.Equals(pass) && usuario.bloqueado != true)
                {
                    this.usuarioActual = usuario;
                    usuarioEncontrado = true;
                    this.usuarioActual.intentosFallidos = 0;
                }
                else if (usuario.nombre.Equals(user) && !usuario.pass.Equals(pass))
                {
                    usuarios[usuario.id].intentosFallidos++;
                }

            }
            return usuarioEncontrado;
        }

        //Cerrar sesión
        public void cerrarSesion()
        {
            usuarioActual = null;
        }

        //======================================MANEJO DE USUARIOS=========================================
        public List<Usuario> getUsuarios()
        {
            return usuarios;
        }
        public bool registrarUsuario(string Dni, string Nombre, string Apellido, string Mail, string Password, bool admin)
        {
            //comprobación para que no me agreguen usuarios con DNI duplicado
            bool esValido = true;
            foreach (Usuario u in usuarios)
            {
                if (u.dni.Equals(Dni))
                {
                    esValido = false;
                }
            }
            if (esValido)
            {
                int idNuevoUsuario;
                idNuevoUsuario = DB.registrarUsuario(Dni, Nombre, Apellido, Mail, Password, admin, false, 0);
                if (idNuevoUsuario != -1)
                {
                    //Ahora sí lo agrego en la lista
                    Usuario nuevo = new Usuario(idNuevoUsuario, Dni, Nombre, Apellido, Mail, Password, admin, false, 0);
                    usuarios.Add(nuevo);
                    return true;
                }
                else
                {
                    //algo salió mal con la query porque no generó un id válido
                    return false;
                }
            }
            else
                return false;
        }

        public bool eliminarUsuario(int Id)
        {
            //primero me aseguro que lo pueda agregar a la base
            if (DB.eliminarUsuario(Id) == 1)
            {
                try
                {
                    //Ahora sí lo elimino en la lista
                    for (int i = 0; i < usuarios.Count; i++)
                        if (usuarios[i].id == Id)
                            usuarios.RemoveAt(i);
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

        public bool modificarUsuario(int Id, string Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADM, bool Bloqueado, int IntentosFallidos)
        {
            //primero me aseguro que lo pueda agregar a la base
            if (DB.modificarUsuario(Id, Dni, Nombre, Apellido, Mail, Password, EsADM, Bloqueado,IntentosFallidos) == 1)
            {
                try
                {
                    //Ahora sí lo MODIFICO en la lista
                    for (int i = 0; i < usuarios.Count; i++)
                        if (usuarios[i].id == Id)
                        {
                            usuarios[i].nombre = Nombre;
                            usuarios[i].apellido = Apellido;
                            usuarios[i].dni = Dni;
                            usuarios[i].mail = Mail;
                            usuarios[i].pass = Password;
                            usuarios[i].esAdmin = EsADM;
                            usuarios[i].bloqueado = Bloqueado;
                            usuarios[i].intentosFallidos = IntentosFallidos;
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

        //===========================================MANEJO DE AMIGOS==================================================

        public bool agregarAmigo(int id)
        {
            if (DB.registrarAmigo(usuarioActual.id, id))
            {
                foreach (Usuario u in usuarios)
                {

                    if (!usuarioActual.amigos.Contains(u) && (u.id == id))
                    {
                        u.amigos.Add(usuarioActual);
                        usuarioActual.amigos.Add(u);
                        return true;
                    }

                }
            }
            return false;
        }

        public void quitarAmigo(int id)
        {

            if (DB.eliminarAmigo(id, usuarioActual.id))
            {
                foreach (Usuario u in usuarios)
                {

                    if (u.id == id)
                    {
                        //Se elimina el amigo
                        int aux = usuarios.FindIndex(usuario => usuario.id == usuarioActual.id);
                        usuarios[aux].amigos.Remove(u);

                        //El usuario que fue eliminado, tambien elimina al usuario que lo elimino
                        int aux2 = usuarios.FindIndex(usuario => usuario.id == u.id);
                        usuarios[aux2].amigos.Remove(usuarioActual);

                    }
                }
            }

        }

        //===========================================MANEJO DE REACCIONES==================================================
        public bool reaccionar(int idPost, int tipoReaccion, int idUsuario)
        {

            int idNuevaReaccion = DB.Reaccionar(tipoReaccion, idPost, idUsuario);
            if (idNuevaReaccion != -1)
            {
                Post PostAModif = null;
                foreach (Post p in posts)
                {
                    if (p.id == idPost)
                    {
                        PostAModif = p;
                    }
                }
                if (PostAModif != null)
                {
                    foreach (Reaccion r in PostAModif.reacciones)
                    {
                        if (r.usuario.id == idUsuario)
                        {
                            return false;
                        }
                    }
                    Reaccion Nueva = new Reaccion(idNuevaReaccion, tipoReaccion, PostAModif.id, idUsuario);
                    PostAModif.reacciones.Add(Nueva);
                    usuarioActual.misReacciones.Add(Nueva);
                    return true;
                }
            }
            return false;
        }


        public void modificarReaccion(int idReaccion, int tipo, int idPost)
        {

            if (DB.modificarReaccion(idReaccion, tipo))
            {
                foreach (Post p in posts)
                {
                    if (p.id == idPost)
                    {
                        //busco el indice de la reaccion en la lista de posts
                        int aux = p.reacciones.FindIndex((reaccion) => reaccion.id == idReaccion);
                        p.reacciones[aux].tipo = tipo;
                    }
                }

            }

        }

        public void quitarReaccion(int idPost)
        {
            int idReaccion = 0;
            foreach (Post p in posts) {
                if(p.usuario.id == usuarioActual.id)
                {
                    foreach(Reaccion r in p.reacciones)
                    {
                        if(r.usuario.id == usuarioActual.id)
                        {
                            idReaccion = r.id;
                        }
                    }
                }
            }
            if (DB.eliminarReaccion(idReaccion))
            {
                //Borro reaccion de la lista
                foreach (Post p in posts)
                {
                    if (p.id == idPost)
                    {
                        //busco el indice de la reaccion en la lista de posts
                        int aux = p.reacciones.FindIndex((reaccion) => reaccion.id == idReaccion);
                        p.reacciones.RemoveAt(aux);
                    }
                }
            }

        }

        //===========================================MANEJO DE POSTEOS==================================================
        public void postear(string contenido, DateTime fecha, int idUsuario, List<Tag> tag)
        {
            int idNuevoPost;
            idNuevoPost = DB.Postear(contenido, fecha, idUsuario);

            if (idNuevoPost != -1)
            {
                //Ahora sí lo agrego en la lista
                Post nuevo = new Post(idNuevoPost,
                                            fecha,
                                            contenido,
                                            idUsuario);
                nuevo.usuario = usuarioActual;
                foreach (Tag t in tag)
                {
                    t.posts.Add(nuevo);
                    nuevo.tags.Add(t);

                    if (!tags.Contains(t))
                    {
                        tags.Add(t);
                    }
                }
                foreach (Tag t in tag)
                {
                    t.posts.Add(nuevo);
                    nuevo.tags.Add(t);

                    if (!tags.Contains(t))
                    {
                        tags.Add(t);
                    }
                }
                posts.Add(nuevo);
                usuarioActual.misPost.Add(nuevo);

            }

        }

        public bool modificarPost(int idPost, string comentario)
        {
            int aux = posts.FindIndex(p => p.id == idPost);
            Post post = posts[aux];

            if (!post.usuario.Equals(usuarioActual)) return false;

            if (DB.modificarPost(idPost, comentario))
            {
                post.contenido = comentario;
                return true;
            }
            return false;
        }

        public bool eliminarPost(int idPost)

        {
            
            //Busco el post a eliminar
            int auxPost = posts.FindIndex(p => p.id == idPost);

            //busco al usuario en la lista de usuarios
            int aux = usuarios.FindIndex(usuario => usuario.id == usuarioActual.id);
            if (!usuarioActual.misPost.Contains(posts[auxPost])) return false;
                //busco la reaccion correspondiente al post 
                Reaccion reaccionEliminar;
            if (posts[auxPost].reacciones != null && posts[auxPost].reacciones.Count >0)
            {
                //elimino la reaccion correspondiente al post
                reaccionEliminar = usuarios[aux].misReacciones.Find(x => x.post.Equals(posts[auxPost]));
                usuarios[aux].misReacciones.Remove(reaccionEliminar);
                DB.eliminarReaccion(reaccionEliminar.id);
            }

            if (posts[auxPost].comentarios != null)
            {
                foreach (Comentario c in posts[auxPost].comentarios)
                {
                    // Se elimina el comentario del post
                    usuarios[aux].misComentarios.Remove(c);
                    DB.eliminarComentario(c.id);
                }

            }

            DB.eliminarPost(idPost);
            usuarios[aux].misPost.Remove(posts[auxPost]); // borro el post de la lista de posts del usuario
            posts.RemoveAt(auxPost); //borro el post de la lista de posts

            return true;
        }

        //===========================================MOSTRAR DATOS==================================================

        public Usuario mostrarDatos()
        {
            return usuarioActual;
        }

        //Mostar posts
        public List<Post> mostrarPost()
        {
            return posts;
        }

        //Mostrar posts amigo
        public List<Post> mostrarPostAmigo()
        {
            List<Post> postAmigo = new List<Post>();
            foreach (Usuario amigo in usuarioActual.amigos)
            {
                foreach (Post post in amigo.misPost)
                {
                    postAmigo.Add(post);
                }
            }
            return postAmigo;
        }

        //Buscar posts
        public List<Post> buscarPosts(string contenido, DateTime fechaDesde, DateTime fechaHasta, List<Tag> t)
        {
            List<Post> bPost = new List<Post>();
            foreach (Post post in posts)
            {
                if (post.contenido.Contains(contenido))
                {
                    bPost.Add(post);
                }
                else if (post.fecha >= fechaDesde && post.fecha <= fechaHasta)
                {
                    bPost.Add(post);
                }
                else
                {
                    foreach (Tag p in t)
                    {
                        foreach (Tag q in post.tags)
                        {
                            if (q.palabra == p.palabra)
                            {
                                bPost.Add(post);
                            }
                        }
                    }
                }
            }
            return bPost;
        }
        public Post buscarPost(int idPost)
        {
            Post post = null;
            foreach(Post postActual in posts)
            {
                if(idPost == postActual.id)
                {
                    post = postActual;
                    break;
                }
            }
            return post;
        }


        //===========================================MANEJO DE COMENTARIOS==================================================

        public void comentar(int idPost, String contenido, DateTime fecha)
        {
            int idNuevoComentario;
            idNuevoComentario = DB.registrarComentario(fecha, contenido, usuarioActual.id, idPost);
            if (idNuevoComentario != -1)
            {
                //Ahora sí lo agrego en la lista
                Comentario nuevo = new Comentario(idNuevoComentario, fecha, contenido, usuarioActual.id, idPost);
                nuevo.usuario = usuarioActual;

                int aux = posts.FindIndex(p => p.id == idPost);
                nuevo.post = posts[aux];

                comentarios.Add(nuevo);
                posts[aux].comentarios.Add(nuevo);

            }
        }

        //Modificar comentario
        public void modificarComentario(int idComentario, string nuevoComentario)
        {

            if (DB.modificarComentario(idComentario, nuevoComentario))
            {
                int aux = comentarios.FindIndex(c => c.id == idComentario);

                if (comentarios[aux].usuario.Equals(usuarioActual))
                {
                    comentarios[aux].contenido = nuevoComentario;
                }
            }

        }

        //Borrar comentario
        public void quitarComentario(int idPost, int idComentario)
        {
            int auxCom = comentarios.FindIndex(c => c.id == idComentario);
            if (!comentarios[auxCom].usuario.Equals(usuarioActual) && !usuarioActual.esAdmin) return;

            if (DB.eliminarComentario(idComentario))
            {
                int aux2 = posts.FindIndex(post => post.id == idPost);

                posts[aux2].comentarios.Remove(comentarios[auxCom]);

                int aux = usuarios.FindIndex(usuario => usuario.id == usuarioActual.id);
                usuarios[aux].misComentarios.Remove(comentarios[auxCom]);

                comentarios.Remove(comentarios[auxCom]);
            }

        }



    }

}