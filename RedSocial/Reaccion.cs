using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial
{
    public class Reaccion
    {
        public int id { get; set; }
        public int tipo { get; set; }
        public Post post { get; set; }
        public Usuario usuario{ get; set; }

        public static int cantidadReaccion = 0;

        public Reaccion(int tipo, Post post, Usuario usuario)
        {
            this.id = cantidadReaccion;
            this.tipo = tipo;
            this.post = post;
            this.usuario = usuario;

            cantidadReaccion++;
        }

    }
}
