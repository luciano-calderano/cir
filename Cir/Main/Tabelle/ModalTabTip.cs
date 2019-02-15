using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Modal
{
    public partial class ModalFormTip : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public ModalFormTip()
        {
            InitializeComponent();
            this.ShowTip();
        }

        public void ShowTip ()
        {
            this.listView.Clear();
            this.listView.View = View.Details;
            this.listView.LabelEdit = false;
            this.listView.AllowColumnReorder = false;
            this.listView.CheckBoxes = false;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Sorting = SortOrder.None;

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Descrizione", this.listView.Width - 8, HorizontalAlignment.Left);

            String q = "SELECT * FROM tip ORDER BY tip_descri LIMIT 100";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["tip_id"].ToString());
                item.SubItems.Add(row["tip_descri"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];

            this.lblTipId.Text = item.Text;
            this.txtTipDescri.Text = item.SubItems[1].Text;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.lblTipId.Text = "";
            this.txtTipDescri.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.lblTipId.Text == "")
                this.newIdTip();

            clsDB.QueryString = "UPDATE tip SET tip_descri=$1 WHERE tip_id=$2";
            clsDB.QueryReplace(1, this.txtTipDescri.Text);
            clsDB.QueryReplace(2, this.lblTipId.Text);
            clsDB.QueryExec();
            this.ShowTip();
        }

        private void newIdTip ()
        {
            int _id = 0;
            string q = "SELECT MAX(tip_id) FROM tip";
            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count > 0)
                int.TryParse(dt.Rows[0][0].ToString(), out _id);
            lblTipId.Text = (_id + 1).ToString();

            clsDB.QueryString = "INSERT INTO tip (tip_id) VALUES ('" + lblTipId.Text + "')";
            clsDB.QueryExec();
        }
    }
}
