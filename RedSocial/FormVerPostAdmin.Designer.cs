namespace RedSocial
{
    partial class FormVerPostAdmin
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
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_volverMain = new System.Windows.Forms.Button();
            this.dataGridView_Comentarios = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_Comentar = new System.Windows.Forms.Button();
            this.textBox_Comentar = new System.Windows.Forms.TextBox();
            this.label_PostComentario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comentarios)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(824, 604);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(94, 29);
            this.buttonEliminar.TabIndex = 21;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(627, 604);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(94, 29);
            this.button_modificar.TabIndex = 20;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // button_volverMain
            // 
            this.button_volverMain.Location = new System.Drawing.Point(32, 604);
            this.button_volverMain.Name = "button_volverMain";
            this.button_volverMain.Size = new System.Drawing.Size(115, 29);
            this.button_volverMain.TabIndex = 19;
            this.button_volverMain.Text = "Volver Inicio";
            this.button_volverMain.UseVisualStyleBackColor = true;
            this.button_volverMain.Click += new System.EventHandler(this.button_volverMainAdmin_Click);
            // 
            // dataGridView_Comentarios
            // 
            this.dataGridView_Comentarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Comentarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Comentarios,
            this.Modificar});
            this.dataGridView_Comentarios.Location = new System.Drawing.Point(57, 207);
            this.dataGridView_Comentarios.Name = "dataGridView_Comentarios";
            this.dataGridView_Comentarios.RowHeadersVisible = false;
            this.dataGridView_Comentarios.RowHeadersWidth = 51;
            this.dataGridView_Comentarios.RowTemplate.Height = 29;
            this.dataGridView_Comentarios.Size = new System.Drawing.Size(861, 369);
            this.dataGridView_Comentarios.TabIndex = 16;
            this.dataGridView_Comentarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectorComentario);
            this.dataGridView_Comentarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Comentarios_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 40;
            // 
            // Comentarios
            // 
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.MinimumWidth = 6;
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.Width = 365;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.MinimumWidth = 6;
            this.Modificar.Name = "Modificar";
            this.Modificar.Width = 77;
            // 
            // button_Comentar
            // 
            this.button_Comentar.Location = new System.Drawing.Point(824, 145);
            this.button_Comentar.Name = "button_Comentar";
            this.button_Comentar.Size = new System.Drawing.Size(94, 29);
            this.button_Comentar.TabIndex = 15;
            this.button_Comentar.Text = "Comentar";
            this.button_Comentar.UseVisualStyleBackColor = true;
            this.button_Comentar.Click += new System.EventHandler(this.button_Comentar_Click);
            // 
            // textBox_Comentar
            // 
            this.textBox_Comentar.Location = new System.Drawing.Point(68, 145);
            this.textBox_Comentar.Name = "textBox_Comentar";
            this.textBox_Comentar.Size = new System.Drawing.Size(732, 27);
            this.textBox_Comentar.TabIndex = 14;
            // 
            // label_PostComentario
            // 
            this.label_PostComentario.AutoSize = true;
            this.label_PostComentario.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_PostComentario.Location = new System.Drawing.Point(42, 17);
            this.label_PostComentario.Name = "label_PostComentario";
            this.label_PostComentario.Size = new System.Drawing.Size(347, 45);
            this.label_PostComentario.TabIndex = 13;
            this.label_PostComentario.Text = "COmentario de posteo";
            // 
            // FormVerPostAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_volverMain);
            this.Controls.Add(this.dataGridView_Comentarios);
            this.Controls.Add(this.button_Comentar);
            this.Controls.Add(this.textBox_Comentar);
            this.Controls.Add(this.label_PostComentario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVerPostAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVerPostAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comentarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonEliminar;
        private Button button_modificar;
        private Button button_volverMain;
        private DataGridView dataGridView_Comentarios;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Comentarios;
        private DataGridViewButtonColumn Modificar;
        private Button button_Comentar;
        private TextBox textBox_Comentar;
        private Label label_PostComentario;
    }
}