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
    public partial class SubTabFat : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Classi.ClsDbGet dbGet = new Cir.Classi.ClsDbGet();

        public SubTabFat()
        {
            InitializeComponent();
        }
        private void SubTabFat_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                ShowFat();
        }

        private void ShowFat()
        {
            myGlobal.defaultListView(listView);

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Data", 80, HorizontalAlignment.Center);
            this.listView.Columns.Add("", 30, HorizontalAlignment.Center);
            this.listView.Columns.Add("Numero", 80, HorizontalAlignment.Right);
            this.listView.Columns.Add("Importo", 80, HorizontalAlignment.Right);
            this.listView.Columns.Add("Commessa", 600, HorizontalAlignment.Left);

            String q = "SELECT fat_id,fat_dat,fat_num,fat_tot,fat_ndc,cms_descri FROM Fat ";
            q += " LEFT JOIN Cms ON cms_id=fat_cms_id";
            q += " WHERE fat_cli_id='" + myGlobal.cli_id + "'";
            q += " GROUP BY fat_id";
            q += " ORDER BY fat_dat DESC,fat_num DESC";
            DataTable dt = clsDB.QueryDataTable(q);

            foreach (DataRow row in dt.Rows)
            {
                dbGet.setRow(row);
                myGlobal.ClsDocument doc = myGlobal.listDocument[dbGet.getInt("fat_ndc")];
                ListViewItem item = new ListViewItem(dbGet.getStr("fat_id"));
                item.SubItems.Add(dbGet.getDat("fat_dat"));
                item.SubItems.Add(doc.strCode);
                item.SubItems.Add(dbGet.getStr("fat_num"));
                string strImp = dbGet.getImp("fat_tot");

//                if (dbGet.getInt("fat_ndc") == 1)
//                    strImp += "-";
                item.SubItems.Add(strImp);
                item.SubItems.Add(dbGet.getStr("cms_descri"));
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void btnNewFat_Click(object sender, EventArgs e)
        {
            Cir.Fatt.ModalFatCreate modal = new Cir.Fatt.ModalFatCreate();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowFat();
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];

            Cir.Clie.Modal.ModalFatRigMod modal = new Cir.Clie.Modal.ModalFatRigMod (item.Text);
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                ShowFat();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
