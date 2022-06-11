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
    public partial class FormAdmin : Form
    {
        private RedSocial miRed;
        private int seleccionarUsuario;
        private int seleccionarPost;
        private int seleccionarTag;

        public delegate void TransfDelegadoLogIn();
        public TransfDelegadoLogIn eventoLogIn;

        public delegate void TransfDelegadoUsuario(int idUsuario);
        public TransfDelegadoUsuario eventoUsuario;

        public delegate void TransfDelegadoPost(int idPost);
        public TransfDelegadoPost eventoPost;

        public FormAdmin(RedSocial redSocial)
        {
            InitializeComponent();
            miRed = redSocial;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            foreach (Usuario usuario in miRed.getUsuarios())
            {
                if (usuario == miRed.usuarioActual) continue;
                dataGridViewUsuarios.Rows.Add(usuario.id, usuario.nombre, usuario.apellido, "Modificar");
            }
            foreach(Post post in miRed.mostrarPost())
            {
                dataGridViewPost.Rows.Add(post.id, post.contenido, "Modificar");
            }
            foreach (Tag tag in miRed.mostrarTag())
            {
                dataGridViewTags.Rows.Add(tag.id, tag.palabra, "Eliminar");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionarUsuario != null && seleccionarUsuario != -1)
            {
                //int aux = int.Parse(dataGridViewUsuarios.Rows[seleccionarUsuario].Cells[0].Value.ToString());
                this.eventoUsuario(int.Parse(dataGridViewUsuarios.Rows[seleccionarUsuario].Cells[0].Value.ToString()));
                this.Close();
            }       
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            miRed.cerrarSesion();
            this.eventoLogIn();
            this.Close();
        }

        private void seleccionadorUsuario(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarUsuario = e.RowIndex;
        }

        private void seleccionadorPost(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarPost = e.RowIndex;
        }
        private void seleccionadorTag(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarTag = e.RowIndex;
        }
        private void dataGridViewPost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionarPost != null && seleccionarPost != -1)
            {
                //int aux = int.Parse(dataGridViewUsuarios.Rows[seleccionarUsuario].Cells[0].Value.ToString());
                this.eventoPost(int.Parse(dataGridViewPost.Rows[seleccionarPost].Cells[0].Value.ToString()));
                this.Close();
            }
        }

        private void eliminarTag(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionarTag != null && seleccionarTag != -1)
            {
                if (MessageBox.Show("Quiere quitar este tag?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (miRed.eliminarTag(int.Parse(dataGridViewTags.Rows[seleccionarUsuario].Cells[0].Value.ToString())))
                    {
                        dataGridViewTags.Rows.Remove(dataGridViewTags.Rows[seleccionarTag]);
                    }
                }
            }
        }
    }
}
