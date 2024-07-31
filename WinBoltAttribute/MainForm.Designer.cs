namespace WinBoltAttribute
{
    partial class MainForm
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pgrbarParts = new System.Windows.Forms.ProgressBar();
            this.rdSelectedParts = new System.Windows.Forms.RadioButton();
            this.rdAllParts = new System.Windows.Forms.RadioButton();
            this.txtBoltMark = new System.Windows.Forms.TextBox();
            this.txtBoltCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtWasherMark = new System.Windows.Forms.TextBox();
            this.txtWasherCode = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNutMark = new System.Windows.Forms.TextBox();
            this.txtNutCode = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtWasherMark3 = new System.Windows.Forms.TextBox();
            this.txtWasherCode3 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtNutMark2 = new System.Windows.Forms.TextBox();
            this.txtNutCode2 = new System.Windows.Forms.TextBox();
            this.Limpar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWasherCode2 = new System.Windows.Forms.TextBox();
            this.txtWasherMark2 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.day = new System.Windows.Forms.Label();
            this.month = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(142, 375);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpadate_Click);
            // 
            // pgrbarParts
            // 
            this.pgrbarParts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgrbarParts.Location = new System.Drawing.Point(0, 404);
            this.pgrbarParts.Name = "pgrbarParts";
            this.pgrbarParts.Size = new System.Drawing.Size(283, 12);
            this.pgrbarParts.TabIndex = 1;
            this.pgrbarParts.Visible = false;
            // 
            // rdSelectedParts
            // 
            this.rdSelectedParts.AutoSize = true;
            this.rdSelectedParts.Enabled = false;
            this.rdSelectedParts.Location = new System.Drawing.Point(12, 57);
            this.rdSelectedParts.Name = "rdSelectedParts";
            this.rdSelectedParts.Size = new System.Drawing.Size(164, 17);
            this.rdSelectedParts.TabIndex = 2;
            this.rdSelectedParts.Text = "Usar Parafusos Selecionados";
            this.rdSelectedParts.UseVisualStyleBackColor = true;
            this.rdSelectedParts.Visible = false;
            // 
            // rdAllParts
            // 
            this.rdAllParts.AutoSize = true;
            this.rdAllParts.Checked = true;
            this.rdAllParts.Location = new System.Drawing.Point(12, 36);
            this.rdAllParts.Name = "rdAllParts";
            this.rdAllParts.Size = new System.Drawing.Size(158, 17);
            this.rdAllParts.TabIndex = 2;
            this.rdAllParts.TabStop = true;
            this.rdAllParts.Text = "Todos Parafusos do Modelo";
            this.rdAllParts.UseVisualStyleBackColor = true;
            // 
            // txtBoltMark
            // 
            this.txtBoltMark.Location = new System.Drawing.Point(6, 16);
            this.txtBoltMark.Name = "txtBoltMark";
            this.txtBoltMark.Size = new System.Drawing.Size(130, 20);
            this.txtBoltMark.TabIndex = 4;
            this.txtBoltMark.Text = "MARCA_PARAFUSO1";
            this.txtBoltMark.TextChanged += new System.EventHandler(this.txtBoltMark_TextChanged);
            // 
            // txtBoltCode
            // 
            this.txtBoltCode.Location = new System.Drawing.Point(141, 16);
            this.txtBoltCode.Name = "txtBoltCode";
            this.txtBoltCode.Size = new System.Drawing.Size(130, 20);
            this.txtBoltCode.TabIndex = 4;
            this.txtBoltCode.Text = "MAT_PARAFUSO1";
            this.txtBoltCode.TextChanged += new System.EventHandler(this.txtBoltCode_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoltMark);
            this.groupBox1.Controls.Add(this.txtBoltCode);
            this.groupBox1.Location = new System.Drawing.Point(1, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 43);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parafuso";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtWasherMark);
            this.groupBox2.Controls.Add(this.txtWasherCode);
            this.groupBox2.Location = new System.Drawing.Point(1, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 43);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arruela";
            // 
            // txtWasherMark
            // 
            this.txtWasherMark.Location = new System.Drawing.Point(6, 16);
            this.txtWasherMark.Name = "txtWasherMark";
            this.txtWasherMark.Size = new System.Drawing.Size(130, 20);
            this.txtWasherMark.TabIndex = 4;
            this.txtWasherMark.Text = "MARCA_ARRUELA1";
            this.txtWasherMark.TextChanged += new System.EventHandler(this.txtWasherMark_TextChanged);
            // 
            // txtWasherCode
            // 
            this.txtWasherCode.Location = new System.Drawing.Point(141, 16);
            this.txtWasherCode.Name = "txtWasherCode";
            this.txtWasherCode.Size = new System.Drawing.Size(130, 20);
            this.txtWasherCode.TabIndex = 4;
            this.txtWasherCode.Text = "MAT_ARRUELA1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNutMark);
            this.groupBox3.Controls.Add(this.txtNutCode);
            this.groupBox3.Location = new System.Drawing.Point(1, 269);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 43);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Porca";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtNutMark
            // 
            this.txtNutMark.Location = new System.Drawing.Point(6, 15);
            this.txtNutMark.Name = "txtNutMark";
            this.txtNutMark.Size = new System.Drawing.Size(130, 20);
            this.txtNutMark.TabIndex = 4;
            this.txtNutMark.Text = "MARCA_PORCA1";
            // 
            // txtNutCode
            // 
            this.txtNutCode.Location = new System.Drawing.Point(141, 15);
            this.txtNutCode.Name = "txtNutCode";
            this.txtNutCode.Size = new System.Drawing.Size(130, 20);
            this.txtNutCode.TabIndex = 4;
            this.txtNutCode.Text = "MAT_PORCA1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtWasherMark3);
            this.groupBox4.Controls.Add(this.txtWasherCode3);
            this.groupBox4.Location = new System.Drawing.Point(1, 220);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 43);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Arruela 3";
            // 
            // txtWasherMark3
            // 
            this.txtWasherMark3.Location = new System.Drawing.Point(6, 16);
            this.txtWasherMark3.Name = "txtWasherMark3";
            this.txtWasherMark3.Size = new System.Drawing.Size(130, 20);
            this.txtWasherMark3.TabIndex = 4;
            this.txtWasherMark3.Text = "MARCA_ARRUELA3";
            // 
            // txtWasherCode3
            // 
            this.txtWasherCode3.Location = new System.Drawing.Point(141, 16);
            this.txtWasherCode3.Name = "txtWasherCode3";
            this.txtWasherCode3.Size = new System.Drawing.Size(130, 20);
            this.txtWasherCode3.TabIndex = 4;
            this.txtWasherCode3.Text = "MAT_ARRUELA3";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtNutMark2);
            this.groupBox5.Controls.Add(this.txtNutCode2);
            this.groupBox5.Location = new System.Drawing.Point(1, 318);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(278, 43);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Porca 2";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // txtNutMark2
            // 
            this.txtNutMark2.Location = new System.Drawing.Point(6, 15);
            this.txtNutMark2.Name = "txtNutMark2";
            this.txtNutMark2.Size = new System.Drawing.Size(130, 20);
            this.txtNutMark2.TabIndex = 4;
            this.txtNutMark2.Text = "MARCA_PORCA2";
            // 
            // txtNutCode2
            // 
            this.txtNutCode2.Location = new System.Drawing.Point(141, 15);
            this.txtNutCode2.Name = "txtNutCode2";
            this.txtNutCode2.Size = new System.Drawing.Size(130, 20);
            this.txtNutCode2.TabIndex = 4;
            this.txtNutCode2.Text = "MAT_PORCA2";
            // 
            // Limpar
            // 
            this.Limpar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Limpar.Location = new System.Drawing.Point(12, 375);
            this.Limpar.Name = "Limpar";
            this.Limpar.Size = new System.Drawing.Size(120, 23);
            this.Limpar.TabIndex = 9;
            this.Limpar.Text = "Limpar";
            this.Limpar.UseVisualStyleBackColor = true;
            this.Limpar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Versão BETA disponivel até ____/____/_______";
            // 
            // txtWasherCode2
            // 
            this.txtWasherCode2.Location = new System.Drawing.Point(141, 16);
            this.txtWasherCode2.Name = "txtWasherCode2";
            this.txtWasherCode2.Size = new System.Drawing.Size(130, 20);
            this.txtWasherCode2.TabIndex = 4;
            this.txtWasherCode2.Text = "MAT_ARRUELA2";
            // 
            // txtWasherMark2
            // 
            this.txtWasherMark2.Location = new System.Drawing.Point(6, 16);
            this.txtWasherMark2.Name = "txtWasherMark2";
            this.txtWasherMark2.Size = new System.Drawing.Size(130, 20);
            this.txtWasherMark2.TabIndex = 4;
            this.txtWasherMark2.Text = "MARCA_ARRUELA2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtWasherMark2);
            this.groupBox6.Controls.Add(this.txtWasherCode2);
            this.groupBox6.Location = new System.Drawing.Point(1, 171);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(278, 43);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Arruela 2";
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.Location = new System.Drawing.Point(159, 8);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(24, 13);
            this.day.TabIndex = 16;
            this.day.Text = "day";
            this.day.Click += new System.EventHandler(this.label2_Click);
            // 
            // month
            // 
            this.month.AutoSize = true;
            this.month.Location = new System.Drawing.Point(189, 8);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(23, 13);
            this.month.TabIndex = 17;
            this.month.Text = "mm";
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(225, 8);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(26, 13);
            this.year.TabIndex = 18;
            this.year.Text = "Ano";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 416);
            this.Controls.Add(this.year);
            this.Controls.Add(this.month);
            this.Controls.Add(this.day);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Limpar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rdAllParts);
            this.Controls.Add(this.rdSelectedParts);
            this.Controls.Add(this.pgrbarParts);
            this.Controls.Add(this.btnUpdate);
            this.Name = "MainForm";
            this.Text = " WinBoltAttribute";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar pgrbarParts;
        private System.Windows.Forms.RadioButton rdSelectedParts;
        private System.Windows.Forms.RadioButton rdAllParts;
        private System.Windows.Forms.TextBox txtBoltMark;
        private System.Windows.Forms.TextBox txtBoltCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtWasherMark;
        private System.Windows.Forms.TextBox txtWasherCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNutMark;
        private System.Windows.Forms.TextBox txtNutCode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtWasherMark3;
        private System.Windows.Forms.TextBox txtWasherCode3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtNutMark2;
        private System.Windows.Forms.TextBox txtNutCode2;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWasherCode2;
        private System.Windows.Forms.TextBox txtWasherMark2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label day;
        private System.Windows.Forms.Label month;
        private System.Windows.Forms.Label year;
    }
}

