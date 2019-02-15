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
    public partial class ModalCliNot : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
 
        public ModalCliNot()
        {
            InitializeComponent();
            String q = "SELECT cli_not FROM cli WHERE cli_id='" + myGlobal.cli_id + "'";
            DataTable dt = clsDB.QueryDataTable(q);
            txtNot.Text = dt.Rows[0][0].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDB.QueryString = "UPDATE cli SET cli_not=$1 WHERE cli_id=$2";
            clsDB.QueryReplace(1, txtNot.Text);
            clsDB.QueryReplace(2, myGlobal.cli_id);
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }
    }
}
