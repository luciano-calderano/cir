namespace Cir.Fatt
{
    partial class ModalFatCreate
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
            this.listViewFat = new System.Windows.Forms.ListView();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPageCms = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewCms = new System.Windows.Forms.ListView();
            this.tabPageInt = new System.Windows.Forms.TabPage();
            this.treeView = new System.Windows.Forms.TreeView();
            this.tabPageFat = new System.Windows.Forms.TabPage();
            this.panelFat = new System.Windows.Forms.Panel();
            this.tabCtrl.SuspendLayout();
            this.tabPageCms.SuspendLayout();
            this.tabPageInt.SuspendLayout();
            this.tabPageFat.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFat
            // 
            this.listViewFat.LabelEdit = true;
            this.listViewFat.Location = new System.Drawing.Point(3, 3);
            this.listViewFat.Name = "listViewFat";
            this.listViewFat.Size = new System.Drawing.Size(966, 254);
            this.listViewFat.TabIndex = 40;
            this.listViewFat.UseCompatibleStateImageBehavior = false;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPageCms);
            this.tabCtrl.Controls.Add(this.tabPageInt);
            this.tabCtrl.Controls.Add(this.tabPageFat);
            this.tabCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrl.Location = new System.Drawing.Point(12, 12);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(980, 288);
            this.tabCtrl.TabIndex = 46;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            // 
            // tabPageCms
            // 
            this.tabPageCms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPageCms.Controls.Add(this.label6);
            this.tabPageCms.Controls.Add(this.label5);
            this.tabPageCms.Controls.Add(this.listViewCms);
            this.tabPageCms.Location = new System.Drawing.Point(4, 24);
            this.tabPageCms.Name = "tabPageCms";
            this.tabPageCms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCms.Size = new System.Drawing.Size(972, 260);
            this.tabPageCms.TabIndex = 0;
            this.tabPageCms.Text = "Commesse / Contratti";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(98, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 47;
            this.label6.Text = "Da fatturare";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(6, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Fatturati";
            // 
            // listViewCms
            // 
            this.listViewCms.CheckBoxes = true;
            this.listViewCms.Location = new System.Drawing.Point(6, 6);
            this.listViewCms.Name = "listViewCms";
            this.listViewCms.Size = new System.Drawing.Size(960, 233);
            this.listViewCms.TabIndex = 45;
            this.listViewCms.UseCompatibleStateImageBehavior = false;
            this.listViewCms.SelectedIndexChanged += new System.EventHandler(this.listViewCms_SelectedIndexChanged);
            this.listViewCms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewCms_MouseClick);
            // 
            // tabPageInt
            // 
            this.tabPageInt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPageInt.Controls.Add(this.treeView);
            this.tabPageInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageInt.Location = new System.Drawing.Point(4, 24);
            this.tabPageInt.Name = "tabPageInt";
            this.tabPageInt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInt.Size = new System.Drawing.Size(972, 260);
            this.tabPageInt.TabIndex = 1;
            this.tabPageInt.Text = "Interventi a pagamento";
            // 
            // treeView
            // 
            this.treeView.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(963, 254);
            this.treeView.TabIndex = 45;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // tabPageFat
            // 
            this.tabPageFat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPageFat.Controls.Add(this.listViewFat);
            this.tabPageFat.Location = new System.Drawing.Point(4, 24);
            this.tabPageFat.Name = "tabPageFat";
            this.tabPageFat.Size = new System.Drawing.Size(972, 260);
            this.tabPageFat.TabIndex = 2;
            this.tabPageFat.Text = "Ultime fatture emesse";
            // 
            // panelFat
            // 
            this.panelFat.BackColor = System.Drawing.Color.Gray;
            this.panelFat.Location = new System.Drawing.Point(0, 296);
            this.panelFat.Name = "panelFat";
            this.panelFat.Size = new System.Drawing.Size(1004, 429);
            this.panelFat.TabIndex = 57;
            // 
            // ModalFatCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 725);
            this.Controls.Add(this.panelFat);
            this.Controls.Add(this.tabCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModalFatCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fatturazione interventi";
            this.tabCtrl.ResumeLayout(false);
            this.tabPageCms.ResumeLayout(false);
            this.tabPageCms.PerformLayout();
            this.tabPageInt.ResumeLayout(false);
            this.tabPageFat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFat;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPageCms;
        private System.Windows.Forms.TabPage tabPageInt;
        private System.Windows.Forms.ListView listViewCms;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabPage tabPageFat;
        private System.Windows.Forms.Panel panelFat;
    }
}