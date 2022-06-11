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
    public partial class FormUsuario : Form
    {
        RedSocial miRedSocial;
        Usuario usuario;

        public delegate void TransfDelegadoAdmin();
        public TransfDelegadoAdmin eventoAdmin;
        public FormUsuario(RedSocial redSocial,int idUsuario)
        {
            miRedSocial = redSocial;
            InitializeComponent();
            usuario = miRedSocial.getUsuario(idUsuario);
        }
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            textBox_NombreReg.Text = usuario.nombre;
            textBox_apellidoRegistro.Text = usuario.apellido;
            textBox_DNIReg.Text = usuario.dni;
            textBox_MailReg.Text = usuario.mail;
            checkBoxBloqueado.Checked = usuario.bloqueado;
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.eventoAdmin();
            this.Close();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            miRedSocial.modificarUsuario(usuario.id,
                textBox_DNIReg.Text,
                textBox_NombreReg.Text,
                textBox_apellidoRegistro.Text,
                textBox_MailReg.Text,
                usuario.pass,
                usuario.esAdmin,
                checkBoxBloqueado.Checked,
                usuario.intentosFallidos);
            this.eventoAdmin();
            this.Close();
        }
    }
}
