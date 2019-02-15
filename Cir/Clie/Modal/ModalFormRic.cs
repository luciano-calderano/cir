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
    public partial class ModalFormRic : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public ModalFormRic()
        {
            InitializeComponent();
            if (myGlobal.ric_id != "")
                this.LeggiRic();
        }

        public ModalFormRic(string id_cli)
        {
            myGlobal.ric_id = "";
            InitializeComponent();
            this.datePickerDatIni.Value = DateTime.Today;
            this.txtDescri.Text = "";
            this.checkBoxChiusa.Checked = false;
        }

        private void LeggiRic()
        {
            string q = "SELECT * FROM ric WHERE ric_id='" + myGlobal.ric_id + "'";
            DataTable dt = clsDB.QueryDataTable(q);
            DataRow row = dt.Rows[0];
            myGlobal.cli_id = row["ric_cli_id"].ToString();
            txtDescri.Text = row["ric_des"].ToString();
            checkBoxChiusa.Checked = (row["ric_closed"].ToString() == "1") ? true : false;
            datePickerDatIni.Value = clsDB.dateFromDB(row["ric_dat"].ToString());         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (myGlobal.ric_id == "")
                this.RicInsNew();
            clsDB.QueryString = "UPDATE ric SET ric_des=$1, ric_dat=$2, ric_closed=$3 WHERE ric_id=$4";
            clsDB.QueryReplace(1, txtDescri.Text);
            clsDB.QueryReplace(2, this.datePickerDatIni.Value.ToString (myGlobal.fmtDataYMD));
            clsDB.QueryReplace(3, (this.checkBoxChiusa.Checked) ? "1" : "0");
            clsDB.QueryReplace(4, myGlobal.ric_id);
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void RicInsNew ()
        {
            myGlobal.ric_id = clsDB.nextId("ric", "ric_id");
            clsDB.QueryString = "INSERT INTO ric (ric_id, ric_cli_id) VALUES ($1,$2)";
            clsDB.QueryReplace(1, myGlobal.ric_id);
            clsDB.QueryReplace(2, myGlobal.cli_id);
            clsDB.QueryExec();
        }
    }
}
