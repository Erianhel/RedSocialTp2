namespace RedSocial
{
    partial class FormBuscarPost
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
            this.button_agrgarTag = new System.Windows.Forms.Button();
            this.textBox_Comentario = new System.Windows.Forms.TextBox();
            this.label_Comentario = new System.Windows.Forms.Label();
            this.dateTimePicker_Desde = new System.Windows.Forms.DateTimePicker();
            this.label_Desde = new System.Windows.Forms.Label();
            this.label_Hasta = new System.Windows.Forms.Label();
            this.dateTimePicker_Hasta = new System.Windows.Forms.DateTimePicker();
            this.label_Tags = new System.Windows.Forms.Label();
            this.textBox_Tags = new System.Windows.Forms.TextBox();
            this.dataGridView_TagsBusqueda = new System.Windows.Forms.DataGridView();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EliminarBusqueda = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.dataGridView_PosteosRed = new System.Windows.Forms.DataGridView();
            this.idPosteos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_FormMain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TagsBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PosteosRed)).BeginInit();
            this.SuspendLayout();
            // 
            // button_agrgarTag
            // 
            this.button_agrgarTag.Location = new System.Drawing.Point(203, 197);
            this.button_agrgarTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_agrgarTag.Name = "button_agrgarTag";
            this.button_agrgarTag.Size = new System.Drawing.Size(96, 25);
            this.button_agrgarTag.TabIndex = 0;
            this.button_agrgarTag.Text = "Agregar Tag";
            this.button_agrgarTag.UseVisualStyleBackColor = true;
            this.button_agrgarTag.Click += new System.EventHandler(this.button_agrgarTag_Click);
            // 
            // textBox_Comentario
            // 
            this.textBox_Comentario.Location = new System.Drawing.Point(38, 34);
            this.textBox_Comentario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Comentario.Name = "textBox_Comentario";
            this.textBox_Comentario.Size = new System.Drawing.Size(260, 23);
            this.textBox_Comentario.TabIndex = 1;
            // 
            // label_Comentario
            // 
            this.label_Comentario.AutoSize = true;
            this.label_Comentario.Location = new System.Drawing.Point(38, 17);
            this.label_Comentario.Name = "label_Comentario";
            this.label_Comentario.Size = new System.Drawing.Size(63, 15);
            this.label_Comentario.TabIndex = 2;
            this.label_Comentario.Text = "Contenido";
            // 
            // dateTimePicker_Desde
            // 
            this.dateTimePicker_Desde.Location = new System.Drawing.Point(38, 84);
            this.dateTimePicker_Desde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker_Desde.Name = "dateTimePicker_Desde";
            this.dateTimePicker_Desde.Size = new System.Drawing.Size(260, 23);
            this.dateTimePicker_Desde.TabIndex = 3;
            // 
            // label_Desde
            // 
            this.label_Desde.AutoSize = true;
            this.label_Desde.Location = new System.Drawing.Point(38, 67);
            this.label_Desde.Name = "label_Desde";
            this.label_Desde.Size = new System.Drawing.Size(39, 15);
            this.label_Desde.TabIndex = 4;
            this.label_Desde.Text = "Desde";
            // 
            // label_Hasta
            // 
            this.label_Hasta.AutoSize = true;
            this.label_Hasta.Location = new System.Drawing.Point(38, 119);
            this.label_Hasta.Name = "label_Hasta";
            this.label_Hasta.Size = new System.Drawing.Size(37, 15);
            this.label_Hasta.TabIndex = 6;
            this.label_Hasta.Text = "Hasta";
            // 
            // dateTimePicker_Hasta
            // 
            this.dateTimePicker_Hasta.Location = new System.Drawing.Point(38, 136);
            this.dateTimePicker_Hasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker_Hasta.Name = "dateTimePicker_Hasta";
            this.dateTimePicker_Hasta.Size = new System.Drawing.Size(260, 23);
            this.dateTimePicker_Hasta.TabIndex = 5;
            // 
            // label_Tags
            // 
            this.label_Tags.AutoSize = true;
            this.label_Tags.Location = new System.Drawing.Point(38, 182);
            this.label_Tags.Name = "label_Tags";
            this.label_Tags.Size = new System.Drawing.Size(30, 15);
            this.label_Tags.TabIndex = 8;
            this.label_Tags.Text = "Tags";
            // 
            // textBox_Tags
            // 
            this.textBox_Tags.Location = new System.Drawing.Point(38, 200);
            this.textBox_Tags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Tags.Name = "textBox_Tags";
            this.textBox_Tags.Size = new System.Drawing.Size(161, 23);
            this.textBox_Tags.TabIndex = 7;
            // 
            // dataGridView_TagsBusqueda
            // 
            this.dataGridView_TagsBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TagsBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tag,
            this.EliminarBusqueda});
            this.dataGridView_TagsBusqueda.Location = new System.Drawing.Point(38, 238);
            this.dataGridView_TagsBusqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_TagsBusqueda.Name = "dataGridView_TagsBusqueda";
            this.dataGridView_TagsBusqueda.RowHeadersVisible = false;
            this.dataGridView_TagsBusqueda.RowHeadersWidth = 51;
            this.dataGridView_TagsBusqueda.RowTemplate.Height = 29;
            this.dataGridView_TagsBusqueda.Size = new System.Drawing.Size(259, 158);
            this.dataGridView_TagsBusqueda.TabIndex = 9;
            this.dataGridView_TagsBusqueda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarTag);
            this.dataGridView_TagsBusqueda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eliminarTag);
            // 
            // Tag
            // 
            this.Tag.HeaderText = "Tag";
            this.Tag.MinimumWidth = 6;
            this.Tag.Name = "Tag";
            this.Tag.Width = 220;
            // 
            // EliminarBusqueda
            // 
            this.EliminarBusqueda.HeaderText = "Eliminar";
            this.EliminarBusqueda.MinimumWidth = 6;
            this.EliminarBusqueda.Name = "EliminarBusqueda";
            this.EliminarBusqueda.Width = 70;
            // 
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Buscar.Location = new System.Drawing.Point(38, 408);
            this.button_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(259, 32);
            this.button_Buscar.TabIndex = 10;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // dataGridView_PosteosRed
            // 
            this.dataGridView_PosteosRed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PosteosRed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPosteos,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridView_PosteosRed.Location = new System.Drawing.Point(338, 34);
            this.dataGridView_PosteosRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_PosteosRed.Name = "dataGridView_PosteosRed";
            this.dataGridView_PosteosRed.RowHeadersVisible = false;
            this.dataGridView_PosteosRed.RowHeadersWidth = 51;
            this.dataGridView_PosteosRed.RowTemplate.Height = 29;
            this.dataGridView_PosteosRed.Size = new System.Drawing.Size(468, 444);
            this.dataGridView_PosteosRed.TabIndex = 11;
            this.dataGridView_PosteosRed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionadorAmigo);
            this.dataGridView_PosteosRed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VerPost);
            // 
            // idPosteos
            // 
            this.idPosteos.HeaderText = "idPosteos";
            this.idPosteos.MinimumWidth = 6;
            this.idPosteos.Name = "idPosteos";
            this.idPosteos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idPosteos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.idPosteos.Visible = false;
            this.idPosteos.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Posteo";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 440;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Ver Post";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // button_FormMain
            // 
            this.button_FormMain.Location = new System.Drawing.Point(119, 457);
            this.button_FormMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_FormMain.Name = "button_FormMain";
            this.button_FormMain.Size = new System.Drawing.Size(95, 22);
            this.button_FormMain.TabIndex = 12;
            this.button_FormMain.Text = "Volver Inicio";
            this.button_FormMain.UseVisualStyleBackColor = true;
            this.button_FormMain.Click += new System.EventHandler(this.button_FormMain_Click);
            // 
            // FormBuscarPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 488);
            this.Controls.Add(this.button_FormMain);
            this.Controls.Add(this.dataGridView_PosteosRed);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.dataGridView_TagsBusqueda);
            this.Controls.Add(this.label_Tags);
            this.Controls.Add(this.textBox_Tags);
            this.Controls.Add(this.label_Hasta);
            this.Controls.Add(this.dateTimePicker_Hasta);
            this.Controls.Add(this.label_Desde);
            this.Controls.Add(this.dateTimePicker_Desde);
            this.Controls.Add(this.label_Comentario);
            this.Controls.Add(this.textBox_Comentario);
            this.Controls.Add(this.button_agrgarTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBuscarPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBuscarPost";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TagsBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PosteosRed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_agrgarTag;
        private TextBox textBox_Comentario;
        private Label label_Comentario;
        private DateTimePicker dateTimePicker_Desde;
        private Label label_Desde;
        private Label label_Hasta;
        private DateTimePicker dateTimePicker_Hasta;
        private Label label_Tags;
        private TextBox textBox_Tags;
        private DataGridView dataGridView_TagsBusqueda;
        private Button button_Buscar;
        private DataGridView dataGridView_PosteosRed;
        private DataGridViewButtonColumn idPosteos;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewButtonColumn dataGridViewTextBoxColumn5;
        private Button button_FormMain;
        private DataGridViewTextBoxColumn Tag;
        private DataGridViewButtonColumn EliminarBusqueda;
    }
}