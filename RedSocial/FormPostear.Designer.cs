namespace RedSocial
{
    partial class FormPostear
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
            this.VolverAMenu = new System.Windows.Forms.Button();
            this.Postear = new System.Windows.Forms.Button();
            this.textBox_publicacion = new System.Windows.Forms.TextBox();
            this.Publicacion = new System.Windows.Forms.Label();
            this.Tags = new System.Windows.Forms.Label();
            this.textBox_Tags = new System.Windows.Forms.TextBox();
            this.dataGridView_Tags = new System.Windows.Forms.DataGridView();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label_listaTags = new System.Windows.Forms.Label();
            this.button_agregarTag = new System.Windows.Forms.Button();
            this.nombreUsuarioActual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).BeginInit();
            this.SuspendLayout();
            // 
            // VolverAMenu
            // 
            this.VolverAMenu.Location = new System.Drawing.Point(35, 592);
            this.VolverAMenu.Name = "VolverAMenu";
            this.VolverAMenu.Size = new System.Drawing.Size(124, 29);
            this.VolverAMenu.TabIndex = 0;
            this.VolverAMenu.Text = "Volver a menu";
            this.VolverAMenu.UseVisualStyleBackColor = true;
            this.VolverAMenu.Click += new System.EventHandler(this.VolverAMenu_Click);
            // 
            // Postear
            // 
            this.Postear.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Postear.Location = new System.Drawing.Point(786, 578);
            this.Postear.Name = "Postear";
            this.Postear.Size = new System.Drawing.Size(107, 43);
            this.Postear.TabIndex = 1;
            this.Postear.Text = "Postear";
            this.Postear.UseVisualStyleBackColor = true;
            this.Postear.Click += new System.EventHandler(this.Postear_Click);
            // 
            // textBox_publicacion
            // 
            this.textBox_publicacion.Location = new System.Drawing.Point(35, 135);
            this.textBox_publicacion.Multiline = true;
            this.textBox_publicacion.Name = "textBox_publicacion";
            this.textBox_publicacion.Size = new System.Drawing.Size(353, 60);
            this.textBox_publicacion.TabIndex = 2;
            // 
            // Publicacion
            // 
            this.Publicacion.AutoSize = true;
            this.Publicacion.Location = new System.Drawing.Point(35, 103);
            this.Publicacion.Name = "Publicacion";
            this.Publicacion.Size = new System.Drawing.Size(85, 20);
            this.Publicacion.TabIndex = 3;
            this.Publicacion.Text = "Publicacion";
            // 
            // Tags
            // 
            this.Tags.AutoSize = true;
            this.Tags.Location = new System.Drawing.Point(37, 213);
            this.Tags.Name = "Tags";
            this.Tags.Size = new System.Drawing.Size(38, 20);
            this.Tags.TabIndex = 4;
            this.Tags.Text = "Tags";
            // 
            // textBox_Tags
            // 
            this.textBox_Tags.Location = new System.Drawing.Point(37, 249);
            this.textBox_Tags.Name = "textBox_Tags";
            this.textBox_Tags.Size = new System.Drawing.Size(353, 27);
            this.textBox_Tags.TabIndex = 5;
            // 
            // dataGridView_Tags
            // 
            this.dataGridView_Tags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Tags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tag,
            this.Eliminar});
            this.dataGridView_Tags.Location = new System.Drawing.Point(478, 103);
            this.dataGridView_Tags.Name = "dataGridView_Tags";
            this.dataGridView_Tags.RowHeadersVisible = false;
            this.dataGridView_Tags.RowHeadersWidth = 51;
            this.dataGridView_Tags.RowTemplate.Height = 29;
            this.dataGridView_Tags.Size = new System.Drawing.Size(415, 414);
            this.dataGridView_Tags.TabIndex = 6;
            this.dataGridView_Tags.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarTag);
            this.dataGridView_Tags.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eliminarTag);
            // 
            // Tag
            // 
            this.Tag.HeaderText = "Tag";
            this.Tag.MinimumWidth = 6;
            this.Tag.Name = "Tag";
            this.Tag.Width = 340;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 70;
            // 
            // label_listaTags
            // 
            this.label_listaTags.AutoSize = true;
            this.label_listaTags.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_listaTags.Location = new System.Drawing.Point(781, 62);
            this.label_listaTags.Name = "label_listaTags";
            this.label_listaTags.Size = new System.Drawing.Size(112, 25);
            this.label_listaTags.TabIndex = 7;
            this.label_listaTags.Text = "Lista de Tags";
            // 
            // button_agregarTag
            // 
            this.button_agregarTag.Location = new System.Drawing.Point(40, 299);
            this.button_agregarTag.Name = "button_agregarTag";
            this.button_agregarTag.Size = new System.Drawing.Size(119, 29);
            this.button_agregarTag.TabIndex = 8;
            this.button_agregarTag.Text = "Agregar Tag";
            this.button_agregarTag.UseVisualStyleBackColor = true;
            this.button_agregarTag.Click += new System.EventHandler(this.button_agregarTag_Click);
            // 
            // nombreUsuarioActual
            // 
            this.nombreUsuarioActual.AutoSize = true;
            this.nombreUsuarioActual.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nombreUsuarioActual.Location = new System.Drawing.Point(12, 9);
            this.nombreUsuarioActual.Name = "nombreUsuarioActual";
            this.nombreUsuarioActual.Size = new System.Drawing.Size(175, 46);
            this.nombreUsuarioActual.TabIndex = 9;
            this.nombreUsuarioActual.Text = "Crear post";
            // 
            // FormPostear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.nombreUsuarioActual);
            this.Controls.Add(this.button_agregarTag);
            this.Controls.Add(this.label_listaTags);
            this.Controls.Add(this.dataGridView_Tags);
            this.Controls.Add(this.textBox_Tags);
            this.Controls.Add(this.Tags);
            this.Controls.Add(this.Publicacion);
            this.Controls.Add(this.textBox_publicacion);
            this.Controls.Add(this.Postear);
            this.Controls.Add(this.VolverAMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPostear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPostear";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button VolverAMenu;
        private Button Postear;
        private TextBox textBox_publicacion;
        private Label Publicacion;
        private Label Tags;
        private TextBox textBox_Tags;
        private DataGridView dataGridView_Tags;
        private Label label_listaTags;
        private Button button_agregarTag;
        private Label nombreUsuarioActual;
        private DataGridViewTextBoxColumn Tag;
        private DataGridViewButtonColumn Eliminar;
    }
}