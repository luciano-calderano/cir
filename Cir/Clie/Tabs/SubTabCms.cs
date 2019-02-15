using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Clie.Tabs
{
    public partial class SubTabCms : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;

        public SubTabCms()
        {
            InitializeComponent();
        }

        private void SubTabCms_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                ShowCms();
        }

        private DataTable dataTableListCms;
        public void ShowCms()
        {
            this.ShowCms(99);
        }
        public void ShowCms(int tipo)
        {
            myGlobal.defaultListView(listViewCms);

            this.listViewCms.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("", 10, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("Descrizione", 460, HorizontalAlignment.Left);
            this.listViewCms.Columns.Add("Importo", 80, HorizontalAlignment.Right);
            this.listViewCms.Columns.Add("Scadenza", 90, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("Interv.", 50, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("Costo", 80, HorizontalAlignment.Right);

            String q = "SELECT  cms.*, COUNT(DISTINCT int_id) AS numint, SUM(intRig_imp) AS totale FROM cms";
            q += " LEFT JOIN interv ON int_cms_id=cms_id";
            q += " LEFT JOIN intrig ON intrig_int_id=int_id";
            q += " WHERE cms_cli_id='" + myGlobal.cli_id + "'";
            if (tipo < 99)
            {
                q += " AND cms_tip='" + tipo.ToString() + "'";
            }
            q += " GROUP BY cms_id ORDER BY cms_scaden desc";

            dataTableListCms = clsDB.QueryDataTable(q);
            foreach (DataRow row in dataTableListCms.Rows)
            {
                float fCms = 0;
                float.TryParse(row["cms_imp"].ToString(), out fCms);
                float fTot = 0;
                float.TryParse(row["totale"].ToString(), out fTot);

                ListViewItem item = new ListViewItem(row["cms_id"].ToString());
                item.SubItems.Add("");
                item.SubItems.Add(row["cms_descri"].ToString());
                item.SubItems.Add(fCms.ToString(myGlobal.fmtImporto));
                item.SubItems.Add(clsDB.dateFormatFromLong(row["cms_scaden"].ToString()));
                item.SubItems.Add(row["numint"].ToString());
                item.SubItems.Add(fTot.ToString(myGlobal.fmtImporto));
                int i = System.Convert.ToInt32(row["cms_tip"]);
                Color c;
                switch (i)
                {
                    case 1:
                        c = Color.Green;
                        break;
                    case 2:
                        c = Color.Red;
                        break;
                    default:
                        c = Color.Blue;
                        break;
                }
                item.SubItems[1].BackColor = c;
                item.UseItemStyleForSubItems = false;
                this.listViewCms.Items.Add(item);
            }
        }

        private void listViewCms_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            DataRow row = dataTableListCms.Rows[lv.SelectedItems[0].Index];

            myGlobal.cms_id = item.Text;
            Cir.Modal.ModalFormCms frmCms = new Cir.Modal.ModalFormCms(row);
            var result = frmCms.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowCms();
        }

        private void btnNewCms_Click(object sender, EventArgs e)
        {
            myGlobal.ric_id = "";
            myGlobal.cms_id = "";
            Cir.Modal.ModalFormCms frmCms = new Cir.Modal.ModalFormCms();
            var result = frmCms.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowCms();
        }

        private void listViewCms_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.FocusedItem.Bounds.Contains(e.Location) == false)
                return;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            DataRow row = dataTableListCms.Rows[lv.SelectedItems[0].Index];

            myGlobal.cms_id = item.Text;
            this.Tag = item.SubItems[2].Text;
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip mnu = new ContextMenuStrip();
                ToolStripMenuItem mnuFlt = new ToolStripMenuItem("Filtra interventi");
                ToolStripMenuItem mnuInt = new ToolStripMenuItem("Nuovo intervento");
                ToolStripMenuItem mnuStm = new ToolStripMenuItem("Stampa");

                mnuFlt.Click += new EventHandler(mnuFlt_Click);
                mnuInt.Click += new EventHandler(mnuInt_Click);
                mnuStm.Click += new EventHandler(mnuStm_Click);

                mnu.Items.AddRange(new ToolStripItem[] { mnuFlt, mnuInt, new ToolStripSeparator(), mnuStm });
                this.listViewCms.ContextMenuStrip = mnu;
            }
            else
            {
                Cir.Modal.ModalFormCms frmCms = new Cir.Modal.ModalFormCms(row);
                var result = frmCms.ShowDialog();
                if (result == DialogResult.OK)
                    this.ShowCms();
            }
        }
        private void mnuFlt_Click(object sender, EventArgs e)
        {
          //  this.ShowInt(myGlobal.cms_id);
        }

        private void mnuInt_Click(object sender, EventArgs e)
        {
            myGlobal.ric_id = "";
            Cir.SubForm.ModalFormInterv modal = new Cir.SubForm.ModalFormInterv();
            var result = modal.ShowDialog();
            //if (result == DialogResult.OK)
          //      this.ShowInt();
        }

        private void mnuStm_Click(object sender, EventArgs e)
        {
        }

 

        private void btnCms_Click(object sender, EventArgs e)
        {
            this.ShowCms(0);
        }

        private void btnCnt_Click(object sender, EventArgs e)
        {
            this.ShowCms(1);
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            this.ShowCms(2);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.ShowCms();
        }
    }
}
