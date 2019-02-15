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
    public partial class ModalFormZone : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public string strZoneId = "";
        public ModalFormZone()
        {
            InitializeComponent();
            this.ShowZone();
        }

        public ModalFormZone(bool soloLettura)
        {
            InitializeComponent();
            if (soloLettura == true)
            {
                this.Height = 280;
            }
            this.ShowZone();
        }

        public void ShowZone ()
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

            String q = "SELECT * FROM tabZone WHERE zone_id > '0' ORDER BY zone_desc";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["zone_id"].ToString());
                item.SubItems.Add(row["zone_desc"].ToString());
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

            strZoneId = item.Text;
            this.lblId.Text = item.Text;
            this.txtTipDescri.Text = item.SubItems[1].Text;
            if (this.Height == 280)
                this.DialogResult = DialogResult.OK;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.lblId.Text = "";
            this.txtTipDescri.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.lblId.Text == "")
                this.newIdTip();

            clsDB.QueryString = "UPDATE tabZone SET zone_desc=$1 WHERE zone_id=$2";
            clsDB.QueryReplace(1, this.txtTipDescri.Text);
            clsDB.QueryReplace(2, this.lblId.Text);
            clsDB.QueryExec();
            this.ShowZone();
        }

        private void newIdTip ()
        {
            lblId.Text = clsDB.nextId("tabZone", "zone_id");
            clsDB.QueryString = "INSERT INTO tabZone (zone_id) VALUES ('" + lblId.Text + "')";
            clsDB.QueryExec();
        }
    }
}
