using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir
{
    public partial class SubMainRic : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public SubMainRic()
        {
            InitializeComponent();
        }

        private void ShowRic ()
        {
            myGlobal.defaultListView(listView);

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Data", 80, HorizontalAlignment.Left);
            this.listView.Columns.Add("Cliente", 360, HorizontalAlignment.Left);
            this.listView.Columns.Add("Descrizione", 500, HorizontalAlignment.Left);
            this.listView.Columns.Add("Chiusa", 0, HorizontalAlignment.Left);
            this.listView.Columns.Add("Cli_Id", 0, HorizontalAlignment.Left);


            String s = "SELECT * FROM ric INNER JOIN cli ON ric_cli_id=cli_id";
            s += " WHERE ric_closed=";
            s += (this.checkChiuse.Checked) ? "'1'" : "'0'";
            s += " ORDER BY ric_dat,cli_nom LIMIT 200";

            DataTable dt = clsDB.QueryDataTable(s);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ric_id"].ToString());
                item.SubItems.Add(clsDB.dateFormatFromLong(row["ric_dat"].ToString()));
                item.SubItems.Add(row["cli_nom"].ToString());
                item.SubItems.Add(row["ric_des"].ToString());
                string strClosed = row["ric_closed"].ToString();
                item.SubItems.Add(strClosed);
                if (strClosed == "1")
                {
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        item.SubItems[i].BackColor = Color.LightGray;
                    }
                }
                item.SubItems.Add(row["cli_id"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void SubFormRic_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                return;
            this.ShowRic();
        }

        private void listView_Click(object sender, EventArgs e)
        {
        }

        private void checkTutte_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowRic();
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.cli_id = item.SubItems[5].Text;
            myGlobal.cms_id = item.SubItems[7].Text;
            myGlobal.ric_id = item.Text;
            Cir.Modal.ModalFormRic modal = new Cir.Modal.ModalFormRic();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowRic();
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listView.FocusedItem.Bounds.Contains(e.Location) == false)
                return;
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = this.listView.SelectedItems[0];
                myGlobal.ric_id = item.Text;
                myGlobal.cli_id = item.SubItems[5].Text;

                string s = (this.checkChiuse.Checked) ? "Riattivo" : "Chiudo";
                s += " la richiesta";
                ContextMenuStrip mnu = new ContextMenuStrip();
                ToolStripMenuItem mnuCli = new ToolStripMenuItem("Scheda cliente");
                ToolStripMenuItem mnuMod = new ToolStripMenuItem("Modifica");
                ToolStripMenuItem mnuHid = new ToolStripMenuItem(s);

                mnuCli.Click += new EventHandler(mnuCli_Click);
                mnuMod.Click += new EventHandler(mnuMod_Click);
                mnuHid.Click += new EventHandler(mnuHid_Click);

                mnu.Items.AddRange(new ToolStripItem[] { mnuCli, mnuMod, mnuHid });
                this.listView.ContextMenuStrip = mnu;
            }
        }

        private void mnuCli_Click(object sender, EventArgs e)
        {
            myGlobal.frmMain.Hide();
            Cir.Clie.FrmClie frm = new Cir.Clie.FrmClie();
        }
        private void mnuMod_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalFormRic modal = new Cir.Modal.ModalFormRic();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowRic();
        }
        private void mnuCms_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalFormCms modal = new Cir.Modal.ModalFormCms();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowRic();
        }
        private void mnuInt_Click(object sender, EventArgs e)
        {
            Cir.SubForm.ModalFormInterv modal = new Cir.SubForm.ModalFormInterv();
            var result = modal.ShowDialog();
        }
        private void mnuHid_Click(object sender, EventArgs e)
        {
            string s = (this.checkChiuse.Checked) ? "0" : "1";

            clsDB.QueryString = "UPDATE ric SET ric_closed=$1 WHERE ric_id=$2";
            clsDB.QueryReplace(1, s);
            clsDB.QueryReplace(2, myGlobal.ric_id);
            clsDB.QueryExec();
            this.ShowRic();

        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            myGlobal.ric_id = "";
//            Cir.Modal.ModalFormRic modal = new Cir.Modal.ModalFormRic();
//            var result = modal.ShowDialog();
        }
    }
}
