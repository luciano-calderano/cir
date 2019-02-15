using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Clie.Modal
{
    public partial class ModalCliScaden : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        string strCli_id;
        string strScaden_id;
        string strScaden_tip_id = "0";

        DataTable dtTabScaden;
        public ModalCliScaden()
        {
            strScaden_id = myGlobal.scaden_id;
            strCli_id = myGlobal.cli_id;
            this.start();
        }

        public ModalCliScaden(string idCli)
        {
            strScaden_id = "";
            strCli_id = idCli;
            this.start();
        }

        private void start()
        {
            InitializeComponent();

            String q = "SELECT * FROM tabScaden ORDER BY tabScaden_des";
            dtTabScaden = clsDB.QueryDataTable(q);
            foreach (DataRow row in dtTabScaden.Rows)
                comboBox.Items.Add(row["tabScaden_des"].ToString());

            this.ShowScaden();
        }

        private void ShowScaden()
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
            this.listView.Columns.Add("Data", 70, HorizontalAlignment.Left);
            this.listView.Columns.Add("Descrizione", 400, HorizontalAlignment.Left);
            this.listView.Columns.Add("DataDB", 0, HorizontalAlignment.Left);

            String q = "SELECT * FROM scaden WHERE scaden_cli_id='" + strCli_id + "' ORDER BY scaden_dat DESC";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["scaden_id"].ToString());
                item.SubItems.Add(clsDB.dateFormatFromLong(row["scaden_dat"].ToString()));
                item.SubItems.Add(row["scaden_des"].ToString());
                item.SubItems.Add(row["scaden_dat"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
            if (strScaden_id != "")
                this.ShowSelected();
        }

        private void ShowSelected () {
            string q = "SELECT * FROM scaden WHERE scaden_id='" + strScaden_id + "' ";
            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count == 0)
                return;
            DataRow row = dt.Rows[0];
            this.lblId.Text = row["scaden_id"].ToString();
            this.comboBox.Text = row["scaden_des"].ToString();
            datePicker.Value = clsDB.dateFromDB(row["scaden_dat"]);

            btnNew.Hide();
            btnSave.Show();
            this.comboBox.Focus();
        }

        private void listView_Click(object sender, EventArgs e)
        {
            btnNew.Show();
            btnSave.Show();
            this.comboBox.Focus();

            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];

            this.lblId.Text = item.Text;
            this.comboBox.Text = item.SubItems[2].Text;
            datePicker.Value = clsDB.dateFromDB(item.SubItems[3].Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblId.Text = "";
            comboBox.Text = "";
            datePicker.Value = DateTime.Today;

            btnNew.Hide();
            btnSave.Show();
            this.comboBox.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnNew.Show();
            btnSave.Hide();
            if (lblId.Text == "")
                this.newIdScaden();

            clsDB.QueryString = "UPDATE scaden SET scaden_dat=$1,scaden_des=$2,scaden_tip_id=$3 WHERE scaden_id=$99";
            clsDB.QueryReplace(1, this.datePicker.Value.ToString(myGlobal.fmtDataYMD));
            clsDB.QueryReplace(2, this.comboBox.Text);
            clsDB.QueryReplace(3, strScaden_tip_id);
            clsDB.QueryReplace(99, lblId.Text);
            clsDB.QueryExec();
            if (strScaden_id == "")
                this.ShowScaden();
            else
                this.DialogResult = DialogResult.OK;

        }
        private void newIdScaden()
        {
            lblId.Text = clsDB.nextId("scaden", "scaden_id");
            clsDB.QueryString = "INSERT INTO scaden (scaden_id,scaden_cli_id) VALUES ($1,$2)";
            clsDB.QueryReplace(1, lblId.Text);
            clsDB.QueryReplace(2, strCli_id);
            clsDB.QueryExec();
        }

        private void txtScaDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Elimino la scadenza ?", "Cancellazione", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            clsDB.QueryString = "DELETE FROM scaden WHERE scaden_id='" + lblId.Text + "'";
            clsDB.QueryExec();
            this.ShowScaden();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            strScaden_tip_id = dtTabScaden.Rows[comboBox.SelectedIndex]["tabscaden_id"].ToString();
        }
    }
}
