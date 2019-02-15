namespace Cir.Modal
{
    partial class ModalFormRic
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
            this.datePickerDatIni = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescri = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkBoxChiusa = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // datePickerDatIni
            // 
            this.datePickerDatIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerDatIni.Location = new System.Drawing.Point(15, 35);
            this.datePickerDatIni.Name = "datePickerDatIni";
            this.datePickerDatIni.Size = new System.Drawing.Size(97, 20);
            this.datePickerDatIni.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Data richiesta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descrizione";
            // 
            // txtDescri
            // 
            this.txtDescri.Location = new System.Drawing.Point(136, 35);
            this.txtDescri.Name = "txtDescri";
            this.txtDescri.Size = new System.Drawing.Size(408, 20);
            this.txtDescri.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(453, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 22);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkBoxChiusa
            // 
            this.checkBoxChiusa.AutoSize = true;
            this.checkBoxChiusa.Location = new System.Drawing.Point(15, 69);
            this.checkBoxChiusa.Name = "checkBoxChiusa";
            this.checkBoxChiusa.Size = new System.Drawing.Size(58, 17);
            this.checkBoxChiusa.TabIndex = 30;
            this.checkBoxChiusa.Text = "Chiusa";
            this.checkBoxChiusa.UseVisualStyleBackColor = true;
            // 
            // ModalFormRic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 101);
            this.Controls.Add(this.checkBoxChiusa);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datePickerDatIni);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModalFormRic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Richiesta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePickerDatIni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescri;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkBoxChiusa;
    }
}