namespace apHashing
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tecniHash = new System.Windows.Forms.Label();
            this.bcktHash = new System.Windows.Forms.RadioButton();
            this.sondLin = new System.Windows.Forms.RadioButton();
            this.sondQua = new System.Windows.Forms.RadioButton();
            this.duplHash = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPalavra = new System.Windows.Forms.Label();
            this.txtBPalavra = new System.Windows.Forms.TextBox();
            this.lblDica = new System.Windows.Forms.Label();
            this.txtBDica = new System.Windows.Forms.TextBox();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.lblLista = new System.Windows.Forms.Label();
            this.lsbListagem = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tecniHash
            // 
            this.tecniHash.AutoSize = true;
            this.tecniHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tecniHash.Location = new System.Drawing.Point(34, 34);
            this.tecniHash.Name = "tecniHash";
            this.tecniHash.Size = new System.Drawing.Size(189, 24);
            this.tecniHash.TabIndex = 0;
            this.tecniHash.Text = "Técnicas de Hashing";
            // 
            // bcktHash
            // 
            this.bcktHash.AutoSize = true;
            this.bcktHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcktHash.Location = new System.Drawing.Point(39, 71);
            this.bcktHash.Name = "bcktHash";
            this.bcktHash.Size = new System.Drawing.Size(137, 24);
            this.bcktHash.TabIndex = 1;
            this.bcktHash.TabStop = true;
            this.bcktHash.Text = "Bucket hashing";
            this.bcktHash.UseVisualStyleBackColor = true;
            this.bcktHash.CheckedChanged += new System.EventHandler(this.bcktHash_CheckedChanged);
            // 
            // sondLin
            // 
            this.sondLin.AutoSize = true;
            this.sondLin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sondLin.Location = new System.Drawing.Point(39, 109);
            this.sondLin.Name = "sondLin";
            this.sondLin.Size = new System.Drawing.Size(147, 24);
            this.sondLin.TabIndex = 2;
            this.sondLin.TabStop = true;
            this.sondLin.Text = "Sondagem linear";
            this.sondLin.UseVisualStyleBackColor = true;
            this.sondLin.CheckedChanged += new System.EventHandler(this.sondLin_CheckedChanged);
            // 
            // sondQua
            // 
            this.sondQua.AutoSize = true;
            this.sondQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sondQua.Location = new System.Drawing.Point(39, 147);
            this.sondQua.Name = "sondQua";
            this.sondQua.Size = new System.Drawing.Size(184, 24);
            this.sondQua.TabIndex = 3;
            this.sondQua.TabStop = true;
            this.sondQua.Text = "Sondagem quadrática";
            this.sondQua.UseVisualStyleBackColor = true;
            this.sondQua.CheckedChanged += new System.EventHandler(this.sondQua_CheckedChanged);
            // 
            // duplHash
            // 
            this.duplHash.AutoSize = true;
            this.duplHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duplHash.Location = new System.Drawing.Point(39, 187);
            this.duplHash.Name = "duplHash";
            this.duplHash.Size = new System.Drawing.Size(129, 24);
            this.duplHash.TabIndex = 4;
            this.duplHash.TabStop = true;
            this.duplHash.Text = "Duplo hashing";
            this.duplHash.UseVisualStyleBackColor = true;
            this.duplHash.CheckedChanged += new System.EventHandler(this.duplHash_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(11, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 193);
            this.panel1.TabIndex = 5;
            // 
            // lblPalavra
            // 
            this.lblPalavra.AutoSize = true;
            this.lblPalavra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalavra.Location = new System.Drawing.Point(309, 59);
            this.lblPalavra.Name = "lblPalavra";
            this.lblPalavra.Size = new System.Drawing.Size(61, 18);
            this.lblPalavra.TabIndex = 6;
            this.lblPalavra.Text = "Palavra:";
            // 
            // txtBPalavra
            // 
            this.txtBPalavra.Location = new System.Drawing.Point(376, 60);
            this.txtBPalavra.Name = "txtBPalavra";
            this.txtBPalavra.Size = new System.Drawing.Size(158, 20);
            this.txtBPalavra.TabIndex = 7;
            // 
            // lblDica
            // 
            this.lblDica.AutoSize = true;
            this.lblDica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDica.Location = new System.Drawing.Point(309, 99);
            this.lblDica.Name = "lblDica";
            this.lblDica.Size = new System.Drawing.Size(42, 18);
            this.lblDica.TabIndex = 8;
            this.lblDica.Text = "Dica:";
            // 
            // txtBDica
            // 
            this.txtBDica.Location = new System.Drawing.Point(376, 97);
            this.txtBDica.Name = "txtBDica";
            this.txtBDica.Size = new System.Drawing.Size(403, 20);
            this.txtBDica.TabIndex = 9;
            // 
            // btnIncluir
            // 
            this.btnIncluir.BackColor = System.Drawing.Color.White;
            this.btnIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncluir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnIncluir.FlatAppearance.BorderSize = 2;
            this.btnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.Location = new System.Drawing.Point(297, 174);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(83, 37);
            this.btnIncluir.TabIndex = 10;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExcluir.FlatAppearance.BorderSize = 2;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(408, 174);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(83, 37);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.White;
            this.btnListar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnListar.FlatAppearance.BorderSize = 2;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Location = new System.Drawing.Point(632, 174);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(83, 37);
            this.btnListar.TabIndex = 13;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.White;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAlterar.FlatAppearance.BorderSize = 2;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(519, 174);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(83, 37);
            this.btnAlterar.TabIndex = 14;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLista.Location = new System.Drawing.Point(12, 251);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(104, 18);
            this.lblLista.TabIndex = 15;
            this.lblLista.Text = "Lista de dados";
            // 
            // lsbListagem
            // 
            this.lsbListagem.FormattingEnabled = true;
            this.lsbListagem.Location = new System.Drawing.Point(12, 272);
            this.lsbListagem.Name = "lsbListagem";
            this.lsbListagem.Size = new System.Drawing.Size(767, 147);
            this.lsbListagem.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsbListagem);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.txtBDica);
            this.Controls.Add(this.lblDica);
            this.Controls.Add(this.txtBPalavra);
            this.Controls.Add(this.lblPalavra);
            this.Controls.Add(this.duplHash);
            this.Controls.Add(this.sondQua);
            this.Controls.Add(this.sondLin);
            this.Controls.Add(this.bcktHash);
            this.Controls.Add(this.tecniHash);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tecniHash;
        private System.Windows.Forms.RadioButton bcktHash;
        private System.Windows.Forms.RadioButton sondLin;
        private System.Windows.Forms.RadioButton sondQua;
        private System.Windows.Forms.RadioButton duplHash;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPalavra;
        private System.Windows.Forms.TextBox txtBPalavra;
        private System.Windows.Forms.Label lblDica;
        private System.Windows.Forms.TextBox txtBDica;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.ListBox lsbListagem;
    }
}

