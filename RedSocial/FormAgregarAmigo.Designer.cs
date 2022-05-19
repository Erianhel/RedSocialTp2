namespace RedSocial
{
    partial class FormAgregarAmigo
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
            this.dataGridView_Usuarios = new System.Windows.Forms.DataGridView();
            this.button_volverMenu = new System.Windows.Forms.Button();
            this.button_agregarAmigo = new System.Windows.Forms.Button();
            this.button_ayuda = new System.Windows.Forms.Button();
            this.label_ayuda = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Usuarios
            // 
            this.dataGridView_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Apellido,
            this.Mail,
            this.DNI,
            this.Id});
            this.dataGridView_Usuarios.Location = new System.Drawing.Point(12, 106);
            this.dataGridView_Usuarios.Name = "dataGridView_Usuarios";
            this.dataGridView_Usuarios.RowHeadersWidth = 35;
            this.dataGridView_Usuarios.RowTemplate.Height = 29;
            this.dataGridView_Usuarios.Size = new System.Drawing.Size(729, 532);
            this.dataGridView_Usuarios.TabIndex = 1;
            this.dataGridView_Usuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarCelda);
            // 
            // button_volverMenu
            // 
            this.button_volverMenu.Location = new System.Drawing.Point(788, 599);
            this.button_volverMenu.Name = "button_volverMenu";
            this.button_volverMenu.Size = new System.Drawing.Size(133, 29);
            this.button_volverMenu.TabIndex = 2;
            this.button_volverMenu.Text = "Volver al inicio";
            this.button_volverMenu.UseVisualStyleBackColor = true;
            this.button_volverMenu.Click += new System.EventHandler(this.button_volverMenu_Click);
            // 
            // button_agregarAmigo
            // 
            this.button_agregarAmigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_agregarAmigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_agregarAmigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_agregarAmigo.Location = new System.Drawing.Point(788, 424);
            this.button_agregarAmigo.Name = "button_agregarAmigo";
            this.button_agregarAmigo.Size = new System.Drawing.Size(133, 72);
            this.button_agregarAmigo.TabIndex = 3;
            this.button_agregarAmigo.Text = "Agregar Amigo";
            this.button_agregarAmigo.UseVisualStyleBackColor = false;
            this.button_agregarAmigo.Click += new System.EventHandler(this.button_agregarAmigo_Click);
            // 
            // button_ayuda
            // 
            this.button_ayuda.Location = new System.Drawing.Point(861, 106);
            this.button_ayuda.Name = "button_ayuda";
            this.button_ayuda.Size = new System.Drawing.Size(60, 30);
            this.button_ayuda.TabIndex = 4;
            this.button_ayuda.Text = "Ayuda";
            this.button_ayuda.UseVisualStyleBackColor = true;
            this.button_ayuda.Click += new System.EventHandler(this.button_ayuda_Click);
            // 
            // label_ayuda
            // 
            this.label_ayuda.AutoSize = true;
            this.label_ayuda.Location = new System.Drawing.Point(753, 146);
            this.label_ayuda.Name = "label_ayuda";
            this.label_ayuda.Size = new System.Drawing.Size(0, 20);
            this.label_ayuda.TabIndex = 5;
            // 
            // Name
            // 
            this.Name.HeaderText = "Nombre";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Name.Width = 173;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.Width = 173;
            // 
            // Mail
            // 
            this.Mail.HeaderText = "Mail";
            this.Mail.MinimumWidth = 6;
            this.Mail.Name = "Mail";
            this.Mail.Width = 173;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            this.DNI.Width = 173;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // FormAgregarAmigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.label_ayuda);
            this.Controls.Add(this.button_ayuda);
            this.Controls.Add(this.button_agregarAmigo);
            this.Controls.Add(this.button_volverMenu);
            this.Controls.Add(this.dataGridView_Usuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name.Name = "FormAgregarAmigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAgregarAmigo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataGridView_Usuarios;
        private Button button_volverMenu;
        private Button button_agregarAmigo;
        private Button button_ayuda;
        private Label label_ayuda;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Mail;
        private DataGridViewTextBoxColumn DNI;
        private DataGridViewTextBoxColumn Id;
    }
}