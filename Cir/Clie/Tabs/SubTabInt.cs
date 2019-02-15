using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Clie.Tabs
{
    public partial class SubTabInt : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private DataTable dtTip;
        private string strIntTip = "";
        private DataTable dtCms;
        private string strIntCms = "";

        public SubTabInt()
        {
            InitializeComponent();
            dateIniz.Value = DateTime.Today.AddYears(-1);
            FillCmbIntTip();
            FillCmbIntCms();
        }
        private void SubTabInt_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                ShowInt();
        }

        private void FillCmbIntTip()
        {
            cmbIntTip.Text = "Tutto";
            cmbIntTip.Items.Add(cmbIntTip.Text);
            String q = "SELECT * FROM tip";
            dtTip = clsDB.QueryDataTable(q);
            foreach (DataRow row in dtTip.Rows)
            {
                cmbIntTip.Items.Add(row["tip_descri"].ToString());
            }
        }

        private void FillCmbIntCms()
        {
            comboCms.Text = "Tutto";
            comboCms.Items.Add(comboCms.Text);
            String q = "SELECT * FROM cms WHERE cms_cli_id='" + myGlobal.cli_id + "' ORDER BY cms_datini DESC" ;
            dtCms = clsDB.QueryDataTable(q);
            foreach (DataRow row in dtCms.Rows)
            {
                comboCms.Items.Add(row["cms_descri"].ToString());
            }
        }

        public void ShowInt()
        {
            this.ShowInt("");
        }
        public void ShowInt(string cms_id)
        {
            myGlobal.defaultListView(listViewInt);

            this.listViewInt.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewInt.Columns.Add("Data", 80, HorizontalAlignment.Center);
            this.listViewInt.Columns.Add("Orario", 85, HorizontalAlignment.Center);
            this.listViewInt.Columns.Add("Descrizione", 500, HorizontalAlignment.Left);
            this.listViewInt.Columns.Add("Tipo", 300, HorizontalAlignment.Left);
            String q;
            q = "SELECT * FROM interv ";
            q += "LEFT JOIN tip ON int_tip_id=tip_id ";
            q += "LEFT JOIN cms ON int_cms_id=cms_id ";
            q += "LEFT JOIN fat ON int_fat_id=fat_id ";
            q += "WHERE int_cli_id='" + myGlobal.cli_id + "' ";
            q += " AND int_datIni BETWEEN '" + dateIniz.Value.ToString(myGlobal.fmtDataYMD) + "' AND '" + dateFine.Value.ToString(myGlobal.fmtDataYMD) + "'";
            if (strIntTip.Length > 0)
                q += " AND int_tip_id='" + strIntTip + "' ";
            else if (cms_id.Length > 0)
                q += " AND int_cms_id='" + cms_id + "' GROUP BY int_id ";
            q += " ORDER BY int_datIni DESC";

            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["int_id"].ToString());
                int i;
                string s = clsDB.dateFormatFromLong(row["int_datIni"].ToString());
                item.SubItems.Add(s);
                i = int.Parse(row["int_oraIni"].ToString());
                s = String.Format("{0:00}", i / 100) + ":" + String.Format("{0:00}", i % 100);
                i = int.Parse(row["int_oraFin"].ToString());
                s += " - " + String.Format("{0:00}", i / 100) + ":" + String.Format("{0:00}", i % 100);
                item.SubItems.Add(s);
                s = row["int_descri"].ToString();
                if (s.IndexOf("\n") > 0)
                    s = s.Substring(0, s.IndexOf("\n")) + "...";
                if (s.Length > 60)
                    s = s.Substring(0, 60) + " ...";
                item.SubItems.Add(s);

                s = row["cms_descri"].ToString();
                if (s.Length > 0)
                    s += " - ";
                if (row["fat_dat"].ToString().Length > 0)
                    s += "Fatt. n. ["+ row["fat_num"].ToString() + "] del " + clsDB.dateFormatFromDB (row["fat_dat"]);
                else if (s.Length == 0)
                    s = row["tip_descri"].ToString();
                if (s.Length > 40)
                    s = s.Substring(0, 40) + " ...";
                item.SubItems.Add(s);
                item.UseItemStyleForSubItems = false;
                this.listViewInt.Items.Add(item);
            }
        }

        private void cmbIntTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbIntTip.SelectedIndex;
            strIntTip = "";
            if (i > 0)
            {
                DataRow row = dtTip.Rows[i - 1];
                strIntTip = row["tip_id"].ToString();
            }
            this.ShowInt();
        }

        private void listViewInt_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.int_id = item.Text;
            myGlobal.cms_id = "";
            Cir.SubForm.ModalFormInterv modal = new Cir.SubForm.ModalFormInterv();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowInt();
        }

        private void btnNewInt_Click(object sender, EventArgs e)
        {
            myGlobal.int_id = "";
            myGlobal.cms_id = "";
            Cir.SubForm.ModalFormInterv modal = new Cir.SubForm.ModalFormInterv();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowInt();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.ShowInt();
        }

        private void comboCms_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboCms.SelectedIndex;
            strIntCms = "";
            if (i > 0)
            {
                DataRow row = dtCms.Rows[i - 1];
                strIntCms = row["cms_id"].ToString();
            }
            this.ShowInt(strIntCms);

        }

    }
}
