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
    public partial class ModalIntTec : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private DataTable dt;
        public ModalIntTec()
        {
            InitializeComponent();
            String q = "SELECT * FROM tec ORDER BY tec_nom";
            dt = clsDB.QueryDataTable(q);
           
            foreach (DataRow row in dt.Rows)
            {
                this.checkedListBoxTec.Items.Add(row["tec_nom"].ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDB.QueryString = "DELETE FROM inttec WHERE inttec_int_id=$1";
            clsDB.QueryReplace(1, myGlobal.int_id);
            clsDB.QueryExec();

            foreach (object itemChecked in checkedListBoxTec.CheckedItems)
            {
                int index = checkedListBoxTec.Items.IndexOf(itemChecked);
                DataRow row = dt.Rows[index];
                clsDB.QueryString = "INSERT INTO inttec VALUES ('" + myGlobal.int_id + "','" + row["tec_id"].ToString() + "')";
                clsDB.QueryExec();
            }
            this.DialogResult = DialogResult.OK;
        }

    }
}
