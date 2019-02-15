namespace Cir.Clie.Tabs
{
    partial class SubTabCms
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
            this.btnAll = new System.Windows.Forms.Button();
            this.btnCms = new System.Windows.Forms.Button();
            this.btnCnt = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.listViewCms = new System.Windows.Forms.ListView();
            this.btnNewCms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.Black;
            this.btnAll.Location = new System.Drawing.Point(376, 8);
            this.btnAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(63, 24);
            this.btnAll.TabIndex = 46;
            this.btnAll.Text = "Tutto";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnCms
            // 
            this.btnCms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCms.ForeColor = System.Drawing.Color.Navy;
            this.btnCms.Location = new System.Drawing.Point(126, 8);
            this.btnCms.Margin = new System.Windows.Forms.Padding(4);
            this.btnCms.Name = "btnCms";
            this.btnCms.Size = new System.Drawing.Size(120, 24);
            this.btnCms.TabIndex = 45;
            this.btnCms.Text = "Commesse";
            this.btnCms.UseVisualStyleBackColor = true;
            this.btnCms.Click += new System.EventHandler(this.btnCms_Click);
            // 
            // btnCnt
            // 
            this.btnCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCnt.ForeColor = System.Drawing.Color.Green;
            this.btnCnt.Location = new System.Drawing.Point(1, 8);
            this.btnCnt.Margin = new System.Windows.Forms.Padding(4);
            this.btnCnt.Name = "btnCnt";
            this.btnCnt.Size = new System.Drawing.Size(120, 24);
            this.btnCnt.TabIndex = 44;
            this.btnCnt.Text = "Contratti";
            this.btnCnt.UseVisualStyleBackColor = true;
            this.btnCnt.Click += new System.EventHandler(this.btnCnt_Click);
            // 
            // btnPre
            // 
            this.btnPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPre.Location = new System.Drawing.Point(251, 8);
            this.btnPre.Margin = new System.Windows.Forms.Padding(4);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(120, 24);
            this.btnPre.TabIndex = 43;
            this.btnPre.Text = "Preventivi";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // listViewCms
            // 
            this.listViewCms.Location = new System.Drawing.Point(4, 44);
            this.listViewCms.Name = "listViewCms";
            this.listViewCms.Size = new System.Drawing.Size(984, 420);
            this.listViewCms.TabIndex = 11;
            this.listViewCms.UseCompatibleStateImageBehavior = false;
            this.listViewCms.Click += new System.EventHandler(this.listViewCms_Click);
            // 
            // btnNewCms
            // 
            this.btnNewCms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewCms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCms.Location = new System.Drawing.Point(878, 4);
            this.btnNewCms.Name = "btnNewCms";
            this.btnNewCms.Size = new System.Drawing.Size(110, 32);
            this.btnNewCms.TabIndex = 15;
            this.btnNewCms.Text = "Inserisci";
            this.btnNewCms.UseVisualStyleBackColor = true;
            this.btnNewCms.Click += new System.EventHandler(this.btnNewCms_Click);
            // 
            // SubTabCms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(992, 468);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnCms);
            this.Controls.Add(this.listViewCms);
            this.Controls.Add(this.btnCnt);
            this.Controls.Add(this.btnNewCms);
            this.Controls.Add(this.btnPre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubTabCms";
            this.Text = "CliTabCms";
            this.VisibleChanged += new System.EventHandler(this.SubTabCms_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnCms;
        private System.Windows.Forms.Button btnCnt;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.ListView listViewCms;
        private System.Windows.Forms.Button btnNewCms;
    }
}