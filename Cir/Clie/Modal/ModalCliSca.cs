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
    public partial class ModalCliSca : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        string strScaden_tip_id = "0";

        DataTable dtTabScaden;
        public ModalCliSca()
        {
            this.start();
        }

        private void start()
        {
            InitializeComponent();
            LoadTabScaden();

            this.lblId.Text = myGlobal.scaden_id;
            String q = "SELECT * FROM scaden WHERE scaden_id='" + myGlobal.scaden_id + "' ";
            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count == 0)
                return;
            DataRow row = dt.Rows[0];
            this.lblId.Text = row["scaden_id"].ToString();
            this.comboBox.Text = row["scaden_des"].ToString();
            datePicker.Value = clsDB.dateFromDB(row["scaden_dat"]);

            this.comboBox.Focus();
        }

        void LoadTabScaden()
        {
            String q = "SELECT * FROM tabScaden ORDER BY tabScaden_des";
            dtTabScaden = clsDB.QueryDataTable(q);
            foreach (DataRow row in dtTabScaden.Rows)
                comboBox.Items.Add(row["tabScaden_des"].ToString());
        }

        private void listView_Click(object sender, EventArgs e)
        {
            this.comboBox.Focus();

            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];

            this.lblId.Text = item.Text;
            this.comboBox.Text = item.SubItems[2].Text;
            datePicker.Value = clsDB.dateFromDB(item.SubItems[3].Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblId.Text == "")
                this.newIdScaden();

            clsDB.QueryString = "UPDATE scaden SET scaden_dat=$1,scaden_des=$2,scaden_tip_id=$3 WHERE scaden_id=$99";
            clsDB.QueryReplace(1, this.datePicker.Value.ToString(myGlobal.fmtDataYMD));
            clsDB.QueryReplace(2, this.comboBox.Text);
            clsDB.QueryReplace(3, strScaden_tip_id);
            clsDB.QueryReplace(99, lblId.Text);
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void newIdScaden()
        {
            lblId.Text = clsDB.nextId("scaden", "scaden_id");
            clsDB.QueryString = "INSERT INTO scaden (scaden_id,scaden_cli_id) VALUES ($1,$2)";
            clsDB.QueryReplace(1, lblId.Text);
            clsDB.QueryReplace(2, myGlobal.cli_id);
            clsDB.QueryExec();
        }

        private void txtScaDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Elimino la scadenza ?", "Cancellazione", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            clsDB.QueryString = "DELETE FROM scaden WHERE scaden_id='" + lblId.Text + "'";
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            strScaden_tip_id = dtTabScaden.Rows[comboBox.SelectedIndex]["tabscaden_id"].ToString();
        }
    }
}
