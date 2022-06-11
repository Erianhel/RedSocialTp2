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
        public int idUsuario { get; set; }
        public int idPost { get; set; }


        public Reaccion(int id, int tipo, int idPost, int idUsuario)
        {
            this.id = id;
            this.tipo = tipo;
            this.idPost = idPost;
            this.idUsuario = idUsuario;
        }

        public void codigo()
        {
            int p1 = 0;
            int correcto = 0;
            string respuesta = "";
            //pregunto si 2+2=4??

            if (p1 == 0)
            {
                respuesta = "8";
                if (respuesta == "8")
                {
                    correcto++;
                }
                p1 = 1;
            }
            else
            {
                //ACA YA PASASTE
            }

        }


    }
}
