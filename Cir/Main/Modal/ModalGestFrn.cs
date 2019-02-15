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
    public partial class ModalFormFrn : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;

        public ModalFormFrn(string frn_id)
        {

            InitializeComponent();
            this.modifica(frn_id);
        }

        private void modifica(string frn_id)
        {
            lblId.Text = frn_id;
            if (frn_id == "")
                return;
            String q = "SELECT * FROM frn WHERE frn_id='" + frn_id + "'";
            DataTable dt = clsDB.QueryDataTable(q);
            DataRow row = dt.Rows[0];

            txtNome.Text = row["frn_nom"].ToString();
            txtInd.Text = row["frn_ind"].ToString();
            txtCap.Text = row["frn_cap"].ToString();
            txtLoc.Text = row["frn_loc"].ToString();
            txtPrv.Text = row["frn_prv"].ToString();
            txtPiva.Text = row["frn_parIva"].ToString();
            txtCodFis.Text = row["frn_fis"].ToString();
            txtNote.Text = row["frn_not"].ToString();
//            if (row["frn_hidden"].ToString() == "1")
//                checkHidden.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string q;
            if (lblId.Text == "")
            {
                lblId.Text = clsDB.nextId ("frn", "frn_id");
                q = "INSERT INTO frn (frn_id) VALUES ('" + lblId.Text + "')";
                clsDB.exec(q);
            }

            clsDB.QueryString = "UPDATE frn SET frn_nom=$1, frn_ind=$2, frn_cap=$3, frn_loc=$4, frn_prv=$5, frn_parIva=$6, frn_fis=$7, ";
            clsDB.QueryAppend("frn_tit=$8, frn_cnt=$9, frn_tel1=$11, frn_tel2=$12, frn_tel3=$13, frn_not=$98 WHERE frn_id=$99");
            clsDB.QueryReplace(1, txtNome.Text);
            clsDB.QueryReplace(2, txtInd.Text);
            clsDB.QueryReplace(3, txtCap.Text);
            clsDB.QueryReplace(4, txtLoc.Text);
            clsDB.QueryReplace(5, txtPrv.Text);
            clsDB.QueryReplace(6, txtPiva.Text);
            clsDB.QueryReplace(7, txtCodFis.Text);
            clsDB.QueryReplace(8, txtTit.Text);
            clsDB.QueryReplace(9, txtCon.Text);
            clsDB.QueryReplace(11, txtTel1.Text);
            clsDB.QueryReplace(12, txtTel2.Text);
            clsDB.QueryReplace(13, txtTel3.Text);
            clsDB.QueryReplace(98, txtNote.Text);
            clsDB.QueryReplace(99, lblId.Text);
            clsDB.exec(clsDB.QueryString.ToUpper());
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_frnck(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}
