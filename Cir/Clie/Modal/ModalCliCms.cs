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
    public partial class ModalFormCms : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        public ModalFormCms(DataRow row)
        {
            InitializeComponent();
            int i = System.Convert.ToInt32(row["cms_tip"]);
            switch (i)
            {
                case 1:
                    opzCnt.Checked = true;
                    break;
                case 2:
                    opzPrv.Checked = true;
                    break;
                default:
                    opzCms.Checked = true;
                    break;
            }
            this.lblCms_Id.Text = row["cms_id"].ToString();
            this.txtCmsDescri.Text = row["cms_descri"].ToString();
            this.txtCmsImp.Text = row["cms_imp"].ToString();
            datePickerIni.Value = clsDB.dateFromDB(row["cms_datini"]);
            datePickerFin.Value = clsDB.dateFromDB(row["cms_scaden"]);
            this.txtNot.Text = row["cms_not"].ToString();
            this.Tag = System.Convert.ToInt32(row["cms_tip"]);
            btnCancel.Show();
        }        
        public ModalFormCms()
        {
            InitializeComponent();
            lblCms_Id.Text = "";
            opzCms.Checked = true;
            this.txtCmsDescri.Text = "";
            this.txtCmsImp.Text = "0";
            this.datePickerIni.Value = DateTime.Today;
            this.datePickerFin.Value = DateTime.Today;
            txtNot.Text = "";
            this.Tag = 0;
            btnCancel.Hide();
        }

         private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblCms_Id.Text == "")
                this.newIdCms();

            clsDB.QueryString = "UPDATE cms SET cms_cli_id=$1, cms_tip=$2, cms_descri=$3, cms_imp=$4, cms_datini=$5, cms_scaden=$6, cms_not=$7 WHERE cms_id=$9";
            clsDB.QueryReplace(1, myGlobal.cli_id);
            clsDB.QueryReplace(2, this.Tag.ToString());
            clsDB.QueryReplace(3, this.txtCmsDescri.Text);
            clsDB.QueryReplace(4, this.txtCmsImp.Text);
            clsDB.QueryReplace(5, this.datePickerIni.Value.ToString(myGlobal.fmtDataYMD));
            clsDB.QueryReplace(6, this.datePickerFin.Value.ToString(myGlobal.fmtDataYMD));
            clsDB.QueryReplace(7, this.txtNot.Text);
            clsDB.QueryReplace(9, this.lblCms_Id.Text);
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void newIdCms ()
        {
            lblCms_Id.Text = clsDB.nextId("cms", "cms_id"); ;
            clsDB.QueryString = "INSERT INTO cms (cms_id) VALUES ('" + lblCms_Id.Text + "')";
            clsDB.QueryExec();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedo ?", "Cancellazione commessa/contratto", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (myGlobal.cms_id.Length > 0)
            {
                clsDB.QueryString = "DELETE FROM cms WHERE cms_id=$1";
                clsDB.QueryReplace(1, myGlobal.cms_id);
                clsDB.QueryExec();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void opzCms_CheckedChanged(object sender, EventArgs e)
        {
            this.Tag = 0;
        }

        private void opzCnt_CheckedChanged(object sender, EventArgs e)
        {
            this.Tag = 1;
        }

        private void opzPrv_CheckedChanged(object sender, EventArgs e)
        {
            this.Tag = 2;
        }

        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.Bounds.Width == 0)
                return;
            myGlobal.listView_DrawColumnHeader(sender, e);
            e.Graphics.DrawString(e.Header.Text, new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), e.Bounds.X + 2, e.Bounds.Y + 4);
        }

        private void btnInt_Click(object sender, EventArgs e)
        {
            Cir.Modal.ModalCliCmsInt modal = new Cir.Modal.ModalCliCmsInt();
             var result = modal.ShowDialog();
        }
    }
}
