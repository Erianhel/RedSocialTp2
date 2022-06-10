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

        public delegate void TransfDelegadoLogIn();
        public TransfDelegadoLogIn eventoLogIn;

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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            miRed.cerrarSesion();
            this.eventoLogIn();
            this.Close();
        }
    }
}
