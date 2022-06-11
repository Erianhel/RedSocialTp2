using Microsoft.VisualBasic;
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
    public partial class FormVerPostAdmin : Form
    {
        RedSocial miRed;
        Post post;

        int comentarioSeleccionado;

        public delegate void TransfDelegadoAdmin();
        public TransfDelegadoAdmin eventoAdmin;

        public FormVerPostAdmin(RedSocial red, int idPost)
        {
            miRed = red;
            post = miRed.buscarPost(idPost);
            InitializeComponent();
            label_PostComentario.Text = post.contenido;            
            foreach (Comentario comentario in post.comentarios)
            {
                dataGridView_Comentarios.Rows.Add(comentario.id, comentario.contenido, "Modificar");
            }
        }

        private void button_volverMainAdmin_Click(object sender, EventArgs e)
        {
            this.eventoAdmin();
            this.Close();
        }

        private void button_Comentar_Click(object sender, EventArgs e)
        {
            if (textBox_Comentar.Text != "")
            {
                Comentario comentario = new Comentario(DateTime.Now, textBox_Comentar.Text, miRed.usuarioActual.id, post.id);
                miRed.comentar(post.id, textBox_Comentar.Text, DateTime.Now);
                dataGridView_Comentarios.Rows.Add(comentario.id, comentario.contenido, "Modificar");
                textBox_Comentar.Text = "";
            }
        }

        private void selectorComentario(object sender, DataGridViewCellEventArgs e)
        {
            comentarioSeleccionado = e.RowIndex;
        }

        private void dataGridView_Comentarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Quiere borrar su comentario?",
                "Mensaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                miRed.quitarComentario(post.id, int.Parse(dataGridView_Comentarios.Rows[comentarioSeleccionado].Cells[0].Value.ToString()));
                dataGridView_Comentarios.Rows.Remove(dataGridView_Comentarios.Rows[comentarioSeleccionado]);
            }
            else
            {
                string nuevoComentario = Interaction.InputBox("Ingrese el replazo de comentario:");
                if (nuevoComentario == null)
                {
                    miRed.modificarComentario(int.Parse(dataGridView_Comentarios.Rows[comentarioSeleccionado].Cells[0].Value.ToString()), nuevoComentario);
                    dataGridView_Comentarios.Rows[comentarioSeleccionado].Cells[1].Value = nuevoComentario;
                }
            }
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            string nuevoContenido = Interaction.InputBox("Ingrese el replazo del contenido:");
            if(nuevoContenido == null)
            {
                miRed.modificarPost(post.id, nuevoContenido);
                label_PostComentario.Text = nuevoContenido;
            }
         
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quiere borrar su Post?",
                "Mensaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                miRed.eliminarPost(post.id);
                this.eventoAdmin();
                this.Close();
            }
        }
    }
}
