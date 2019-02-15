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
    public partial class ModalAmmMod : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public ModalAmmMod()
        {
            InitializeComponent();
            lblId.Text = "";
            txtNom.Text = "";
            txtInd.Text = "";
            txtTel.Text = "";
            txtCel.Text = "";
            txtEml.Text = "";
            txtFax.Text = "";
            txtPec.Text = "";
            if (myGlobal.amm_id == "")
                return;
            clsDB.QueryString = "SELECT * FROM amm WHERE amm_id='" + myGlobal.amm_id + "'";
//            DataTable dt = clsDB.Query();
            clsDB.QueryDB();
            if (clsDB.dt.Rows.Count == 0)
                return;
            DataRow row = clsDB.dt.Rows[0];
            lblId.Text = row["amm_id"].ToString();
            txtNom.Text = row["amm_nom"].ToString();
            txtInd.Text = row["amm_ind"].ToString();
            txtCap.Text = row["amm_cap"].ToString();
            txtLoc.Text = row["amm_loc"].ToString();
            txtTel.Text = row["amm_tel"].ToString();
            txtCel.Text = row["amm_cel"].ToString();
            txtEml.Text = row["amm_eml"].ToString();
            txtFax.Text = row["amm_fax"].ToString();
            txtPec.Text = row["amm_pec"].ToString();

            this.listCli();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (myGlobal.amm_id == "")
            {
                myGlobal.amm_id = clsDB.nextId("amm", "amm_id");
                clsDB.QueryString = "INSERT INTO amm (amm_id) VALUES ($1)";
                clsDB.QueryReplace(1, myGlobal.amm_id);
                clsDB.QueryExec();
            }
            clsDB.QueryString = "UPDATE Amm SET amm_nom=$1,amm_tel=$2,amm_cel=$3,amm_eml=$4,amm_fax=$5,amm_pec=$6,amm_hidden=$7,amm_ind=$8,amm_cap=$9,amm_loc=$10 WHERE amm_id=$99";
            clsDB.QueryReplace(1, this.txtNom.Text);
            clsDB.QueryReplace(2, this.txtTel.Text);
            clsDB.QueryReplace(3, this.txtCel.Text);
            clsDB.QueryReplace(4, this.txtEml.Text);
            clsDB.QueryReplace(5, this.txtFax.Text);
            clsDB.QueryReplace(6, this.txtPec.Text);
            clsDB.QueryReplace(7, checkBoxHide.Checked ? "1" : "0");
            clsDB.QueryReplace(8, this.txtInd.Text);
            clsDB.QueryReplace(9, this.txtCap.Text);
            clsDB.QueryReplace(10, this.txtLoc.Text);
            clsDB.QueryReplace(99, myGlobal.amm_id);
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void listCli()
        {
            this.listViewCli.Clear();
            this.listViewCli.View = View.Details;
            this.listViewCli.LabelEdit = false;
            this.listViewCli.AllowColumnReorder = false;
            this.listViewCli.CheckBoxes = false;
            this.listViewCli.FullRowSelect = true;
            this.listViewCli.GridLines = true;
            this.listViewCli.Sorting = SortOrder.None;

            this.listViewCli.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewCli.Columns.Add("Cliente", listViewCli.Width - 10, HorizontalAlignment.Left);

            String q = "SELECT * FROM cli WHERE cli_amm_id='" + myGlobal.amm_id + "' ORDER BY cli_nom";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["cli_id"].ToString());
                item.SubItems.Add(row["cli_nom"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listViewCli.Items.Add(item);
            }
        }
    }
}
