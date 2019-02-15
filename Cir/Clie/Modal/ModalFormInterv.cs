using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Cir.SubForm
{
    public partial class ModalFormInterv : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Classi.ClsDbGet dbGet = new Cir.Classi.ClsDbGet();

        private string strTec_Id;
        private string strTip_Id;

        ArrayList arrIdCms = new ArrayList();
        ArrayList arrIdTec = new ArrayList();
        ArrayList arrIdTip = new ArrayList();
 
        public ModalFormInterv()
        {
            InitializeComponent();
            this.loadTblList();
            lblCmsImp.Text = "";
            lblTot.Text = "";
            lblFat.Text = "";
            lblCms_id.Text = myGlobal.cms_id;

            strTec_Id = "0";
            strTip_Id = "0";
            comboNumOpe.Text = "1";
            this.ShowCms();

            dataGrid.ColumnCount = 2;
            dataGrid.RowHeadersWidth = 30;
            dataGrid.Columns[0].Name = "Descrizione";
            dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[1].Name = "Importo";
            dataGrid.Columns[1].Width = 80;
            dataGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (myGlobal.int_id.Length == 0)
            {
                dataGrid.Rows.Add("Manodopera", "0");
                return;
            }

            String q = "SELECT * FROM interv ";
            q += "LEFT JOIN tip ON int_tip_id = tip_id ";
            q += "LEFT JOIN cms ON int_cms_id = cms_id ";
            q += "LEFT JOIN fat ON int_fat_id = fat_id ";
            q += "WHERE int_id = '" + myGlobal.int_id + "'";

            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count == 0)
                return;

            this.ShowRig();
            this.ShowTec();

            DataRow row = dt.Rows[0];
            string strDatIni = row["int_datIni"].ToString();
            string strFatDat = row["int_fatDat"].ToString();
            myGlobal.cms_id = row["int_cms_id"].ToString();
            strTec_Id = row["int_tec_id"].ToString();
            strTip_Id = row["int_tip_id"].ToString();
            comboNumOpe.Text = row["int_numOpe"].ToString();
            txtDescri.Text = row["int_descri"].ToString();
            string ora;
            ora = "0000" + row["int_oraIni"].ToString();
            ora = ora.Substring(ora.Length - 4, 4);
            comboOraIni.Text = ora.Substring(0, 2);
            comboOraIniMin.Text = ora.Substring(2, 2);
            ora = "0000" + row["int_oraFin"].ToString();
            ora = ora.Substring(ora.Length - 4, 4);
            comboOraFin.Text = ora.Substring(0, 2);
            comboOraFinMin.Text = ora.Substring(2, 2);
            datePickerDatIni.Value = clsDB.dateFromDB(strDatIni);

            comboCms.Text = row["cms_descri"].ToString();
            comboTip.Text = row["tip_descri"].ToString();

            if (row["fat_dat"].ToString().Length > 0)
                lblFat.Text = "Fatt. num. [" + row["fat_num"].ToString() + "] del " + clsDB.dateFormatFromDB(row["fat_dat"]);
        }

        private void ShowCms()
        {
            String q = "SELECT * FROM cms WHERE cms_id = '" + myGlobal.cms_id + "'";

            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];
            comboCms.Text = row["cms_descri"].ToString();
        }

        private void ShowTec()
        {
            listBoxTec.Items.Clear();
            String q = "SELECT * FROM inttec";
            q += " LEFT JOIN tec ON tec_id=inttec_tec_id";
            q += " WHERE inttec_int_id = '" + myGlobal.int_id + "'";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                listBoxTec.Items.Add(row["tec_nom"].ToString());
            }
            comboNumOpe.Text = listBoxTec.Items.Count.ToString();
        }
        public void ShowRig()
        {
            //dataGrid.Rows.Clear();
            clsDB.QueryString = "SELECT * FROM intRig WHERE intRig_int_id=$1"; ;
            clsDB.QueryReplace (1,myGlobal.int_id);
            clsDB.QueryDB();

            foreach (DataRow row in clsDB.dt.Rows)
            {
                dbGet.setRow(row);
                dataGrid.Rows.Add(dbGet.getStr("intRig_des"), dbGet.getImp("intRig_imp"));
            }
            totale();
        }

        private void loadTblList()
        {
            String q;
            DataTable dt;

            q = "SELECT * FROM tip ORDER BY tip_descri";
            dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                arrIdTip.Add(row["tip_id"].ToString());
                comboTip.Items.Add(row["tip_descri"].ToString());
            }

            arrIdCms.Add("|");
            comboCms.Items.Add("Generico");
            string oggi = DateTime.Today.ToString(myGlobal.fmtDataYMD);
            q = "SELECT * FROM cms WHERE cms_cli_id='" + myGlobal.cli_id + "' AND cms_scaden > '" + oggi + "'  ORDER BY cms_scaden";
            dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                arrIdCms.Add(row["cms_Id"].ToString() + "|" + row["cms_imp"].ToString());
                comboCms.Items.Add(row["cms_descri"].ToString());
            }
        }
         
        private void comboCms_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = arrIdCms[comboCms.SelectedIndex].ToString();
            string[] z = s.Split('|');
            myGlobal.cms_id = z[0];

            float imp;
            float.TryParse(z[1], out imp);
            if (imp > 0)
                lblCmsImp.Text = "Importo: " + imp.ToString(myGlobal.fmtImporto);
            else
                lblCmsImp.Text = "";
            lblCms_id.Text = myGlobal.cms_id;
        }


        private void comboTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            strTip_Id = arrIdTip[comboTip.SelectedIndex].ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (myGlobal.int_id.Length == 0)
                this.insNewInt();

            string q = "UPDATE interv SET ";
            q += "int_datIni=$1, int_oraIni=$2, int_oraFin=$3, int_cms_id=$4, int_tec_id=$5, int_tip_id=$6, ";
            q += "int_numOpe=$7, int_descri=$8, int_imp=$9, int_not='', int_cod='' ";
            q += "WHERE int_id=$99";
            clsDB.QueryString = q;
            clsDB.QueryReplace(01, clsDB.datePickerToDB(datePickerDatIni));
            clsDB.QueryReplace(02, comboOraIni.Text + comboOraIniMin.Text);
            clsDB.QueryReplace(03, comboOraFin.Text + comboOraFinMin.Text);
            clsDB.QueryReplace(04, myGlobal.cms_id);
            clsDB.QueryReplace(05, strTec_Id);
            clsDB.QueryReplace(06, strTip_Id);
            clsDB.QueryReplace(07, comboNumOpe.Text);
            clsDB.QueryReplace(08, txtDescri.Text.ToUpper());
            clsDB.QueryReplace(09, lblTot.Text);
            clsDB.QueryReplace(99, myGlobal.int_id);
            clsDB.QueryExec();

            this.DialogResult = DialogResult.OK;

            clsDB.QueryString = "DELETE FROM intrig WHERE intrig_int_id='" + myGlobal.int_id + "'";
            clsDB.QueryExec();

            int rig = 0;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;
                float fImp;
                string s = row.Cells[1].Value.ToString().Replace ('.', ',');
                float.TryParse(s, out fImp);
                clsDB.QueryString = "INSERT INTO intrig VALUES ($1,$2,$3,$4)";
                clsDB.QueryReplace(01,  myGlobal.int_id);
                clsDB.QueryReplace(02, rig.ToString());
                clsDB.QueryReplace(03, row.Cells[0].Value.ToString());
                clsDB.QueryReplace(04, s.Replace(',', '.'));
                clsDB.QueryExec();
                rig++;
            }
        }
        void insNewInt()
        {
            myGlobal.int_id = clsDB.nextId("interv", "int_id");

            clsDB.QueryString = "INSERT INTO interv (int_id, int_cli_id, int_ric_id) VALUES ($1,$2,$3)";
            clsDB.QueryReplace(1, myGlobal.int_id);
            clsDB.QueryReplace(2, myGlobal.cli_id);
            clsDB.QueryReplace(3, myGlobal.ric_id);
            clsDB.QueryExec();

            Cir.Clie.Modal.ModalIntTec modal = new Cir.Clie.Modal.ModalIntTec();

            clsDB.QueryString = "UPDATE inttec SET inttec_int_id='" + myGlobal.int_id + "' WHERE inttec_int_id='0'";
            clsDB.QueryExec();
        }

        private void comboOraIni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOraFin.Text == "")
                comboOraFin.Text = comboOraIni.Text;
            this.CalcolaCostoOra();
        }

 
        private void comboOraFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcolaCostoOra();
        }

        private void comboOraIniMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcolaCostoOra();
        }

        private void comboOraFinMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcolaCostoOra();
        }

        private void comboNumOpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcolaCostoOra();
        }
        private void CalcolaCostoOra()
        {
 //           txtImp.Text = "0";
            if (comboOraIni.Text == "")
                return;
            if (comboOraFin.Text == "")
                return;
            if (comboNumOpe.Text == "")
                return;
            float ini;
            float.TryParse(comboOraIni.Text, out ini);
            float fin;
            float.TryParse(comboOraFin.Text, out fin);
            float diffH = fin - ini;

            float.TryParse(comboOraIniMin.Text, out ini);
            float.TryParse(comboOraFinMin.Text, out fin);
            float diffM = fin - ini;

            float f = (diffH * myGlobal.costoOra) + (diffM / 15) * (myGlobal.costoOra / 4);
            float numOpe;
            float.TryParse(comboNumOpe.Text, out numOpe);
            if (numOpe == 0)
                numOpe = 1;
            float totale = f * numOpe;

            DataGridViewRow row = dataGrid.Rows[0];
            row.Cells[0].Value = "Manodopera: " + comboNumOpe.Text + " x " + diffH.ToString() + "h" + diffM.ToString("00");
            row.Cells[1].Value = totale.ToString(myGlobal.fmtImporto);

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedo ?", "Cancellazione intervento", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (myGlobal.int_id.Length > 0)
            {
                clsDB.QueryString = "DELETE FROM interv WHERE int_id=$1";
                clsDB.QueryReplace(1, myGlobal.int_id);
                clsDB.QueryExec();
                clsDB.QueryString = "DELETE FROM intrig WHERE intrig_int_id=$1";
                clsDB.QueryReplace(1, myGlobal.int_id);
                clsDB.QueryExec();
                clsDB.QueryString = "DELETE FROM inttec WHERE inttec_int_id=$1";
                clsDB.QueryReplace(1, myGlobal.int_id);
                clsDB.QueryExec();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnTec_Click(object sender, EventArgs e)
        {
            Cir.Clie.Modal.ModalIntTec modal = new Cir.Clie.Modal.ModalIntTec();
            var result = modal.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            this.ShowTec();
        }

        private void dataGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            totale();
        }
        private void dataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            totale();
        }

        private void totale()
        {
            float tot = 0;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;
                float fImp;
                string s;
                if (row.Cells[1].Value == null)
                    s = "0";
                else
                    s = row.Cells[1].Value.ToString().Replace('.', ',');
                float.TryParse(s, out fImp);
                tot += fImp;
            }
            if (tot == 0)
                lblTot.Text = "";
            else
                lblTot.Text = "Totale: " + tot.ToString(myGlobal.fmtImporto);

        }
    }
}
