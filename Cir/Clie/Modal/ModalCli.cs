using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.SubForm
{
    public partial class ModalFormCli : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;

        public ModalFormCli()
        {

            InitializeComponent();
            this.modifica();
        }

        private void modifica()
        {
            lblId.Text = myGlobal.cli_id;
            if (myGlobal.cli_id == "")
                return;
            String q = "SELECT * FROM cli WHERE cli_id='" + myGlobal.cli_id + "'";
            DataTable dt = clsDB.QueryDataTable(q);
            DataRow row = dt.Rows[0];

            txtNome.Text = row["cli_nom"].ToString();
            txtInd.Text = row["cli_ind"].ToString();
            txtCap.Text = row["cli_cap"].ToString();
            txtLoc.Text = row["cli_loc"].ToString();
            txtPrv.Text = row["cli_prv"].ToString();
            txtPiva.Text = row["cli_parIva"].ToString();
            txtCodFis.Text = row["cli_codFis"].ToString();
            txtCodImp.Text = row["cli_codImp"].ToString();
            txtNote.Text = row["cli_not"].ToString();
            if (row["cli_hidden"].ToString() == "1")
                checkHidden.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string q;
            if (myGlobal.cli_id == "")
            {
                int _id = 0;
                q = "SELECT MAX(cli_id) FROM cli";
                DataTable dt = clsDB.QueryDataTable(q);
                if (dt.Rows.Count > 0)
                    int.TryParse(dt.Rows[0][0].ToString(), out _id);
                lblId.Text = (_id + 1).ToString();
                q = "INSERT INTO cli (cli_id) VALUES ('" + lblId.Text + "')";
                clsDB.exec(q);
            }

            clsDB.QueryString = "UPDATE cli SET cli_nom=$1, cli_ind=$2, cli_cap=$3, cli_loc=$4, cli_prv=$5, cli_parIva=$6, cli_codFis=$7, cli_not=$8, cli_codimp=$9 WHERE cli_id=$99";
            clsDB.QueryReplace(1, txtNome.Text);
            clsDB.QueryReplace(2, txtInd.Text);
            clsDB.QueryReplace(3, txtCap.Text);
            clsDB.QueryReplace(4, txtLoc.Text);
            clsDB.QueryReplace(5, txtPrv.Text);
            clsDB.QueryReplace(6, txtPiva.Text);
            clsDB.QueryReplace(7, txtCodFis.Text);
            clsDB.QueryReplace(8, txtNote.Text);
            clsDB.QueryReplace(9, txtCodImp.Text);
            clsDB.QueryReplace(99, lblId.Text);
            clsDB.exec(clsDB.QueryString.ToUpper());
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
