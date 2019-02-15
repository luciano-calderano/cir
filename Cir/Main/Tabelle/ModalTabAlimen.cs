using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Tabelle
{
    public partial class ModalTabAlimen : Form
    {

        private ClsDataBase clsDB = ClsDataBase.Instance;

        public ModalTabAlimen()
        {
            InitializeComponent();
            this.ShowAlimen();
        }

        public void ShowAlimen ()
        {
            this.btnNew.Show();
            this.btnSave.Hide();

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

            String q = "SELECT * FROM tabAlimen ORDER BY alimen_des LIMIT 100";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["alimen_id"].ToString());
                item.SubItems.Add(row["alimen_des"].ToString());
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

            this.btnNew.Show();
            this.btnSave.Show();
            this.lblId.Text = item.Text;
            this.txtDes.Text = item.SubItems[1].Text;
            this.txtDes.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.btnNew.Hide();
            this.btnSave.Show();
            this.lblId.Text = "";
            this.txtDes.Text = "";
            this.txtDes.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtDes.Text == "")
                return;
            if (this.lblId.Text == "")
                this.newIdAlimen();

            clsDB.QueryString = "UPDATE tabalimen SET alimen_des=$1 WHERE alimen_id=$2";
            clsDB.QueryReplace(1, this.txtDes.Text);
            clsDB.QueryReplace(2, this.lblId.Text);
            clsDB.QueryExec();

            this.lblId.Text = "";
            this.txtDes.Text = "";
            this.ShowAlimen();
        }

        private void newIdAlimen ()
        {
            int _id = 0;
            string q = "SELECT MAX(alimen_id) FROM tabalimen";
            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count > 0)
                int.TryParse(dt.Rows[0][0].ToString(), out _id);
            lblId.Text = (_id + 1).ToString();

            clsDB.QueryString = "INSERT INTO tabalimen (alimen_id) VALUES ('" + lblId.Text + "')";
            clsDB.QueryExec();
        }
    }
}
