namespace SistemaInventario
{
    partial class FrmInventario
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventario));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBMinimizar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBSalir = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtexistencia = new System.Windows.Forms.TextBox();
            this.txtpcompra = new System.Windows.Forms.TextBox();
            this.txtpventa = new System.Windows.Forms.TextBox();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btnborrar = new System.Windows.Forms.Button();
            this.btnimportar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvmostrar = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.btnexportar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.txtdescripcion = new System.Windows.Forms.RichTextBox();
            this.lblruta = new System.Windows.Forms.Label();
            this.pbFotoProducto = new System.Windows.Forms.PictureBox();
            this.btncargar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmostrar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoProducto)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventario";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(164)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.picBMinimizar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.picBSalir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 74);
            this.panel1.TabIndex = 1;
            // 
            // picBMinimizar
            // 
            this.picBMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("picBMinimizar.Image")));
            this.picBMinimizar.Location = new System.Drawing.Point(1185, 15);
            this.picBMinimizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBMinimizar.Name = "picBMinimizar";
            this.picBMinimizar.Size = new System.Drawing.Size(60, 52);
            this.picBMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBMinimizar.TabIndex = 30;
            this.picBMinimizar.TabStop = false;
            this.picBMinimizar.Click += new System.EventHandler(this.picBMinimizar_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-29, -54);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 62);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // picBSalir
            // 
            this.picBSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBSalir.Image = ((System.Drawing.Image)(resources.GetObject("picBSalir.Image")));
            this.picBSalir.Location = new System.Drawing.Point(1259, 15);
            this.picBSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBSalir.Name = "picBSalir";
            this.picBSalir.Size = new System.Drawing.Size(53, 52);
            this.picBSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBSalir.TabIndex = 26;
            this.picBSalir.TabStop = false;
            this.picBSalir.Click += new System.EventHandler(this.picBSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 30);
            this.label2.TabIndex = 27;
            this.label2.Text = "Codigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 30);
            this.label3.TabIndex = 27;
            this.label3.Text = "Existencias:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(5, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 30);
            this.label6.TabIndex = 27;
            this.label6.Text = "Precio Compra:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 174);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 30);
            this.label7.TabIndex = 27;
            this.label7.Text = "Precio Venta:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(5, 239);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 30);
            this.label10.TabIndex = 27;
            this.label10.Text = "Descripción:";
            // 
            // txtexistencia
            // 
            this.txtexistencia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexistencia.Location = new System.Drawing.Point(221, 64);
            this.txtexistencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtexistencia.MaxLength = 50;
            this.txtexistencia.Name = "txtexistencia";
            this.txtexistencia.Size = new System.Drawing.Size(304, 32);
            this.txtexistencia.TabIndex = 2;
            this.txtexistencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtexistencia_KeyPress);
            // 
            // txtpcompra
            // 
            this.txtpcompra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpcompra.Location = new System.Drawing.Point(221, 118);
            this.txtpcompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpcompra.MaxLength = 100;
            this.txtpcompra.Name = "txtpcompra";
            this.txtpcompra.Size = new System.Drawing.Size(304, 32);
            this.txtpcompra.TabIndex = 3;
            this.txtpcompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpcompra_KeyPress);
            // 
            // txtpventa
            // 
            this.txtpventa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpventa.Location = new System.Drawing.Point(221, 174);
            this.txtpventa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpventa.MaxLength = 100;
            this.txtpventa.Name = "txtpventa";
            this.txtpventa.Size = new System.Drawing.Size(304, 32);
            this.txtpventa.TabIndex = 4;
            this.txtpventa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpventa_KeyPress);
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnagregar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregar.ForeColor = System.Drawing.Color.Black;
            this.btnagregar.Location = new System.Drawing.Point(9, 618);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(137, 42);
            this.btnagregar.TabIndex = 13;
            this.btnagregar.Text = "Guardar";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnGuardarA_Click);
            // 
            // btnborrar
            // 
            this.btnborrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnborrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnborrar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnborrar.ForeColor = System.Drawing.Color.Black;
            this.btnborrar.Location = new System.Drawing.Point(383, 617);
            this.btnborrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnborrar.Name = "btnborrar";
            this.btnborrar.Size = new System.Drawing.Size(137, 43);
            this.btnborrar.TabIndex = 14;
            this.btnborrar.Text = "Borrar";
            this.btnborrar.UseVisualStyleBackColor = false;
            this.btnborrar.Click += new System.EventHandler(this.btnborrar_Click);
            // 
            // btnimportar
            // 
            this.btnimportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnimportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnimportar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimportar.ForeColor = System.Drawing.Color.Black;
            this.btnimportar.Location = new System.Drawing.Point(325, 619);
            this.btnimportar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnimportar.Name = "btnimportar";
            this.btnimportar.Size = new System.Drawing.Size(201, 43);
            this.btnimportar.TabIndex = 15;
            this.btnimportar.Text = "Importar";
            this.btnimportar.UseVisualStyleBackColor = false;
            this.btnimportar.Click += new System.EventHandler(this.btnimportar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(1364, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(255, 30);
            this.label12.TabIndex = 27;
            this.label12.Text = "Registro de alumnos";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgvmostrar
            // 
            this.dgvmostrar.AllowUserToAddRows = false;
            this.dgvmostrar.AllowUserToDeleteRows = false;
            this.dgvmostrar.AllowUserToOrderColumns = true;
            this.dgvmostrar.AllowUserToResizeRows = false;
            this.dgvmostrar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvmostrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmostrar.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvmostrar.Location = new System.Drawing.Point(9, 59);
            this.dgvmostrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvmostrar.MultiSelect = false;
            this.dgvmostrar.Name = "dgvmostrar";
            this.dgvmostrar.ReadOnly = true;
            this.dgvmostrar.RowHeadersWidth = 51;
            this.dgvmostrar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvmostrar.Size = new System.Drawing.Size(724, 533);
            this.dgvmostrar.TabIndex = 17;
            this.dgvmostrar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmostrar_CellClick);
            this.dgvmostrar.DoubleClick += new System.EventHandler(this.dgvDatosAlumnos_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Controls.Add(this.btnexportar);
            this.panel2.Controls.Add(this.btnimportar);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtArchivo);
            this.panel2.Controls.Add(this.txtdescripcion);
            this.panel2.Controls.Add(this.lblruta);
            this.panel2.Controls.Add(this.pbFotoProducto);
            this.panel2.Controls.Add(this.btncargar);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtexistencia);
            this.panel2.Controls.Add(this.txtpcompra);
            this.panel2.Controls.Add(this.txtpventa);
            this.panel2.Location = new System.Drawing.Point(16, 81);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 672);
            this.panel2.TabIndex = 0;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtCodigo.Location = new System.Drawing.Point(220, 10);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo.Mask = "0000000";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(304, 32);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Tag = "";
            // 
            // btnexportar
            // 
            this.btnexportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnexportar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexportar.ForeColor = System.Drawing.Color.Black;
            this.btnexportar.Location = new System.Drawing.Point(11, 618);
            this.btnexportar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(201, 43);
            this.btnexportar.TabIndex = 45;
            this.btnexportar.Text = "Exportar";
            this.btnexportar.UseVisualStyleBackColor = false;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 565);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 30);
            this.label4.TabIndex = 51;
            this.label4.Text = "Nombre Archivo:";
            // 
            // txtArchivo
            // 
            this.txtArchivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivo.Location = new System.Drawing.Point(232, 559);
            this.txtArchivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtArchivo.MaxLength = 100;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(293, 32);
            this.txtArchivo.TabIndex = 7;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(221, 239);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdescripcion.MaxLength = 100;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(304, 58);
            this.txtdescripcion.TabIndex = 5;
            this.txtdescripcion.Text = "";
            // 
            // lblruta
            // 
            this.lblruta.AutoSize = true;
            this.lblruta.Location = new System.Drawing.Point(7, 380);
            this.lblruta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblruta.Name = "lblruta";
            this.lblruta.Size = new System.Drawing.Size(61, 17);
            this.lblruta.TabIndex = 48;
            this.lblruta.Text = "rutaFoto";
            this.lblruta.Visible = false;
            // 
            // pbFotoProducto
            // 
            this.pbFotoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFotoProducto.Location = new System.Drawing.Point(325, 362);
            this.pbFotoProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbFotoProducto.Name = "pbFotoProducto";
            this.pbFotoProducto.Size = new System.Drawing.Size(201, 188);
            this.pbFotoProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFotoProducto.TabIndex = 47;
            this.pbFotoProducto.TabStop = false;
            // 
            // btncargar
            // 
            this.btncargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btncargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncargar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncargar.ForeColor = System.Drawing.Color.Black;
            this.btncargar.Location = new System.Drawing.Point(220, 327);
            this.btncargar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(305, 27);
            this.btncargar.TabIndex = 6;
            this.btncargar.Text = "Seleccionar foto...";
            this.btncargar.UseVisualStyleBackColor = false;
            this.btncargar.Click += new System.EventHandler(this.txtFoto_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(4, 327);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 30);
            this.label16.TabIndex = 46;
            this.label16.Text = "Foto:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnEditar);
            this.panel3.Controls.Add(this.dgvmostrar);
            this.panel3.Controls.Add(this.btnagregar);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.btnborrar);
            this.panel3.Location = new System.Drawing.Point(573, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(748, 672);
            this.panel3.TabIndex = 42;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(580, 617);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 42);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Location = new System.Drawing.Point(199, 619);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(137, 42);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(452, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(273, 30);
            this.label14.TabIndex = 0;
            this.label14.Text = "Registro de productos";
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog1";
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1320, 768);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Alumno_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmostrar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoProducto)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtexistencia;
        private System.Windows.Forms.TextBox txtpcompra;
        private System.Windows.Forms.TextBox txtpventa;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnborrar;
        private System.Windows.Forms.Button btnimportar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgvmostrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picBMinimizar;
        private System.Windows.Forms.Label lblruta;
        private System.Windows.Forms.PictureBox pbFotoProducto;
        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.RichTextBox txtdescripcion;
        private System.Windows.Forms.Button btnexportar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.MaskedTextBox txtCodigo;
        private System.Windows.Forms.Button btnCancelar;
    }
}