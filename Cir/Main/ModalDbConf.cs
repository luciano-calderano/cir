using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cir.SubForm
{
    public partial class FormDbConf : Form
    {
        private ClsDataBase DB = ClsDataBase.Instance;
        public FormDbConf()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
//            Properties.Settings.Default[cong_dbSrv] = "127.0.0.1";
//            Properties.Settings.Default.Save();
            /*
            string[] strParam = myGlobal.db_param.Split(',');
            if (strParam.Count() != 4)
                return;
            txtIP.Text = strParam[0];
            txtNm.Text = strParam[1];
            txtUs.Text = strParam[2];
            txtPw.Text = strParam[3];
             * */
   //         txtIP.Text = Properties.Settings.Default[cong_dbSrv].ToString();


            myGlobal.db_param = txtIP.Text + "," + txtNm.Text + "," + txtUs.Text + "," + txtPw.Text;
            using (StreamWriter outfile = new StreamWriter(myGlobal.fileConf))
            {
                outfile.Write(myGlobal.db_param);
            }
            bool dbExisits = DB.dbCheck();
            if (dbExisits == false)
                return;
            this.DialogResult = DialogResult.OK;
        }
    }
}
