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
    public partial class ModalTabScaden : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public ModalTabScaden()
        {
            InitializeComponent();
            this.ShowTabScaden();
        }

        public void ShowTabScaden()
        {
            btnNew.Show();
            btnSave.Hide();

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

            String q = "SELECT * FROM tabScaden ORDER BY tabScaden_des";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["tabScaden_id"].ToString());
                item.SubItems.Add(row["tabScaden_des"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            btnNew.Show();
            btnSave.Show();

            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];

            this.lblId.Text = item.Text;
            this.txtDes.Text = item.SubItems[1].Text;
            this.txtDes.Focus();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Hide();
            btnSave.Show();

            this.lblId.Text = "";
            this.txtDes.Text = "";
            this.txtDes.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnNew.Show();
            btnSave.Hide();
            if (this.lblId.Text == "")
                this.newIdTabScaden();

            clsDB.QueryString = "UPDATE tabScaden SET tabScaden_des=$1 WHERE tabScaden_id=$2";
            clsDB.QueryReplace(1, this.txtDes.Text);
            clsDB.QueryReplace(2, this.lblId.Text);
            clsDB.QueryExec();
            this.ShowTabScaden();
            this.lblId.Text = "";
            this.txtDes.Text = "";

        }

        private void newIdTabScaden()
        {
            int _id = 0;
            string q = "SELECT MAX(tabScaden_id) FROM tabScaden";
            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count > 0)
                int.TryParse(dt.Rows[0][0].ToString(), out _id);
            lblId.Text = (_id + 1).ToString();
            clsDB.QueryString = "INSERT INTO tabScaden (tabScaden_id) VALUES ('" + lblId.Text + "')";
            clsDB.QueryExec();
        }

   }
}
