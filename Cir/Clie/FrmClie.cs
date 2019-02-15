using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Clie
{
    public partial class FrmClie : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private string strCliNot;
        public FrmClie()
        {            
            InitializeComponent();
            this.Show();
            this.ShowCli();
            myGlobal.frmMain.Hide();
            AddForm(new Cir.Clie.Tabs.SubTabInt(), tabPageInt);
            AddForm(new Cir.Clie.Tabs.SubTabCms(), tabPageCms);
            AddForm(new Cir.Clie.Tabs.SubTabSca(), tabPageSca);
            AddForm(new Cir.Clie.Tabs.SubTabRic(), tabPageRic);
            AddForm(new Cir.Clie.Tabs.SubTabFat(), tabPageFat);
            Form frm = (Form)tabPageInt.Tag;
            frm.Show();
        }

        void AddForm(Form sub, TabPage tabPage)
        {
            sub.TopLevel = false;
            sub.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None; 
            tabPage.Controls.Add(sub);
            tabPage.Tag = sub;
        }

        private void FormClie_FormClosed(object sender, FormClosedEventArgs e)
        {
            SalvaNote();
            myGlobal.frmMain.Show();
        }

        private void SalvaNote()
        {
            if (strCliNot == txtCliNot.Text)
                return;

            clsDB.QueryString = "UPDATE cli SET cli_not=$1 WHERE cli_id=$9";
            clsDB.QueryReplace(1, txtCliNot.Text);
            clsDB.QueryReplace(9, myGlobal.cli_id);
            clsDB.QueryExec();
            strCliNot = txtCliNot.Text;
        }
        private void ShowCli ()
        {
            string q = "SELECT * FROM cli LEFT JOIN amm ON cli_amm_id = amm_id";
            q += " WHERE cli_id='" + myGlobal.cli_id +"'";

            DataTable dt = clsDB.QueryDataTable(q);
            DataRow rdr = dt.Rows[0];

            this.Text = rdr["cli_nom"].ToString();
            lblId.Text = myGlobal.cli_id;

            lblInd.Text = rdr["cli_ind"].ToString();
            lblCapLoc.Text = "";
            string s;
            s = rdr["cli_cap"].ToString();
            if (s.Length > 0)
                lblCapLoc.Text += s + " ";
            s = rdr["cli_loc"].ToString();
            if (s.Length > 0)
            {
                if (lblCapLoc.Text.Length > 0)
                    lblCapLoc.Text += "- ";
                lblCapLoc.Text += s + " ";
            }
            s = rdr["cli_prv"].ToString();
            if (s.Length > 0)
                lblCapLoc.Text += "(" + s + ")";
            this.lblParIva.Text = "Partita Iva: " + rdr["cli_parIva"].ToString();
            this.lblCodFis.Text = "C.F.: " + rdr["cli_CodFis"].ToString();
            strCliNot = rdr["cli_not"].ToString();
            txtCliNot.Text = strCliNot;
            lblCodImp.Text = rdr["cli_codImp"].ToString();
            if (lblCodImp.Text.Length == 0)
                lblCodImp.Text = "---";

            this.lblAmm_id.Text = rdr["cli_amm_id"].ToString();
            this.lblAmmNom.Text = rdr["amm_nom"].ToString();
            this.lblAmmTel.Text = rdr["amm_tel"].ToString();
            this.lblAmmCel.Text = rdr["amm_cel"].ToString();
            this.lblAmmFax.Text = rdr["amm_fax"].ToString();
            this.lblAmmEml.Text = rdr["amm_eml"].ToString();
            this.lblAmmPec.Text = rdr["amm_pec"].ToString();
            tabPageCli.Text = rdr["cli_nom"].ToString();
            tabPageAmm.Text = "Amministratore " + rdr["amm_nom"].ToString();
        }

        private void btnCliMod_Click(object sender, EventArgs e)
        {
            Cir.SubForm.ModalFormCli frmCliUpdate = new Cir.SubForm.ModalFormCli();
            var result = frmCliUpdate.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowCli();
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            Cir.Clie.Modal.ModalCliNot CliNot = new  Cir.Clie.Modal.ModalCliNot ();
            var result = CliNot.ShowDialog();
        }

        private void btnAmm_Click(object sender, EventArgs e)
        {
            myGlobal.amm_id = lblAmm_id.Text;
            Cir.Modal.ModalFormAmm modal = new Cir.Modal.ModalFormAmm();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowCli();
        }

        private void btnSch_Click(object sender, EventArgs e)
        {
            Cir.Clie.Modal.FrmScheda modal = new Cir.Clie.Modal.FrmScheda();
            var result = modal.ShowDialog();
        }

        private void btnAmmInfo_Click(object sender, EventArgs e)
        {
            myGlobal.amm_id = this.lblAmm_id.Text;
            Cir.Modal.ModalAmmMod modal = new Cir.Modal.ModalAmmMod();
            var result = modal.ShowDialog();
        }

        private void txtCliNot_Leave(object sender, EventArgs e)
        {
            SalvaNote();
        }

        private void tabPageInt_Click(object sender, EventArgs e)
        {
            tabPageInt.Show();
        }

        private void tabControlCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tab = tabControlCli.TabPages[tabControlCli.SelectedIndex];
            Form frm = (Form)tab.Tag;
            frm.Show();
        }

// Tab Allegati

        private DataTable dataTableAllegati;
        private string allegFileName;
        private void ShowAlleg()
        {
            listBoxAllegatiClie.Items.Clear();
            allegReset();
            String q = "SELECT * FROM cli_allegati WHERE allegati_cli_id='" + myGlobal.cli_id + "' ORDER BY allegati_desc";

            dataTableAllegati = clsDB.QueryDataTable(q);
            foreach (DataRow row in dataTableAllegati.Rows)
            {
                this.listBoxAllegatiClie.Items.Add(row["allegati_desc"].ToString());
            }
        }

        private void btnAllegDel_Click(object sender, EventArgs e)
        {

        }

        private void btnAllegSfoglia_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.InitialDirectory = "\\";
            DialogResult result = fileDial.ShowDialog();
            if (result == DialogResult.OK)
            {
                allegFileName = fileDial.FileName;
                lblAllegFileName.Text = System.IO.Path.GetFileName(allegFileName);
            }
        }

        private void btnAllegIns_Click(object sender, EventArgs e)
        {
            if (lblAllegId.Text.Length == 0)
            {
                lblAllegId.Text = clsDB.nextId("cli_allegati", "allegati_id");
                clsDB.QueryString = "INSERT INTO cli_allegati (allegati_id, allegati_cli_id) VALUES ($1, $2)";
                clsDB.QueryReplace(1, lblAllegId.Text);
                clsDB.QueryReplace(2, myGlobal.cli_id);
                clsDB.QueryExec();
            }
            clsDB.QueryString = "UPDATE cli_allegati SET allegati_desc=$1,allegati_path=$2 WHERE allegati_id=$99";
            clsDB.QueryReplace(1, this.txtAllegDesc.Text);
            clsDB.QueryReplace(2, allegFileName.Replace("\\", "\\\\"));
            clsDB.QueryReplace(99, lblAllegId.Text);
            clsDB.QueryExec();
            ShowAlleg();
        }

        private void listBoxAllegatiClie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lv = (ListBox)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            int i = lv.SelectedIndex;
            DataRow row = dataTableAllegati.Rows[i];

            lblAllegId.Text = row["allegati_id"].ToString();
            allegFileName = row["allegati_path"].ToString();
            lblAllegFileName.Text = lblAllegFileName.Text = System.IO.Path.GetFileName(allegFileName);
            txtAllegDesc.Text = row["allegati_desc"].ToString();
            btnAllegIns.Text = "Modifica";
            btnAllegDel.Show();
        }

        private void btnAllegOpem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(allegFileName.Replace("\\", "\\\\"));
        }

        private void btnAllegAnnulla_Click(object sender, EventArgs e)
        {
            allegReset();
        }

        private void allegReset ()
        {
            lblAllegId.Text = "";
            lblAllegFileName.Text = "";
            txtAllegDesc.Text = "";
            btnAllegIns.Text = "Inserisci";
            btnAllegDel.Hide();
        }

        private void tabControlClieHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlClieHeader.SelectedIndex == 2)
                ShowAlleg();
        }

    }
}
