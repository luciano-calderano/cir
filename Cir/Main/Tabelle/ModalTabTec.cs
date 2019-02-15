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
    public partial class ModalFormTec : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public ModalFormTec()
        {
            InitializeComponent();
            this.ShowTec();
        }

        public void ShowTec ()
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
            this.listView.Columns.Add("Nome", this.listView.Width - 8, HorizontalAlignment.Left);

            String q = "SELECT * FROM tec ORDER BY tec_nom LIMIT 100";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["tec_id"].ToString());
                item.SubItems.Add(row["tec_nom"].ToString());
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

            this.lblIdTec.Text = item.Text;
            this.txtNome.Text = item.SubItems[1].Text;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.lblIdTec.Text = "";
            this.txtNome.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.lblIdTec.Text == "")
                this.newIdTec();

            clsDB.QueryString = "UPDATE tec SET tec_nom=$1 WHERE tec_id=$2";
            clsDB.QueryReplace(1, this.txtNome.Text);
            clsDB.QueryReplace(2, this.lblIdTec.Text);
            clsDB.QueryExec();
            this.ShowTec();
        }

        private void newIdTec ()
        {
            int _id = 0;
            string q = "SELECT MAX(tec_id) FROM tec";
            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count > 0)
                int.TryParse(dt.Rows[0][0].ToString(), out _id);
            lblIdTec.Text = (_id + 1).ToString();

            clsDB.QueryString = "INSERT INTO tec (tec_id) VALUES ('" + lblIdTec.Text + "')";
            clsDB.QueryExec();
        }
    }
}
