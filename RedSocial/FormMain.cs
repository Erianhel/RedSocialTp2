using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedSocial
{
    public partial class FormMain : Form
    {
        private RedSocial miRed;
        private int seleccionarAmigo;
        private int seleccionarPost;

        public delegate void TransfDelegadoAgregarAmigo();
        public TransfDelegadoAgregarAmigo eventoAgregarAmigo;

        public delegate void TransfDelegadoPostear();
        public TransfDelegadoPostear eventoPostear;

        public delegate void TransfDelegadoVerPost(int idPost);
        public TransfDelegadoVerPost eventoVerPost;

        public delegate void TransfDelegadoLogIn();
        public TransfDelegadoLogIn eventoLogIn;

        public delegate void TransfDelegadoBuscarPost();
        public TransfDelegadoBuscarPost eventoBuscarPost;

        public FormMain(RedSocial miRed)
        {
            this.miRed = miRed;
            InitializeComponent();
            nombreUsuarioActual.Text = miRed.usuarioActual.nombre;
            nombreCompleto.Text = miRed.usuarioActual.nombre + miRed.usuarioActual.apellido;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach(Usuario amigos in miRed.mostrarDatos().amigos)
            {
                dataGridView_listaAmigos.Rows.Add(amigos.id,amigos.nombre,amigos.apellido,"Eliminar");
            }
            foreach(Post post in miRed.mostrarDatos().misPost)
            {
                dataGridView_MisPost.Rows.Add(post.id,post.contenido,"Ver Post");
            }
            foreach (Post post in miRed.mostrarPost())
            {
                dataGridView_PosteosRed.Rows.Add(post.id, post.contenido, "Ver Post");
            }

        }

        //////////////////////////BOTONES
        private void button_agregarAmigo_Click(object sender, EventArgs e)
        {
            this.eventoAgregarAmigo();
            this.Close();
        }
        private void button_irFormPostear(object sender, EventArgs e)
        {
            this.eventoAgregarAmigo();
            this.Close();
        }

        ///////////////////////BOTONES DE GRILLAS
        private void seleccionadorAmigo(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarAmigo = e.RowIndex;
        }

        private void eliminadorAmigo(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionarAmigo != null && seleccionarAmigo != -1)
            {
                miRed.quitarAmigo(int.Parse(dataGridView_listaAmigos.Rows[seleccionarAmigo].Cells[0].Value.ToString()));
                dataGridView_listaAmigos.Rows.Remove(dataGridView_listaAmigos.Rows[seleccionarAmigo]);
            }
        }
        private void seleccionadorPost(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarPost = e.RowIndex;
        }

        private void button_postear_Click(object sender, EventArgs e)
        {
            this.eventoPostear();
            this.Close();
        }

        private void dataGridView_MisPost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (seleccionarPost != null && seleccionarPost != -1)
            {
                this.eventoVerPost(int.Parse(dataGridView_MisPost.Rows[seleccionarPost].Cells[0].Value.ToString()));
                this.Close();
            }
        }
        private void dataGridView_Post_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionarAmigo != null && seleccionarAmigo != -1)
            {
                this.eventoVerPost(int.Parse(dataGridView_PosteosRed.Rows[seleccionarPost].Cells[0].Value.ToString()));
                this.Close();
            }
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            miRed.cerrarSesion();
            this.eventoLogIn();
            this.Close();
        }

        private void button_BuscarPost_Click(object sender, EventArgs e)
        {
            this.eventoBuscarPost();
            this.Close();
        }
    }
}
