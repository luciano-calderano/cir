namespace Cir
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnAmm = new System.Windows.Forms.Button();
            this.btnCnd = new System.Windows.Forms.Button();
            this.btnRic = new System.Windows.Forms.Button();
            this.btnMnu = new System.Windows.Forms.Button();
            this.btnFrn = new System.Windows.Forms.Button();
            this.mnuTabell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.parametriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tecniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoInterventoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testoScadenzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoAlimentazioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnScaden = new System.Windows.Forms.Button();
            this.btnDaFatt = new System.Windows.Forms.Button();
            this.btnFatt = new System.Windows.Forms.Button();
            this.zoneClientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTabell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAmm
            // 
            this.btnAmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmm.Location = new System.Drawing.Point(495, 0);
            this.btnAmm.Name = "btnAmm";
            this.btnAmm.Size = new System.Drawing.Size(118, 23);
            this.btnAmm.TabIndex = 0;
            this.btnAmm.Text = "Amministratori";
            this.btnAmm.UseVisualStyleBackColor = true;
            this.btnAmm.Click += new System.EventHandler(this.butAmm_Click);
            // 
            // btnCnd
            // 
            this.btnCnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCnd.Location = new System.Drawing.Point(-1, 0);
            this.btnCnd.Name = "btnCnd";
            this.btnCnd.Size = new System.Drawing.Size(118, 23);
            this.btnCnd.TabIndex = 4;
            this.btnCnd.Text = "Clienti";
            this.btnCnd.UseVisualStyleBackColor = true;
            this.btnCnd.Click += new System.EventHandler(this.btnCli_Click);
            // 
            // btnRic
            // 
            this.btnRic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRic.Location = new System.Drawing.Point(247, 0);
            this.btnRic.Name = "btnRic";
            this.btnRic.Size = new System.Drawing.Size(118, 23);
            this.btnRic.TabIndex = 6;
            this.btnRic.Text = "Richieste";
            this.btnRic.UseVisualStyleBackColor = true;
            this.btnRic.Click += new System.EventHandler(this.btnRic_Click);
            // 
            // btnMnu
            // 
            this.btnMnu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMnu.Location = new System.Drawing.Point(917, 0);
            this.btnMnu.Name = "btnMnu";
            this.btnMnu.Size = new System.Drawing.Size(85, 23);
            this.btnMnu.TabIndex = 8;
            this.btnMnu.Text = "Tabelle";
            this.btnMnu.UseVisualStyleBackColor = true;
            this.btnMnu.Click += new System.EventHandler(this.btnMnu_Click);
            // 
            // btnFrn
            // 
            this.btnFrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrn.Location = new System.Drawing.Point(619, 0);
            this.btnFrn.Name = "btnFrn";
            this.btnFrn.Size = new System.Drawing.Size(118, 23);
            this.btnFrn.TabIndex = 11;
            this.btnFrn.Text = "Fornitori";
            this.btnFrn.UseVisualStyleBackColor = true;
            this.btnFrn.Click += new System.EventHandler(this.btnFrn_Click);
            // 
            // mnuTabell
            // 
            this.mnuTabell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametriToolStripMenuItem,
            this.tecniciToolStripMenuItem,
            this.tipoInterventoToolStripMenuItem,
            this.testoScadenzeToolStripMenuItem,
            this.tipoAlimentazioneToolStripMenuItem,
            this.zoneClientiToolStripMenuItem});
            this.mnuTabell.Name = "mnuTabell";
            this.mnuTabell.Size = new System.Drawing.Size(176, 158);
            // 
            // parametriToolStripMenuItem
            // 
            this.parametriToolStripMenuItem.Name = "parametriToolStripMenuItem";
            this.parametriToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.parametriToolStripMenuItem.Text = "Parametri";
            this.parametriToolStripMenuItem.Click += new System.EventHandler(this.parametriToolStripMenuItem_Click);
            // 
            // tecniciToolStripMenuItem
            // 
            this.tecniciToolStripMenuItem.Name = "tecniciToolStripMenuItem";
            this.tecniciToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tecniciToolStripMenuItem.Text = "Tecnici";
            this.tecniciToolStripMenuItem.Click += new System.EventHandler(this.tecniciToolStripMenuItem_Click);
            // 
            // tipoInterventoToolStripMenuItem
            // 
            this.tipoInterventoToolStripMenuItem.Name = "tipoInterventoToolStripMenuItem";
            this.tipoInterventoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tipoInterventoToolStripMenuItem.Text = "Tipo intervento";
            this.tipoInterventoToolStripMenuItem.Click += new System.EventHandler(this.tipoInterventoToolStripMenuItem_Click);
            // 
            // testoScadenzeToolStripMenuItem
            // 
            this.testoScadenzeToolStripMenuItem.Name = "testoScadenzeToolStripMenuItem";
            this.testoScadenzeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.testoScadenzeToolStripMenuItem.Text = "Testo scadenze";
            this.testoScadenzeToolStripMenuItem.Click += new System.EventHandler(this.testoScadenzeToolStripMenuItem_Click);
            // 
            // tipoAlimentazioneToolStripMenuItem
            // 
            this.tipoAlimentazioneToolStripMenuItem.Name = "tipoAlimentazioneToolStripMenuItem";
            this.tipoAlimentazioneToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tipoAlimentazioneToolStripMenuItem.Text = "Tipo alimentazione";
            this.tipoAlimentazioneToolStripMenuItem.Click += new System.EventHandler(this.tipoAlimentazioneToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Location = new System.Drawing.Point(2, 24);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1000, 700);
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            // 
            // btnScaden
            // 
            this.btnScaden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScaden.Location = new System.Drawing.Point(123, 0);
            this.btnScaden.Name = "btnScaden";
            this.btnScaden.Size = new System.Drawing.Size(118, 23);
            this.btnScaden.TabIndex = 13;
            this.btnScaden.Text = "Scadenze";
            this.btnScaden.UseVisualStyleBackColor = true;
            this.btnScaden.Click += new System.EventHandler(this.btnScaden_Click);
            // 
            // btnDaFatt
            // 
            this.btnDaFatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaFatt.Location = new System.Drawing.Point(371, 0);
            this.btnDaFatt.Name = "btnDaFatt";
            this.btnDaFatt.Size = new System.Drawing.Size(118, 23);
            this.btnDaFatt.TabIndex = 14;
            this.btnDaFatt.Text = "Interv. da fatturare";
            this.btnDaFatt.UseVisualStyleBackColor = true;
            this.btnDaFatt.Click += new System.EventHandler(this.btnDaFatt_Click);
            // 
            // btnFatt
            // 
            this.btnFatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFatt.Location = new System.Drawing.Point(743, 0);
            this.btnFatt.Name = "btnFatt";
            this.btnFatt.Size = new System.Drawing.Size(118, 23);
            this.btnFatt.TabIndex = 15;
            this.btnFatt.Text = "Fatture";
            this.btnFatt.UseVisualStyleBackColor = true;
            this.btnFatt.Click += new System.EventHandler(this.btnFatt_Click);
            // 
            // zoneClientiToolStripMenuItem
            // 
            this.zoneClientiToolStripMenuItem.Name = "zoneClientiToolStripMenuItem";
            this.zoneClientiToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.zoneClientiToolStripMenuItem.Text = "Zone clienti";
            this.zoneClientiToolStripMenuItem.Click += new System.EventHandler(this.zoneClientiToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 725);
            this.Controls.Add(this.btnFatt);
            this.Controls.Add(this.btnDaFatt);
            this.Controls.Add(this.btnScaden);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnFrn);
            this.Controls.Add(this.btnMnu);
            this.Controls.Add(this.btnRic);
            this.Controls.Add(this.btnCnd);
            this.Controls.Add(this.btnAmm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cir";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.mnuTabell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAmm;
        private System.Windows.Forms.Button btnCnd;
        private System.Windows.Forms.Button btnRic;
        private System.Windows.Forms.Button btnMnu;
        private System.Windows.Forms.Button btnFrn;
        private System.Windows.Forms.ContextMenuStrip mnuTabell;
        private System.Windows.Forms.ToolStripMenuItem tecniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoInterventoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem testoScadenzeToolStripMenuItem;
        private System.Windows.Forms.Button btnScaden;
        private System.Windows.Forms.ToolStripMenuItem tipoAlimentazioneToolStripMenuItem;
        private System.Windows.Forms.Button btnDaFatt;
        private System.Windows.Forms.ToolStripMenuItem parametriToolStripMenuItem;
        private System.Windows.Forms.Button btnFatt;
        private System.Windows.Forms.ToolStripMenuItem zoneClientiToolStripMenuItem;
    }
}

