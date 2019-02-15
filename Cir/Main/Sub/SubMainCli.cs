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
    public partial class SubMainCli : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;

        public SubMainCli()
        {
            InitializeComponent();
        }

        private void SubFormCli_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                return;
            this.txtSrch.Text = "";
            this.ShowCli();
        }

        public void ShowCli ()
        {
            myGlobal.defaultListView(listView);

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Nome", 300, HorizontalAlignment.Left);
            this.listView.Columns.Add("Indirizzo", 425, HorizontalAlignment.Left);
            this.listView.Columns.Add("Amministratore", 240, HorizontalAlignment.Left);

            string strIniz = txtSrch.Text;
            string check;
            if (checkHidden.Checked == true)
            {
                check = "1";
                strIniz = "";
            }
            else
            {
                check = "0";
                if (strIniz == "")
                    strIniz = "A";
            }
            String q = "SELECT * FROM cli";
            q += " LEFT JOIN amm ON cli_amm_id=amm_id";
            q += " WHERE cli_hidden='" + check + "' AND cli_nom LIKE '" + strIniz.Replace("'", "''").ToUpper() + "%' ORDER BY cli_nom";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["cli_id"].ToString());
                item.ToolTipText = row["cli_not"].ToString();
                item.SubItems.Add(row["cli_nom"].ToString());
                item.SubItems.Add(row["cli_ind"].ToString());
                string s = "";
                if (row["amm_id"].ToString() != "0")
                    s = row["amm_nom"].ToString();
                item.SubItems.Add(s);
                if (row["amm_hidden"].ToString() != "0")
                    item.SubItems[3].BackColor = Color.LightGray;
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            this.ShowCli();
        }

        private void btnCliNew_Click(object sender, EventArgs e)
        {
            myGlobal.cli_id = "";
            Cir.SubForm.ModalFormCli frmCliUpdate = new Cir.SubForm.ModalFormCli();
            var result = frmCliUpdate.ShowDialog();
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listView.FocusedItem.Bounds.Contains(e.Location) == false)
                return;
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.cli_id = item.Text;

            if (e.Button == MouseButtons.Right)
            {
                string strZona = "? Zona ?";
                String q = "SELECT cli_zone_id, tabZone.* FROM cli";
                q += " JOIN tabZone ON cli_zone_id=zone_id";
                q += " WHERE cli_id='" + myGlobal.cli_id + "'";
                DataTable dt = clsDB.QueryDataTable(q);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    strZona = row["zone_desc"].ToString();
                }

                string s = (this.checkHidden.Checked) ? "Riattivo" : "Nascondo";
                s += " il cliente";
                ContextMenuStrip mnu = new ContextMenuStrip();
                ToolStripMenuItem mnuCli = new ToolStripMenuItem("Scheda cliente");
                ToolStripMenuItem mnuSch = new ToolStripMenuItem("Scheda impianto");
                ToolStripMenuItem mnuCms = new ToolStripMenuItem("Commesse/Contratti");
                ToolStripMenuItem mnuInt = new ToolStripMenuItem("Nuovo intervento");
                ToolStripMenuItem mnuRic = new ToolStripMenuItem("Nuova richiesta");
                ToolStripMenuItem mnuAmm = new ToolStripMenuItem("Cambia amministratore");
                ToolStripMenuItem mnuHid = new ToolStripMenuItem(s);
                ToolStripMenuItem mnuZon = new ToolStripMenuItem(strZona);

                mnuCli.Click += new EventHandler(mnuCli_Click);
                mnuSch.Click += new EventHandler(mnuSch_Click);
                mnuCms.Click += new EventHandler(mnuCms_Click);
                mnuInt.Click += new EventHandler(mnuInt_Click);
                mnuRic.Click += new EventHandler(mnuRic_Click);
                mnuAmm.Click += new EventHandler(mnuAmm_Click);
                mnuHid.Click += new EventHandler(mnuHid_Click);
                mnuZon.Click += new EventHandler(mnuZon_Click);

                mnu.Items.AddRange(new ToolStripItem[] { mnuCli, mnuSch, new ToolStripSeparator(), mnuCms, mnuInt, mnuRic, new ToolStripSeparator(), mnuAmm, mnuHid, new ToolStripSeparator(), mnuZon });
                this.listView.ContextMenuStrip = mnu;
            }
            else
            {
                myGlobal.frmMain.Hide();
                Clie.FrmClie frm = new Clie.FrmClie();
            }
        }

        private void mnuHid_Click(object sender, EventArgs e)
        {
            string s = (this.checkHidden.Checked) ? "0" : "1";

            clsDB.QueryString = "UPDATE cli SET cli_hidden=$1 WHERE cli_id=$2";
            clsDB.QueryReplace(1, s);
            clsDB.QueryReplace(2, myGlobal.cli_id);
            clsDB.QueryExec();
            this.ShowCli();

        }
        private void mnuCli_Click(object sender, EventArgs e)
        {
            myGlobal.frmMain.Hide();
            Cir.Clie.FrmClie frm = new Cir.Clie.FrmClie();
        }

        private void mnuSch_Click(object sender, EventArgs e)
        {
            Cir.Clie.Modal.FrmScheda frm = new Cir.Clie.Modal.FrmScheda();
            frm.Show();
        }

        private void mnuAmm_Click(object sender, EventArgs e)
        {
            myGlobal.ric_id = "";
            Cir.Modal.ModalFormAmm modal = new Cir.Modal.ModalFormAmm();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowCli();
        }

        private void mnuCms_Click(object sender, EventArgs e)
        {
            Cir.Clie.FrmCms frmCms = new Clie.FrmCms();
            frmCms.Show();
        }

        private void mnuInt_Click(object sender, EventArgs e)
        {
            Cir.SubForm.ModalFormInterv frmInt = new Cir.SubForm.ModalFormInterv();
            frmInt.Show();
        }

        private void mnuRic_Click(object sender, EventArgs e)
        {
            myGlobal.ric_id = "";
            Cir.Modal.ModalFormRic modal = new Cir.Modal.ModalFormRic();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowCli();
        }

        private void checkHidden_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowCli();
        }

        private void mnuZon_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalFormZone modal = new Cir.Modal.ModalFormZone(true);
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
            {
                string s = modal.strZoneId;
                clsDB.QueryString = "UPDATE cli SET cli_zone_id=$1 WHERE cli_id=$2";
                clsDB.QueryReplace(1, s);
                clsDB.QueryReplace(2, myGlobal.cli_id);
                clsDB.QueryExec();
            }
        }
    }
}
