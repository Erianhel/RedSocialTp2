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
            this.textBox_Comentario = new System.Windows.Forms.TextBox();
            this.button_Comentar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label_tags = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.VolverMain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label_PostComentario
            // 
            this.label_PostComentario.AutoSize = true;
            this.label_PostComentario.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_PostComentario.Location = new System.Drawing.Point(37, 24);
            this.label_PostComentario.Name = "label_PostComentario";
            this.label_PostComentario.Size = new System.Drawing.Size(347, 45);
            this.label_PostComentario.TabIndex = 0;
            this.label_PostComentario.Text = "COmentario de posteo";
            // 
            // textBox_Comentario
            // 
            this.textBox_Comentario.Location = new System.Drawing.Point(48, 150);
            this.textBox_Comentario.Name = "textBox_Comentario";
            this.textBox_Comentario.Size = new System.Drawing.Size(344, 27);
            this.textBox_Comentario.TabIndex = 1;
            // 
            // button_Comentar
            // 
            this.button_Comentar.Location = new System.Drawing.Point(420, 150);
            this.button_Comentar.Name = "button_Comentar";
            this.button_Comentar.Size = new System.Drawing.Size(94, 29);
            this.button_Comentar.TabIndex = 2;
            this.button_Comentar.Text = "Comentar";
            this.button_Comentar.UseVisualStyleBackColor = true;
            this.button_Comentar.Click += new System.EventHandler(this.buttonComentar);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Comentarios,
            this.Eliminar});
            this.dataGridView1.Location = new System.Drawing.Point(37, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(477, 369);
            this.dataGridView1.TabIndex = 3;
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
            this.Comentarios.Width = 125;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 125;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(598, 55);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(300, 398);
            this.dataGridView2.TabIndex = 4;
            // 
            // label_tags
            // 
            this.label_tags.AutoSize = true;
            this.label_tags.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_tags.Location = new System.Drawing.Point(780, 24);
            this.label_tags.Name = "label_tags";
            this.label_tags.Size = new System.Drawing.Size(118, 28);
            this.label_tags.TabIndex = 5;
            this.label_tags.Text = "Tag del post";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(598, 474);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // VolverMain
            // 
            this.VolverMain.Location = new System.Drawing.Point(37, 609);
            this.VolverMain.Name = "VolverMain";
            this.VolverMain.Size = new System.Drawing.Size(119, 29);
            this.VolverMain.TabIndex = 7;
            this.VolverMain.Text = "Volver al inicio";
            this.VolverMain.UseVisualStyleBackColor = true;
            // 
            // FormVerPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.VolverMain);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_tags);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_Comentar);
            this.Controls.Add(this.textBox_Comentario);
            this.Controls.Add(this.label_PostComentario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVerPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVerPost";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_PostComentario;
        private TextBox textBox_Comentario;
        private Button button_Comentar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Comentarios;
        private DataGridViewButtonColumn Eliminar;
        private DataGridView dataGridView2;
        private Label label_tags;
        private Button button2;
        private Button VolverMain;
    }
}