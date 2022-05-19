using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial
{
    public class Post
    {
        public int id { get; set; }
        public Usuario usuario {get; set;}
        public string contenido {get; set;}
        public List<Comentario> comentarios {get; set;}
        public List<Reaccion> reacciones {get; set;}
        public List<Tag> tags {get; set;}
        public DateTime fecha {get; set;}

        public static int cantidadPost = 0;

        public Post(Usuario usuario, string contenido, DateTime fecha)
        {

            this.id = cantidadPost;
            this.usuario = usuario;
            this.contenido = contenido;
            this.comentarios = new List<Comentario>(); 
            this.reacciones = new List<Reaccion>();
            this.tags = new List<Tag>();
            this.fecha = fecha;

            cantidadPost++;

        }
    }
    
}
