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
    public partial class ModalSchCld : Form
    {
        private class ClsElementi
        {
            public string strCod = "";
            public string strDes = "";
            public string strLabel1 = "";
            public string strLabel2 = "";
            public string[] strOpz01;
            public string[] strOpz02;
            public ClsElementi addElem(string cod, string des, string label1, string label2, string[] opz01, string[] opz02)
            {
                this.strCod = cod;
                this.strDes = des;
                this.strLabel1 = label1;
                this.strLabel2 = label2;
                this.strOpz01 = opz01;
                this.strOpz02 = opz02;
                return this;
            }
        }
        List<ClsElementi> arrElem;
        ClsElementi clsElem;
        private ClsDataBase clsDB = ClsDataBase.Instance;

        public ModalSchCld()
        {
            InitializeComponent();

            arrElem = new List<ClsElementi>();
            string[] strOpzC1 = { "Acciaio", "Ghisa" };
            string[] strOpzC2 = { "Atm.", "Prex.", "Condensazione" };
            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("0", "Caldaia", "Pot. Foc.", "Pot. Utile", strOpzC1, strOpzC2));

            string[] strOpzB1 = { "Andata", "Ritorno" };
            string[] strOpzB2 = { "Aperta", "Chiusa" };
            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("1", "Bruciatore", "Campo funz. tra", "e", strOpzB1, strOpzB2));

            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("2", "Pompa", "", "", null, null));

            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("3", "Rampa", "", "", null, null));

            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("4", "Addolcitore", "", "", null, null));

            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("5", "Scambiatore", "", "", null, null));

            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("6", "Unita trattamento aria", "", "", null, null));
            
            clsElem = new ClsElementi();
            arrElem.Add(clsElem.addElem("7", "Condizionamento", "", "", null, null));

            foreach (ClsElementi elem in arrElem)
                cmbElem.Items.Add (elem.strDes);
            cmbElem.Text = cmbElem.Items[0].ToString();
        }

        public void Open(string cld_id)
        {
            lblCld_id.Text = cld_id;
            btnCanc.Visible = (cld_id.Length > 0);

            String q = "SELECT * FROM schcld WHERE cld_id='" + cld_id + "'";
            DataTable dt = clsDB.QueryDataTable(q);
            DataRow rdr = dt.Rows[0];
            comboTipo1.Text = "";
            comboTipo2.Text = "";

            if (dt.Rows.Count == 0)
                return;
            rdr = dt.Rows[0];
            txtCalMod.Text = rdr["cld_mod"].ToString();
            txtCalMat.Text = rdr["cld_mat"].ToString();
            txtCalAnn.Text = rdr["cld_AnnCos"].ToString();
            txtParam1.Text = rdr["cld_param1"].ToString();
            txtParam2.Text = rdr["cld_param2"].ToString();
            comboTipo1.Text = rdr["cld_tipo01"].ToString();
            comboTipo2.Text = rdr["cld_tipo02"].ToString();
            txtNot.Text = rdr["cld_not"].ToString();
            int i = int.Parse (rdr["cld_tip"].ToString());
            cmbElem.SelectedIndex = i;

            string s = rdr["cld_datIns"].ToString();
            datePickerInstall.Checked = false;
            if (s.Length == 8)
            {
                datePickerInstall.Checked = true;
                datePickerInstall.Value = clsDB.dateFromDB(s);
            }
        }

        public void OpenNew()
        {
            lblCld_id.Text = "";

            txtCalMod.Text = "";
            txtCalMat.Text = "";
            txtCalAnn.Text = "";
            txtParam2.Text = "";
            txtParam1.Text = "";
            comboTipo1.Text = "";
            comboTipo2.Text = "";
            txtNot.Text = "";
            datePickerInstall.Checked = false;

            var result = this.ShowDialog();
            if (result == DialogResult.OK)
                ListShow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblCld_id.Text == "")
            {
                lblCld_id.Text = clsDB.nextId("schcld", "cld_id");
                clsDB.QueryString = "INSERT INTO schcld (cld_id, cld_cli_id) VALUES ('" + lblCld_id.Text + "','" + myGlobal.cli_id + "')";
                clsDB.QueryExec();
            }
            clsDB.QueryString = "UPDATE schcld SET ";
            clsDB.QueryAppend("cld_mod=$1, ");
            clsDB.QueryAppend("cld_mat=$2, ");
            clsDB.QueryAppend("cld_AnnCos=$11, ");
            clsDB.QueryAppend("cld_DatIns=$12, ");
            clsDB.QueryAppend("cld_param1=$13, ");
            clsDB.QueryAppend("cld_param2=$14, ");
            clsDB.QueryAppend("cld_tipo01=$20, ");
            clsDB.QueryAppend("cld_tipo02=$21, ");
            clsDB.QueryAppend("cld_tip=$22, ");
            clsDB.QueryAppend("cld_not=$90 ");
            clsDB.QueryAppend("WHERE cld_id=$99 ");

            string strDataInst = "";
            if (datePickerInstall.Checked == true)
                strDataInst = datePickerInstall.Value.ToString(myGlobal.fmtDataYMD);

            clsDB.QueryReplace(1, txtCalMod.Text);
            clsDB.QueryReplace(2, txtCalMat.Text);
            clsDB.QueryReplace(11, txtCalAnn.Text);
            clsDB.QueryReplace(12, strDataInst);
            clsDB.QueryReplace(13, txtParam1.Text);
            clsDB.QueryReplace(14, txtParam2.Text);
            clsDB.QueryReplace(20, this.comboTipo1.Text);
            clsDB.QueryReplace(21, this.comboTipo2.Text);
            clsDB.QueryReplace(22, clsElem.strCod);
            clsDB.QueryReplace(90, txtNot.Text);
            clsDB.QueryReplace(99, lblCld_id.Text);
            clsDB.QueryExec();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedo ?", "Cancellazione elemento", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (myGlobal.cms_id.Length > 0)
            {
                clsDB.QueryString = "DELETE FROM schcld WHERE cld_id=$1";
                clsDB.QueryReplace(1, lblCld_id.Text);
                clsDB.QueryExec();
            }
            this.DialogResult = DialogResult.OK;
        }

        private DataTable dataTableListCld;
        private ListView listViewCld;
        public void ListShow(ListView listViewSchedaCld)
        {
            listViewCld = listViewSchedaCld;
            ListShow();
        }

        private void ListShow()
        {
            myGlobal.defaultListView(listViewCld);

            this.listViewCld.Columns.Add("Id", 0, HorizontalAlignment.Center);
         //   this.listViewCld.Columns.Add(" ", 0, HorizontalAlignment.Center);
            this.listViewCld.Columns.Add("Elemento", 150, HorizontalAlignment.Left);
            this.listViewCld.Columns.Add("Modello", 300, HorizontalAlignment.Left);
            this.listViewCld.Columns.Add("Matricola", 160, HorizontalAlignment.Left);
            this.listViewCld.Columns.Add("Dati", 180, HorizontalAlignment.Center);
            this.listViewCld.Columns.Add("Tipo", 180, HorizontalAlignment.Center);

            this.listViewCld.Columns.Add("Anno", 50, HorizontalAlignment.Center);
            this.listViewCld.Columns.Add("Data Inst.", 80, HorizontalAlignment.Center);
            this.listViewCld.Columns.Add("Note", 300, HorizontalAlignment.Left);

            String q = "SELECT * FROM schcld WHERE cld_cli_id='" + myGlobal.cli_id + "'";
            dataTableListCld = clsDB.QueryDataTable(q);
            foreach (DataRow row in dataTableListCld.Rows)
            {
                ListViewItem item = new ListViewItem(row["cld_id"].ToString());
                int i = int.Parse(row["cld_tip"].ToString());
                ClsElementi elem = arrElem[i]; 
               
            //    item.SubItems.Add(elem.strCod);
                item.SubItems.Add(elem.strDes);
                item.SubItems.Add(row["cld_mod"].ToString());
                item.SubItems.Add(row["cld_mat"].ToString());
                switch (i)
                {
                    case 0:
                        item.SubItems.Add("Focale " + row["cld_param1"].ToString() + " / Utile " + row["cld_param2"].ToString());
                        break;
                    case 1:
                        item.SubItems.Add("Campo funz. " + row["cld_param1"].ToString() + " / " + row["cld_param2"].ToString());
                        break;
                    case 2:
                        item.SubItems.Add("Diametro " + row["cld_param1"].ToString() + " / Vaso esp. lt. " + row["cld_param2"].ToString());
                        break;
                    default:
                        item.SubItems.Add("");
                        break;
                }

                item.SubItems.Add(row["cld_tipo01"].ToString() + " / " + row["cld_tipo02"].ToString());
                item.SubItems.Add(row["cld_AnnCos"].ToString());
                string s = row["cld_datIns"].ToString();
                if (s.Length == 8)
                    item.SubItems.Add(clsDB.dateFormatFromLong(s));
                else
                    item.SubItems.Add("-");
                item.SubItems.Add(row["cld_not"].ToString());

                item.UseItemStyleForSubItems = false;
                this.listViewCld.Items.Add(item);
            }
        }
        public void listViewClicked(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.FocusedItem.Bounds.Contains(e.Location) == false)
                return;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            DataRow row = dataTableListCld.Rows[lv.SelectedItems[0].Index];

            if (e.Button == MouseButtons.Right)
            {
            }
            else
            {
            }

            Open(item.Text);
            var result = this.ShowDialog();
            if (result == DialogResult.OK)
                ListShow();
        }

        private void cmbElem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbElem.SelectedIndex;
            clsElem = arrElem[i];
            if (clsElem.strLabel1.Length > 0)
            {
                lblParam1.Text = clsElem.strLabel1;
                lblParam1.Show();
                txtParam1.Show();
            }
            else
            {
                lblParam1.Hide();
                txtParam1.Hide();
            }
            if (clsElem.strLabel2.Length > 0)
            {
                lblParam2.Text = clsElem.strLabel2;
                lblParam2.Show();
                txtParam2.Show();
            }
            else
            {
                lblParam2.Hide();
                txtParam2.Hide();
            }
            if (clsElem.strOpz01 != null)
            {
                comboTipo1.Items.Clear();
                comboTipo2.Items.Clear();
                foreach (var s in clsElem.strOpz01)
                    comboTipo1.Items.Add(s);
                foreach (var s in clsElem.strOpz02)
                    comboTipo2.Items.Add(s);
                lblTipo.Show();
                comboTipo1.Show();
                comboTipo2.Show();
            }
            else
            {
                lblTipo.Hide();
                comboTipo1.Hide();
                comboTipo2.Hide();               
            }
        }
    }
}
