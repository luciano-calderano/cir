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
    public partial class SubTabRic : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public SubTabRic()
        {
            InitializeComponent();
        }

        private void SubTabRic_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                ShowRic();
        }

        public void ShowRic()
        {
            myGlobal.defaultListView(listViewRic);

            this.listViewRic.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewRic.Columns.Add("Data", 100, HorizontalAlignment.Center);
            this.listViewRic.Columns.Add("Descrizione", 820, HorizontalAlignment.Left);
            string strClosed = (checkBoxClosed.Checked ? "1" : "0");
            String q;
            q = "SELECT * FROM ric ";
            q += " WHERE ric_cli_id='" + myGlobal.cli_id + "' ";
            q += " AND ric_closed='" + strClosed + "'";
            q += " ORDER BY ric_dat";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ric_id"].ToString());
                string s = clsDB.dateFormatFromDB(row["ric_dat"]);
                item.SubItems.Add(s);
                s = row["ric_des"].ToString();
                if (s.Length > 100)
                    s = s.Substring(0, 100) + " ...";
                item.SubItems.Add(s);

                item.UseItemStyleForSubItems = false;
                this.listViewRic.Items.Add(item);
            }
        }

        private void listViewRic_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.ric_id = item.Text;
            Cir.Modal.ModalFormRic modal = new Cir.Modal.ModalFormRic();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowRic();
        }

        private void btnNewRic_Click(object sender, EventArgs e)
        {
            myGlobal.ric_id = "";
            Cir.Modal.ModalFormRic modal = new Cir.Modal.ModalFormRic();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowRic();
        }

        private void checkBoxClosed_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowRic();
        }

    }
}
