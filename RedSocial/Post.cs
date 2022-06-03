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
        public int idUsuario {get; set;}


        public Post(int id, DateTime fecha, string contenido, int idUsuario)
        {
            this.contenido = contenido;
            this.comentarios = new List<Comentario>(); 
            this.reacciones = new List<Reaccion>();
            this.tags = new List<Tag>();
            this.fecha = fecha;
            this.idUsuario = idUsuario;

        }
    }
    
}
