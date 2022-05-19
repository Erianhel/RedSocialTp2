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
    public partial class FormBuscarPost : Form
    {
        RedSocial miRed;
        int tagSeleccionado;
        int seleccionarAmigo;

        public delegate void TransfDelegado();
        public TransfDelegado eventoMain;

        public delegate void TransfDelegadoVerPost(int idPost);
        public TransfDelegadoVerPost eventoVerPost;

        public FormBuscarPost(RedSocial red)
        {
            miRed = red;
            InitializeComponent();
        }

        private void button_agrgarTag_Click(object sender, EventArgs e)
        {
            if (textBox_Tags.Text != "")
            {
                dataGridView_TagsBusqueda.Rows.Add(textBox_Tags.Text, "Eliminar");
                textBox_Tags.Text = "";
            }
        }

        private void button_FormMain_Click(object sender, EventArgs e)
        {
            this.eventoMain();
            this.Close();
        }

        private void eliminarTag(object sender, DataGridViewCellEventArgs e)
        {
            
                if (MessageBox.Show("Quiere quitar este tag?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataGridView_TagsBusqueda.Rows.Remove(dataGridView_TagsBusqueda.Rows[tagSeleccionado]);
                }
            
        }
        private void seleccionarTag(object sender, DataGridViewCellEventArgs e)
        {
            tagSeleccionado = e.RowIndex;
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            string comentario = textBox_Comentario.Text;
            DateTime desde = dateTimePicker_Desde.Value;
            DateTime hasta = dateTimePicker_Hasta.Value;
            List<Tag> tags = new List<Tag>();
            for (int i = 0; i < dataGridView_TagsBusqueda.Rows.Count - 1; i++)
            {
                tags.Add(new Tag(dataGridView_TagsBusqueda.Rows[i].Cells[0].Value.ToString()));
            }
            List<Post> encontrado = miRed.buscarPosts(comentario, desde, hasta, tags);
            foreach (Post post in encontrado)
            {
                dataGridView_PosteosRed.Rows.Add(post.id, post.contenido, "Ver Post");
            }
        }
        private void VerPost(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionarAmigo != null && seleccionarAmigo != -1)
            {
                this.eventoVerPost(int.Parse(dataGridView_PosteosRed.Rows[seleccionarAmigo].Cells[0].Value.ToString()));
                this.Close();
            }
        }
        private void seleccionadorAmigo(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarAmigo = e.RowIndex;
        }
    }
}
