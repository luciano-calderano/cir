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
    public partial class ModalFormAmm : Form
    {
        public string ammNom {get;set;}
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Classi.ClsDbGet dbGet = new Cir.Classi.ClsDbGet();

        public ModalFormAmm()
        {
            InitializeComponent();
            this.showList();
        }

        private void showList () {
            this.listView.Clear();
            this.listView.View = View.Details;
            this.listView.LabelEdit = false;
            this.listView.AllowColumnReorder = false;
            this.listView.CheckBoxes = false;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Sorting = SortOrder.None;

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Nome", 200, HorizontalAlignment.Left);

            clsDB.QueryString = "SELECT * FROM amm WHERE amm_hidden<>'1' ";
            if (txtSrch.Text.Length > 0)
                clsDB.QueryAppend ("AND amm_nom LIKE $1 ");
            clsDB.QueryAppend ("ORDER BY amm_nom");
            clsDB.QueryReplace(1, "%" + txtSrch.Text.ToUpper() + "%");
            clsDB.QueryDB();

            foreach (DataRow row in clsDB.dt.Rows)
            {
                dbGet.setRow(row);
                ListViewItem item = new ListViewItem(dbGet.getStr("amm_id"));
                item.SubItems.Add(dbGet.getStr("amm_nom"));
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView.SelectedItems[0];
            ammNom = item.SubItems[1].Text;

            string q = "UPDATE cli SET";
            q += " cli_amm_id='" + item.Text + "'";
            q += ",cli_ammDatIni='" + DateTime.Today.ToString("yyyyMMdd") + "'";
            q += ",cli_ammPre_id='" + myGlobal.amm_id + "'";
            q += " WHERE cli_id='" + myGlobal.cli_id + "'";
            //Console.Write(q);
            clsDB.exec(q);
            myGlobal.amm_id = item.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            this.showList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}
