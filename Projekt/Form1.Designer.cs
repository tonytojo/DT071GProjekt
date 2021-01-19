namespace Projekt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRad = new System.Windows.Forms.Label();
            this.lblCol = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSpela = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cboRad = new System.Windows.Forms.ComboBox();
            this.cboCol = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtNamn = new System.Windows.Forms.TextBox();
            this.cboPersons = new System.Windows.Forms.ComboBox();
            this.lstMoves = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblRad
            // 
            this.lblRad.AutoSize = true;
            this.lblRad.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.lblRad.Location = new System.Drawing.Point(39, 35);
            this.lblRad.Name = "lblRad";
            this.lblRad.Size = new System.Drawing.Size(35, 18);
            this.lblRad.TabIndex = 1;
            this.lblRad.Text = "Rad:";
            // 
            // lblCol
            // 
            this.lblCol.AutoSize = true;
            this.lblCol.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.lblCol.Location = new System.Drawing.Point(39, 65);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(55, 18);
            this.lblCol.TabIndex = 1;
            this.lblCol.Text = "Kolumn:";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnClear.Location = new System.Drawing.Point(39, 96);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 26);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSpela
            // 
            this.btnSpela.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnSpela.Location = new System.Drawing.Point(111, 96);
            this.btnSpela.Name = "btnSpela";
            this.btnSpela.Size = new System.Drawing.Size(131, 26);
            this.btnSpela.TabIndex = 4;
            this.btnSpela.Text = "Run KnightTour";
            this.btnSpela.UseVisualStyleBackColor = true;
            this.btnSpela.Click += new System.EventHandler(this.btnSpela_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Location = new System.Drawing.Point(240, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(569, 59);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "KnightTour On ChessBoard";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblInfo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline);
            this.lblInfo.Location = new System.Drawing.Point(255, 101);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(489, 18);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Ange rad och kolumn för hästens placering på checkbrädet";
            // 
            // cboRad
            // 
            this.cboRad.FormattingEnabled = true;
            this.cboRad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cboRad.Location = new System.Drawing.Point(95, 34);
            this.cboRad.Name = "cboRad";
            this.cboRad.Size = new System.Drawing.Size(112, 21);
            this.cboRad.TabIndex = 9;
            // 
            // cboCol
            // 
            this.cboCol.FormattingEnabled = true;
            this.cboCol.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h"});
            this.cboCol.Location = new System.Drawing.Point(95, 64);
            this.cboCol.Name = "cboCol";
            this.cboCol.Size = new System.Drawing.Size(112, 21);
            this.cboCol.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(36, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Namn:";
            // 
            // txtNamn
            // 
            this.txtNamn.Location = new System.Drawing.Point(95, 6);
            this.txtNamn.Name = "txtNamn";
            this.txtNamn.Size = new System.Drawing.Size(112, 20);
            this.txtNamn.TabIndex = 12;
            // 
            // cboPersons
            // 
            this.cboPersons.FormattingEnabled = true;
            this.cboPersons.Location = new System.Drawing.Point(12, 157);
            this.cboPersons.Name = "cboPersons";
            this.cboPersons.Size = new System.Drawing.Size(167, 21);
            this.cboPersons.TabIndex = 15;
            this.cboPersons.SelectedIndexChanged += new System.EventHandler(this.cboPersons_SelectedIndexChanged);
            // 
            // lstMoves
            // 
            this.lstMoves.FormattingEnabled = true;
            this.lstMoves.Location = new System.Drawing.Point(12, 199);
            this.lstMoves.Name = "lstMoves";
            this.lstMoves.Size = new System.Drawing.Size(87, 433);
            this.lstMoves.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 729);
            this.Controls.Add(this.lstMoves);
            this.Controls.Add(this.cboPersons);
            this.Controls.Add(this.txtNamn);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cboCol);
            this.Controls.Add(this.cboRad);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSpela);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCol);
            this.Controls.Add(this.lblRad);
            this.Name = "Form1";
            this.Text = "KnightTour on ChessBoard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRad;
        private System.Windows.Forms.Label lblCol;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSpela;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cboRad;
        private System.Windows.Forms.ComboBox cboCol;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtNamn;
        private System.Windows.Forms.ComboBox cboPersons;
        private System.Windows.Forms.ListBox lstMoves;
    }
}

