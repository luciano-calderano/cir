namespace Cir
{
    partial class SubMainCli
    {

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView = new System.Windows.Forms.ListView();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkHidden = new System.Windows.Forms.CheckBox();
            this.btnNewCli = new System.Windows.Forms.Button();
            this.toolTipCli = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(5, 50);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(990, 645);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // txtSrch
            // 
            this.txtSrch.Location = new System.Drawing.Point(50, 12);
            this.txtSrch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(196, 22);
            this.txtSrch.TabIndex = 1;
            this.txtSrch.TextChanged += new System.EventHandler(this.txtSrch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cerca";
            // 
            // checkHidden
            // 
            this.checkHidden.AutoSize = true;
            this.checkHidden.ForeColor = System.Drawing.Color.White;
            this.checkHidden.Location = new System.Drawing.Point(907, 14);
            this.checkHidden.Margin = new System.Windows.Forms.Padding(4);
            this.checkHidden.Name = "checkHidden";
            this.checkHidden.Size = new System.Drawing.Size(80, 20);
            this.checkHidden.TabIndex = 24;
            this.checkHidden.Text = "Nascosti";
            this.checkHidden.UseVisualStyleBackColor = true;
            this.checkHidden.CheckedChanged += new System.EventHandler(this.checkHidden_CheckedChanged);
            // 
            // btnNewCli
            // 
            this.btnNewCli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCli.Location = new System.Drawing.Point(754, 9);
            this.btnNewCli.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewCli.Name = "btnNewCli";
            this.btnNewCli.Size = new System.Drawing.Size(130, 28);
            this.btnNewCli.TabIndex = 25;
            this.btnNewCli.Text = "Nuovo cliente";
            this.btnNewCli.UseVisualStyleBackColor = true;
            this.btnNewCli.Click += new System.EventHandler(this.btnCliNew_Click);
            // 
            // SubFormCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnNewCli);
            this.Controls.Add(this.checkHidden);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSrch);
            this.Controls.Add(this.listView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubFormCli";
            this.Text = "FormCnd";
            this.VisibleChanged += new System.EventHandler(this.SubFormCli_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkHidden;
        private System.Windows.Forms.Button btnNewCli;
        private System.Windows.Forms.ToolTip toolTipCli;
        private System.ComponentModel.IContainer components;
    }
}