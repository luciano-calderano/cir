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
    public partial class ModalTabPar : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public ModalTabPar()
        {
            InitializeComponent();
            string s = "SELECT * FROM tabpar";

            DataTable dt = clsDB.QueryDataTable(s);
            if (dt.Rows.Count == 0)
                return;
            DataRow row = dt.Rows[0];
            txtCostoOra.Text = row["par_costo_ora"].ToString();
            txtIva1.Text = row["aliq_iva_1"].ToString();
            txtIva2.Text = row["aliq_iva_2"].ToString();
            txtIva3.Text = row["aliq_iva_3"].ToString();
            txtIva4.Text = row["aliq_iva_4"].ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            clsDB.QueryString = "UPDATE tabpar SET par_costo_ora=$1,aliq_iva_1=$11,aliq_iva_2=$12,aliq_iva_3=$13,aliq_iva_4=$14";
            clsDB.QueryReplace(1, this.txtCostoOra.Text);
            clsDB.QueryReplace(11, this.txtIva1.Text);
            clsDB.QueryReplace(12, this.txtIva2.Text);
            clsDB.QueryReplace(13, this.txtIva3.Text);
            clsDB.QueryReplace(14, this.txtIva4.Text);
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }
    }
}
