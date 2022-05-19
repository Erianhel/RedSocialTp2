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
    public partial class Form0 : Form
    {
        private RedSocial miRed;
        Form1 hijoLogin;
        FormMain hijoMain;
        FormAgregarAmigo hijoAgregarAmigo;
        FormPostear hijoPostear;
        FormVerPost hijoVerPost;
        FormBuscarPost hijoBuscarPost;

        bool logued;
        public Form0()
        {
            InitializeComponent();

            miRed = new RedSocial();
            logued = false;

            miRed.registrarUsuario("1", "1", "1", "1", "1");
            miRed.registrarUsuario("2", "2", "2", "2", "2");
            TransfDelegadoLogIn();
        }

        private void TransfDelegadoLogIn()
        {
            hijoLogin = new Form1(miRed, false);
            hijoLogin.MdiParent = this;
            hijoLogin.eventoEvento += TransfDelegado;
            hijoLogin.Show();
        }

        private void TransfDelegado()
        {
            hijoMain = new FormMain(miRed);
            hijoMain.MdiParent = this;
            hijoMain.eventoAgregarAmigo += TransfDelegadoAgregarAmigo;
            hijoMain.eventoPostear += TransfDelegadoCrearPost;
            hijoMain.eventoVerPost += TransfDelegadoVerPost;
            hijoMain.eventoLogIn += TransfDelegadoLogIn;
            hijoMain.eventoBuscarPost += TransfDelegadoBuscarPost;
            hijoMain.Show();
        }
        private void TransfDelegadoAgregarAmigo()
        {
            hijoAgregarAmigo = new FormAgregarAmigo(miRed);
            hijoAgregarAmigo.MdiParent = this;
            hijoAgregarAmigo.eventoMain += TransfDelegado;
            hijoAgregarAmigo.Show();
        }

        private void TransfDelegadoCrearPost()
        {
            hijoPostear = new FormPostear(miRed);
            hijoPostear.MdiParent = this;
            hijoPostear.eventoMain += TransfDelegado;
            hijoPostear.Show();
        }

        private void TransfDelegadoVerPost(int idPost)
        {
            hijoVerPost = new FormVerPost(miRed, idPost);
            hijoVerPost.MdiParent = this;
            hijoVerPost.eventoMain += TransfDelegado;
            hijoVerPost.Show();
        }
        
        private void TransfDelegadoBuscarPost()
        {
            hijoBuscarPost = new FormBuscarPost(miRed);
            hijoBuscarPost.MdiParent = this;
            hijoBuscarPost.eventoMain += TransfDelegado;
            hijoBuscarPost.eventoVerPost += TransfDelegadoVerPost;
            hijoBuscarPost.Show();
        }
    }
}
