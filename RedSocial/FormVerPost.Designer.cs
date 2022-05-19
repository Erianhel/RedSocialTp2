namespace RedSocial
{
    partial class FormVerPost
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
            this.label_PostComentario = new System.Windows.Forms.Label();
            this.textBox_Comentar = new System.Windows.Forms.TextBox();
            this.button_Comentar = new System.Windows.Forms.Button();
            this.dataGridView_Comentarios = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView_Tags = new System.Windows.Forms.DataGridView();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_listaTag = new System.Windows.Forms.Label();
            this.button_volverMain = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonMeGusta = new System.Windows.Forms.Button();
            this.label_meGusta = new System.Windows.Forms.Label();
            this.button_QuitarMegusta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comentarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).BeginInit();
            this.SuspendLayout();
            // 
            // label_PostComentario
            // 
            this.label_PostComentario.AutoSize = true;
            this.label_PostComentario.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_PostComentario.Location = new System.Drawing.Point(22, 22);
            this.label_PostComentario.Name = "label_PostComentario";
            this.label_PostComentario.Size = new System.Drawing.Size(347, 45);
            this.label_PostComentario.TabIndex = 0;
            this.label_PostComentario.Text = "COmentario de posteo";
            // 
            // textBox_Comentar
            // 
            this.textBox_Comentar.Location = new System.Drawing.Point(48, 150);
            this.textBox_Comentar.Name = "textBox_Comentar";
            this.textBox_Comentar.Size = new System.Drawing.Size(344, 27);
            this.textBox_Comentar.TabIndex = 1;
            // 
            // button_Comentar
            // 
            this.button_Comentar.Location = new System.Drawing.Point(420, 150);
            this.button_Comentar.Name = "button_Comentar";
            this.button_Comentar.Size = new System.Drawing.Size(94, 29);
            this.button_Comentar.TabIndex = 2;
            this.button_Comentar.Text = "Comentar";
            this.button_Comentar.UseVisualStyleBackColor = true;
            this.button_Comentar.Click += new System.EventHandler(this.button_Comentar_Click);
            // 
            // dataGridView_Comentarios
            // 
            this.dataGridView_Comentarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Comentarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Comentarios,
            this.Modificar});
            this.dataGridView_Comentarios.Location = new System.Drawing.Point(37, 212);
            this.dataGridView_Comentarios.Name = "dataGridView_Comentarios";
            this.dataGridView_Comentarios.RowHeadersVisible = false;
            this.dataGridView_Comentarios.RowHeadersWidth = 51;
            this.dataGridView_Comentarios.RowTemplate.Height = 29;
            this.dataGridView_Comentarios.Size = new System.Drawing.Size(477, 369);
            this.dataGridView_Comentarios.TabIndex = 3;
            this.dataGridView_Comentarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectorComentario);
            this.dataGridView_Comentarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Comentarios_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // Comentarios
            // 
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.MinimumWidth = 6;
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.Width = 395;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.MinimumWidth = 6;
            this.Modificar.Name = "Modificar";
            this.Modificar.Width = 77;
            // 
            // dataGridView_Tags
            // 
            this.dataGridView_Tags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Tags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tag});
            this.dataGridView_Tags.Location = new System.Drawing.Point(598, 80);
            this.dataGridView_Tags.Name = "dataGridView_Tags";
            this.dataGridView_Tags.RowHeadersWidth = 51;
            this.dataGridView_Tags.RowTemplate.Height = 29;
            this.dataGridView_Tags.Size = new System.Drawing.Size(300, 398);
            this.dataGridView_Tags.TabIndex = 4;
            // 
            // Tag
            // 
            this.Tag.HeaderText = "Tag";
            this.Tag.MinimumWidth = 6;
            this.Tag.Name = "Tag";
            this.Tag.Width = 240;
            // 
            // label_listaTag
            // 
            this.label_listaTag.AutoSize = true;
            this.label_listaTag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_listaTag.Location = new System.Drawing.Point(848, 49);
            this.label_listaTag.Name = "label_listaTag";
            this.label_listaTag.Size = new System.Drawing.Size(50, 28);
            this.label_listaTag.TabIndex = 5;
            this.label_listaTag.Text = "Tags";
            // 
            // button_volverMain
            // 
            this.button_volverMain.Location = new System.Drawing.Point(12, 609);
            this.button_volverMain.Name = "button_volverMain";
            this.button_volverMain.Size = new System.Drawing.Size(115, 29);
            this.button_volverMain.TabIndex = 7;
            this.button_volverMain.Text = "Volver Inicio";
            this.button_volverMain.UseVisualStyleBackColor = true;
            this.button_volverMain.Click += new System.EventHandler(this.button_volverMain_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(607, 609);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(94, 29);
            this.button_modificar.TabIndex = 8;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(804, 609);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(94, 29);
            this.buttonEliminar.TabIndex = 9;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonMeGusta
            // 
            this.buttonMeGusta.Location = new System.Drawing.Point(607, 484);
            this.buttonMeGusta.Name = "buttonMeGusta";
            this.buttonMeGusta.Size = new System.Drawing.Size(124, 29);
            this.buttonMeGusta.TabIndex = 10;
            this.buttonMeGusta.Text = "Me Gusta";
            this.buttonMeGusta.UseVisualStyleBackColor = true;
            this.buttonMeGusta.Click += new System.EventHandler(this.buttonMeGusta_Click);
            // 
            // label_meGusta
            // 
            this.label_meGusta.AutoSize = true;
            this.label_meGusta.Location = new System.Drawing.Point(773, 507);
            this.label_meGusta.Name = "label_meGusta";
            this.label_meGusta.Size = new System.Drawing.Size(77, 20);
            this.label_meGusta.TabIndex = 11;
            this.label_meGusta.Text = "Me gusta: ";
            // 
            // button_QuitarMegusta
            // 
            this.button_QuitarMegusta.Location = new System.Drawing.Point(607, 519);
            this.button_QuitarMegusta.Name = "button_QuitarMegusta";
            this.button_QuitarMegusta.Size = new System.Drawing.Size(124, 29);
            this.button_QuitarMegusta.TabIndex = 12;
            this.button_QuitarMegusta.Text = "Ya no me gusta";
            this.button_QuitarMegusta.UseVisualStyleBackColor = true;
            this.button_QuitarMegusta.Click += new System.EventHandler(this.buttonNoMeGusta);
            // 
            // FormVerPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.button_QuitarMegusta);
            this.Controls.Add(this.label_meGusta);
            this.Controls.Add(this.buttonMeGusta);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_volverMain);
            this.Controls.Add(this.label_listaTag);
            this.Controls.Add(this.dataGridView_Tags);
            this.Controls.Add(this.dataGridView_Comentarios);
            this.Controls.Add(this.button_Comentar);
            this.Controls.Add(this.textBox_Comentar);
            this.Controls.Add(this.label_PostComentario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVerPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVerPost";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comentarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_PostComentario;
        private TextBox textBox_Comentar;
        private Button button_Comentar;
        private DataGridView dataGridView_Comentarios;
        private DataGridView dataGridView_Tags;
        private Label label_listaTag;
        private Button button_volverMain;
        private DataGridViewTextBoxColumn Tag;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Comentarios;
        private DataGridViewButtonColumn Modificar;
        private Button button_modificar;
        private Button buttonEliminar;
        private Button buttonMeGusta;
        private Label label_meGusta;
        private Button button_QuitarMegusta;
    }
}