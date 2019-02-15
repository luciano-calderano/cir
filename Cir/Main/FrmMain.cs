using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;

namespace Cir
{
    public partial class FormMain : Form
    {
        private ClsDataBase DB = ClsDataBase.Instance;

        private SubMainCli subCli = null;
        private SubMainAmm subAmm = null;
        private SubMainRic subRic = null;
        private SubMainFat subFat = null;
        private SubForm.SubMainScaden subScaden = null;
        private Cir.SubForm.FormDbConf frmDbConf;
        private Cir.SubForm.SubMainFrn subFrn;
        private Cir.SubForm.SubMainIntDaFatt daFatt;
        Form frmActive;

        public FormMain()
        {
            InitializeComponent();
            myGlobal.frmMain = this;
            myGlobal.loadDefault();

            Task task = new Task(new Action(saveDB));
            task.Start();

        }

        private void saveDB()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string cmdFile = path + "\\backupdb.bat";
            if (System.IO.File.Exists(cmdFile) == false)
            {
                string cmdText = "";
                cmdText += @"IF NOT EXIST Y:\ GOTO NO_Y_DIR";
                cmdText += System.Environment.NewLine;
                cmdText += @"C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump -u root cir_ok > Y:\copiaDB.%1.sql";
                cmdText += System.Environment.NewLine;
                cmdText += @":NO_Y_DIR";
                System.IO.File.WriteAllText(cmdFile, cmdText);
            }

            string file = path + "\\LastBackup.txt";
            string nextBackup = "000";
            if (System.IO.File.Exists(file))
            {
                string riga = File.ReadAllText(file);
                int progressivo = 0;
                if (int.TryParse(riga, out progressivo) == true)
                    progressivo++;
                if (progressivo > 50)
                    progressivo = 0;
                nextBackup = progressivo.ToString("000");
            }
            System.IO.File.WriteAllText(file, nextBackup);
            Process cmd = new Process();
            try
            {
                cmd.StartInfo.FileName = cmdFile;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments = nextBackup;
                cmd.Start();
            }
            catch
            {
                throw;
            }
//            System.Diagnostics.Process.Start(cmdFile, nextBackup);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (DB.dbCheck() == false)
            {
                frmDbConf = new Cir.SubForm.FormDbConf();
                var result = frmDbConf.ShowDialog();
                if (result != DialogResult.OK)
                {
                    this.Close();
                    Application.Exit();
                    return;
                }
            }

            string s = "SELECT * FROM tabpar";
            DataTable dt = DB.QueryDataTable(s);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                myGlobal.costoOra = (float)row["par_costo_ora"];
            }

            subRic = new SubMainRic();
            subRic.TopLevel = false;
            this.pictureBox.Controls.Add(subRic);

            subAmm = new SubMainAmm();
            subAmm.TopLevel = false;
            this.pictureBox.Controls.Add(subAmm);

            subCli = new SubMainCli();
            subCli.TopLevel = false;
            this.pictureBox.Controls.Add(subCli);

            subFat = new SubMainFat();
            subFat.TopLevel = false;
            this.pictureBox.Controls.Add(subFat);

            subFrn = new Cir.SubForm.SubMainFrn();
            subFrn.TopLevel = false;
            this.pictureBox.Controls.Add(subFrn);

            subScaden = new SubForm.SubMainScaden();
            subScaden.TopLevel = false;
            this.pictureBox.Controls.Add(subScaden);

            daFatt = new SubForm.SubMainIntDaFatt();
            daFatt.TopLevel = false;
            this.pictureBox.Controls.Add(daFatt);

            frmActive = subCli;
            this.showForm(frmActive);
        }
        private void showForm(Form frmToShow)
        {
            myGlobal.cli_id = "";
            myGlobal.amm_id = "";
            myGlobal.ric_id = "";
            myGlobal.int_id = "";
            myGlobal.cms_id = "";
            myGlobal.scaden_id = "";

            frmActive.Hide();
            frmToShow.Visible = true;
            frmActive = frmToShow;
        }

        private void btnScaden_Click(object sender, EventArgs e)
        {
            this.showForm(subScaden);
        }
        private void butAmm_Click(object sender, EventArgs e)
        {
            this.showForm(subAmm);
        }

        private void btnCli_Click(object sender, EventArgs e)
        {
            this.showForm(subCli);
        }

        private void btnDaFatt_Click(object sender, EventArgs e)
        {
            this.showForm(daFatt);
        }

        private void btnRic_Click(object sender, EventArgs e)
        {
            this.showForm(subRic);
        }

        private void btnFrn_Click(object sender, EventArgs e)
        {
            this.showForm(subFrn);
        }

        private void btnFatt_Click(object sender, EventArgs e)
        {
            this.showForm(subFat);
        }

        private void btnMnu_Click(object sender, EventArgs e)
        {
            this.mnuTabell.Show(this.Left + this.Width - this.mnuTabell.Width - 20, this.Top + 60);
        }

        private void tecniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalFormTec frmTec = new Cir.Modal.ModalFormTec();
            var result = frmTec.ShowDialog();
        }

        private void tipoInterventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalFormTip frmTip = new Cir.Modal.ModalFormTip();
            var result = frmTip.ShowDialog();
        }

        private void testoScadenzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalTabScaden tabScaden = new Cir.Modal.ModalTabScaden();
            var result = tabScaden.ShowDialog();
        }

        private void tipoAlimentazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cir.Tabelle.ModalTabAlimen modal = new Cir.Tabelle.ModalTabAlimen();
            var result = modal.ShowDialog();
        }

        private void parametriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cir.Tabelle.ModalTabPar modal = new Cir.Tabelle.ModalTabPar();
            var result = modal.ShowDialog();
        }

        private void zoneClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalFormZone modal = new Cir.Modal.ModalFormZone();
            var result = modal.ShowDialog();
        }
    }
}
