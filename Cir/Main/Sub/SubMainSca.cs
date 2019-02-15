using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.SubForm
{
    public partial class SubMainScaden : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private string strTipScadenSel = "";
        private string strZonaSel = "";
        private int pagNum = 0;
        
        DataTable dtTabScaden;
        DataTable dtTabZone;
        public SubMainScaden()
        {
            InitializeComponent();
            InitCmbScadenTip();
            InitCmbScadenZone();
        }
        private void InitCmbScadenTip()
        {
            cmbScadenTip.Text = "Tutto";
            cmbScadenTip.Items.Add(cmbScadenTip.Text);
            String s = "SELECT * FROM tabscaden ORDER BY tabscaden_des";

            dtTabScaden = clsDB.QueryDataTable(s);
            foreach (DataRow row in dtTabScaden.Rows)
            {
                cmbScadenTip.Items.Add(row["tabscaden_des"].ToString());
            }
        }

        private void InitCmbScadenZone()
        {
            comboZone.Text = "Tutto";
            comboZone.Items.Add(cmbScadenTip.Text);
            String s = "SELECT * FROM tabZone ORDER BY zone_desc";

            dtTabZone = clsDB.QueryDataTable(s);
            foreach (DataRow row in dtTabZone.Rows)
            {
                comboZone.Items.Add(row["zone_desc"].ToString());
            }
        }

        private void SubFormScaden_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                this.ShowScaden();
        }

        private void ShowScaden()
        {
            myGlobal.defaultListView(listView);

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Data", 80, HorizontalAlignment.Left);
            this.listView.Columns.Add("Cliente", 380, HorizontalAlignment.Left);
            this.listView.Columns.Add("Descrizione", 350, HorizontalAlignment.Left);
            this.listView.Columns.Add("Cli_Id", 0, HorizontalAlignment.Left);
            this.listView.Columns.Add("Zona", 150, HorizontalAlignment.Left);

            string strWhere = "";
            if (strTipScadenSel.Length > 0)
                strWhere = " WHERE scaden_tip_id='" + strTipScadenSel + "'";
            if (strZonaSel.Length > 0)
            {
                if (strWhere.Length > 0)
                    strWhere += " AND";
                else
                    strWhere = " WHERE cli_zone_id";
                strWhere += " ='" + strZonaSel + "'";
            }

            String s = "SELECT cli_nom, cli_id, scaden.*, tabZone.* FROM scaden LEFT JOIN cli ON scaden_cli_id=cli_id LEFT JOIN tabZone ON cli_zone_id=zone_id ";
            s += strWhere;
            s += " ORDER BY scaden_dat LIMIT " + (pagNum * 100) + "," + (pagNum + 1) * 100;

            DataTable dt = clsDB.QueryDataTable(s);
            if (dt.Rows.Count < 100)
                btnNext.Hide();
            else
                btnNext.Show();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["scaden_id"].ToString());
                item.SubItems.Add(clsDB.dateFormatFromLong(row["scaden_dat"].ToString()));
                item.SubItems.Add(row["cli_nom"].ToString());
                item.SubItems.Add(row["scaden_des"].ToString());
                item.SubItems.Add(row["cli_id"].ToString());
                item.SubItems.Add(row["zone_desc"].ToString());
                this.listView.Items.Add(item);
            }
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ListViewItem item = this.listView.SelectedItems[0];
                    myGlobal.scaden_id = item.Text;
                    myGlobal.cli_id = item.SubItems[4].Text;

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

                    ContextMenuStrip mnu = new ContextMenuStrip();
                    ToolStripMenuItem mnuCli = new ToolStripMenuItem("Scheda cliente");
                    ToolStripMenuItem mnuMod = new ToolStripMenuItem("Modifica");
                    ToolStripMenuItem mnuZon = new ToolStripMenuItem(strZona);

                    mnuCli.Click += new EventHandler(mnuCli_Click);
                    mnuMod.Click += new EventHandler(mnuRic_Click);
                    mnuZon.Click += new EventHandler(mnuZon_Click);

                    mnu.Items.AddRange(new ToolStripItem[] { mnuCli, mnuMod, new ToolStripSeparator(), mnuZon });
                    this.listView.ContextMenuStrip = mnu;
                }
            }
        }
        private void mnuRic_Click(object sender, EventArgs e)
        {
            Cir.Clie.Modal.ModalCliScaden modal = new Cir.Clie.Modal.ModalCliScaden();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowScaden();
        }
        private void mnuCli_Click(object sender, EventArgs e)
        {
            Cir.Clie.FrmClie frm = new Cir.Clie.FrmClie();
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
                this.ShowScaden();
            }
        }

        private void cmbScadenTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            pagNum = 0;
            int i = cmbScadenTip.SelectedIndex;
            if (i == 0)
                strTipScadenSel = "";
            else
                strTipScadenSel = dtTabScaden.Rows[i - 1]["tabscaden_id"].ToString();
            ShowScaden();
        }

        private void comboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            pagNum = 0;
            int i = comboZone.SelectedIndex;
            if (i == 0)
                strZonaSel = "";
            else
                strZonaSel = dtTabZone.Rows[i - 1]["zone_id"].ToString();
            ShowScaden();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pagNum++;
            ShowScaden();
        }
    }
}
