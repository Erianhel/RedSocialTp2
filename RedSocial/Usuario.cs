using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial
{
    public class Usuario
    {

        public int id { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string pass { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }

        public List<Usuario> amigos = new List<Usuario>();

        public List<Post> misPost = new List<Post>();

        public List<Comentario> misComentarios = new List<Comentario>();

        public List<Reaccion> misReacciones = new List<Reaccion>();


        public Usuario(int id, string dni, string nombre, string apellido, string mail, string pass) 
        {
            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.pass = pass;
            this.intentosFallidos = 0;
            this.bloqueado = false;
        }
    }
}
