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
    public partial class FormVerPost : Form
    {
        RedSocial miRed;
        Post post;
        int comentarioSeleccionado;

        public delegate void TransfDelegado();
        public TransfDelegado eventoMain;
        public FormVerPost(RedSocial red, int idPost)
        {
            miRed = red;
            post = miRed.buscarPost(idPost);
            InitializeComponent();
            label_PostComentario.Text = post.contenido;
            foreach(Tag tag in post.tags)
            {
                dataGridView_Tags.Rows.Add(tag.palabra);
            }
            foreach(Comentario comentario in post.comentarios)
            {
                dataGridView_Comentarios.Rows.Add(comentario.id, comentario.contenido, "Modificar");
            }
            label_meGusta.Text = "Me gusta: " + post.reacciones.Count();
        }

        private void button_volverMain_Click(object sender, EventArgs e)
        {
            this.eventoMain();
            this.Close();
        }

        private void button_Comentar_Click(object sender, EventArgs e)
        {
            if(textBox_Comentar.Text != "")
            {
                Comentario comentario = new Comentario(post, miRed.usuarioActual, textBox_Comentar.Text, DateTime.Now);
                miRed.comentar(post, comentario);
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
            if(MessageBox.Show("Quiere borrar su comentario?",
                "Mensaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes){
                miRed.quitarComentario(post.id, int.Parse(dataGridView_Comentarios.Rows[comentarioSeleccionado].Cells[0].Value.ToString()));
                dataGridView_Comentarios.Rows.Remove(dataGridView_Comentarios.Rows[comentarioSeleccionado]);
            }
            else
            {
                string nuevoComentario = Interaction.InputBox("Ingrese el replazo de comentario:");
                miRed.modificarComentario(int.Parse(dataGridView_Comentarios.Rows[comentarioSeleccionado].Cells[0].Value.ToString()),nuevoComentario);
                dataGridView_Comentarios.Rows[comentarioSeleccionado].Cells[1].Value = nuevoComentario;
            }
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            string nuevoContenido = Interaction.InputBox("Ingrese el replazo del contenido:");
            miRed.modificarPost(post.id,nuevoContenido);
            label_PostComentario.Text = nuevoContenido;
            
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quiere borrar su Post?",
                "Mensaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (miRed.eliminarPost(post.id))
                {
                    this.eventoMain();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usted no es dueño del post",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonMeGusta_Click(object sender, EventArgs e)
        {
            miRed.reaccionar(post.id,1, miRed.usuarioActual);
            label_meGusta.Text = "Me gusta: " + post.reacciones.Count;
            //buttonMeGusta.Click -= buttonMeGusta_Click;
            //buttonMeGusta.Click += buttonNoMeGusta;
        }

        private void buttonNoMeGusta(object sender, EventArgs e)
        {
            miRed.quitarReaccion(post.id);
            label_meGusta.Text = "Me gusta: " + post.reacciones.Count;
            //buttonMeGusta.Click -= buttonNoMeGusta;
            //buttonMeGusta.Click += buttonMeGusta_Click;
        }
    }
}
