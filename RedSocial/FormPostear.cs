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
    public partial class FormPostear : Form
    {
        RedSocial miRed;
        int tagSeleccionado;


        public delegate void TransfDelegado();
        public TransfDelegado eventoMain;
        public FormPostear(RedSocial red)
        {   
            miRed = red;
            InitializeComponent();
        }

        private void VolverAMenu_Click(object sender, EventArgs e)
        {
            this.eventoMain();
            this.Close();
        }

        private void button_agregarTag_Click(object sender, EventArgs e)
        {
            if(textBox_Tags.Text != "")
            {
                dataGridView_Tags.Rows.Add(textBox_Tags.Text, "Eliminar");
                textBox_Tags.Text = "";
            }
        }
        private void eliminarTag(object sender, DataGridViewCellEventArgs e)
        {
            if (tagSeleccionado != null && tagSeleccionado != -1)
            {
                if (MessageBox.Show("Quiere quitar este tag?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataGridView_Tags.Rows.Remove(dataGridView_Tags.Rows[tagSeleccionado]);
                }
            }
        }
        private void seleccionarTag(object sender, DataGridViewCellEventArgs e)
        {
            tagSeleccionado = e.RowIndex;
        }

        private void Postear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quiere publicar como esta el post?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Tag> tags = new List<Tag>();
                for (int i = 0; i < dataGridView_Tags.Rows.Count-1; i++)
                {
                    tags.Add(new Tag(dataGridView_Tags.Rows[i].Cells[0].Value.ToString()));
                }
                Post post = new Post(miRed.mostrarDatos(), textBox_publicacion.Text, DateTime.Now);
                miRed.postear(post,tags);
                this.eventoMain();
                this.Close();
            }
        }
    }
}
