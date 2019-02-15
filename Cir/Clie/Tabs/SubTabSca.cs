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
    public partial class SubTabSca : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public SubTabSca()
        {
            InitializeComponent();
        }

        private void SubTabSca_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                ShowSca();
        }
        public void ShowSca()
        {
            myGlobal.defaultListView(listViewSca);

            this.listViewSca.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewSca.Columns.Add("Data", 100, HorizontalAlignment.Center);
            this.listViewSca.Columns.Add("Descrizione", 820, HorizontalAlignment.Left);
            String q;
            q = "SELECT * FROM scaden ";
            q += " WHERE scaden_cli_id='" + myGlobal.cli_id + "' ";
            q += " ORDER BY scaden_dat";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["scaden_id"].ToString());
                string s = clsDB.dateFormatFromDB(row["scaden_dat"]);
                item.SubItems.Add(s);
                s = row["scaden_des"].ToString();
                if (s.Length > 100)
                    s = s.Substring(0, 100) + " ...";
                item.SubItems.Add(s);

                item.UseItemStyleForSubItems = false;
                this.listViewSca.Items.Add(item);
            }
        }

        private void listViewSca_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.scaden_id = item.Text;
            Cir.Clie.Modal.ModalCliSca modal = new Cir.Clie.Modal.ModalCliSca();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowSca();
        }

        private void btnNewSca_Click(object sender, EventArgs e)
        {
            myGlobal.scaden_id = "";
            Cir.Clie.Modal.ModalCliSca modal = new Cir.Clie.Modal.ModalCliSca();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowSca();
        }
    }
}
