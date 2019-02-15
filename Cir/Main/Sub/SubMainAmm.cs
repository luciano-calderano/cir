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
    public partial class SubMainAmm : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public SubMainAmm()
        {
            InitializeComponent();
        }

        private void SubFormAmm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                this.ShowAmmLst();
        }

        private void ShowAmmLst()
        {
            myGlobal.defaultListView(listView);

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Nome", 240, HorizontalAlignment.Left);
            this.listView.Columns.Add("Telefono", 140, HorizontalAlignment.Left);
            this.listView.Columns.Add("Cellulare", 140, HorizontalAlignment.Left);
            this.listView.Columns.Add("Fax", 140, HorizontalAlignment.Left);
            this.listView.Columns.Add("e-mail", 140, HorizontalAlignment.Left);
            this.listView.Columns.Add("Pec", 140, HorizontalAlignment.Left);

            string hidden = checkBoxHidden.Checked ? "1" : "0";
            String q = "SELECT * FROM amm  WHERE amm_hidden='" + hidden + "' ORDER BY UPPER (amm_nom)";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["amm_id"].ToString());
                item.SubItems.Add(row["amm_nom"].ToString());
                item.SubItems.Add(row["amm_tel"].ToString());
                item.SubItems.Add(row["amm_cel"].ToString());
                item.SubItems.Add(row["amm_fax"].ToString());
                item.SubItems.Add(row["amm_eml"].ToString());
                item.SubItems.Add(row["amm_pec"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            myGlobal.amm_id = "";
            Cir.Modal.ModalAmmMod modal = new Cir.Modal.ModalAmmMod();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowAmmLst(); 
        }

     private void listView_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.amm_id = item.Text;
            Cir.Modal.ModalAmmMod modal = new Cir.Modal.ModalAmmMod();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowAmmLst();
        }


        private void checkBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowAmmLst();
        }
     }
}
