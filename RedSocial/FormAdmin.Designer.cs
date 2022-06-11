namespace RedSocial
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewPost = new System.Windows.Forms.DataGridView();
            this.idPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContenidoPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccionPost = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.buttonOut = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPost)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 91);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewUsuarios);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(918, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Apellido,
            this.Accion});
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(3, 2);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowHeadersWidth = 51;
            this.dataGridViewUsuarios.RowTemplate.Height = 29;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(912, 501);
            this.dataGridViewUsuarios.TabIndex = 0;
            this.dataGridViewUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionadorUsuario);
            this.dataGridViewUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Id.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 225;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.Width = 225;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.MinimumWidth = 6;
            this.Accion.Name = "Accion";
            this.Accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Accion.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewPost);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(918, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Posteos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPost
            // 
            this.dataGridViewPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPost,
            this.ContenidoPost,
            this.AccionPost});
            this.dataGridViewPost.Location = new System.Drawing.Point(2, 1);
            this.dataGridViewPost.Name = "dataGridViewPost";
            this.dataGridViewPost.RowHeadersWidth = 51;
            this.dataGridViewPost.RowTemplate.Height = 29;
            this.dataGridViewPost.Size = new System.Drawing.Size(913, 502);
            this.dataGridViewPost.TabIndex = 0;
            this.dataGridViewPost.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPost_CellContentClick);
            // 
            // idPost
            // 
            this.idPost.HeaderText = "id";
            this.idPost.MinimumWidth = 6;
            this.idPost.Name = "idPost";
            this.idPost.Width = 50;
            // 
            // ContenidoPost
            // 
            this.ContenidoPost.HeaderText = "Contenido";
            this.ContenidoPost.MinimumWidth = 6;
            this.ContenidoPost.Name = "ContenidoPost";
            this.ContenidoPost.Width = 425;
            // 
            // AccionPost
            // 
            this.AccionPost.HeaderText = "Accion";
            this.AccionPost.MinimumWidth = 6;
            this.AccionPost.Name = "AccionPost";
            this.AccionPost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AccionPost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AccionPost.Width = 125;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUsuario.Location = new System.Drawing.Point(19, 15);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(235, 46);
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Usuario admin";
            // 
            // buttonOut
            // 
            this.buttonOut.Location = new System.Drawing.Point(829, 15);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(94, 29);
            this.buttonOut.TabIndex = 2;
            this.buttonOut.Text = "Cerrar Sesion";
            this.buttonOut.UseVisualStyleBackColor = true;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 651);
            this.Controls.Add(this.buttonOut);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdmin";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label labelUsuario;
        private DataGridView dataGridViewUsuarios;
        private Button buttonOut;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewButtonColumn Accion;
        private DataGridView dataGridViewPost;
        private DataGridViewTextBoxColumn idPost;
        private DataGridViewTextBoxColumn ContenidoPost;
        private DataGridViewButtonColumn AccionPost;
    }
}