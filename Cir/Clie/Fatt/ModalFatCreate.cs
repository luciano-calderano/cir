using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Fatt
{
    public partial class ModalFatCreate : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Classi.ClsDbGet dbGet = new Cir.Classi.ClsDbGet();

        private DataTable dtCms;
        private DataTable dtInt;

        private Cir.Fatt.SubFatt subFat;

        public ModalFatCreate()
        {
            InitializeComponent();
            myGlobal.cms_id = "";
            myGlobal.int_id = "";
            ShowFatList();
            ShowIntList();
            ShowCmsList();

            subFat = new Cir.Fatt.SubFatt(this);
            subFat.TopLevel = false;
            this.panelFat.Controls.Add(subFat);
            subFat.Top = (panelFat.Height - subFat.Height) / 2;
            subFat.Left = (panelFat.Width - subFat.Width) / 2; ;
            subFat.Show();
        }
        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //subFat.Clear();
        }

        /* */

        public void ShowCmsList()
        {
            myGlobal.defaultListView(listViewCms, false);

            this.listViewCms.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("", 10, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("Descrizione", 360, HorizontalAlignment.Left);
            this.listViewCms.Columns.Add("Fattura", 200, HorizontalAlignment.Left);
            this.listViewCms.Columns.Add("Importo", 80, HorizontalAlignment.Right);
            this.listViewCms.Columns.Add("Scadenza", 90, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("Interv.", 80, HorizontalAlignment.Center);
            this.listViewCms.Columns.Add("Costo", 80, HorizontalAlignment.Right);

            String q = "SELECT cms.*, fat.*, COUNT(DISTINCT int_id) AS numint, SUM(intRig_imp) AS totale FROM cms";
            q += " LEFT JOIN interv ON int_cms_id=cms_id";
            q += " LEFT JOIN intrig ON intrig_int_id=int_id";
            q += " LEFT JOIN fat ON fat_cms_id=cms_id";
            q += " WHERE cms_cli_id='" + myGlobal.cli_id + "'";
            q += " GROUP BY cms_id ORDER BY cms_scaden desc";

            dtCms = clsDB.QueryDataTable(q);
            foreach (DataRow row in dtCms.Rows)
            {
                dbGet.setRow(row);
                ListViewItem item = new ListViewItem(dbGet.getStr("cms_id"));
                item.SubItems.Add("");
                item.SubItems.Add(dbGet.getStr("cms_descri"));

                if (dbGet.getStr("fat_dat").Length > 0)
                    item.SubItems.Add(dbGet.getStr("fat_num") + " del " + dbGet.getDat("fat_dat"));
                else
                    item.SubItems.Add("");
                item.SubItems.Add(dbGet.getImp("cms_imp"));
                item.SubItems.Add(dbGet.getDat("cms_scaden"));
                item.SubItems.Add(dbGet.getStr("numint"));
                item.SubItems.Add(dbGet.getImp("totale"));

                Color c;
                if (dbGet.getStr("fat_cms_id").Length > 0)
                    c = Color.Green;
                else
                    c = Color.Red;
                item.SubItems[1].BackColor = c;
                item.UseItemStyleForSubItems = false;
                this.listViewCms.Items.Add(item);
            }
        }

        public void ShowIntList()
        {
            treeView.CheckBoxes = true;
            String q = "SELECT *, SUM(intRig_imp) AS totale FROM interv";
            q += " LEFT JOIN intrig ON intrig_int_id=int_id";
            //  q += " LEFT JOIN FatRig ON fatrig_int_id=int_id";
            q += " WHERE int_cli_id='" + myGlobal.cli_id + "' AND int_tip_id='1' AND int_fat_id='0'";
            q += " GROUP BY int_id";
            dtInt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dtInt.Rows)
            {
                dbGet.setRow(row);
                string strDes = dbGet.getStr("int_descri");
                if (strDes.Length > 50)
                    strDes = strDes.Substring(0, 50);
                else
                    strDes = strDes + "".PadLeft(50 - strDes.Length);
                strDes = dbGet.getDat("int_datini") + " - " + strDes;
                TreeNode treeNode = new TreeNode(String.Format("{0,-50} {1,10}", strDes, dbGet.getImp("totale") + " €"));
                treeNode.Tag = row;
                treeView.Nodes.Add(treeNode);
            }
        }
        private void ShowFatList()
        {
            myGlobal.defaultListView(listViewFat);

            this.listViewFat.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewFat.Columns.Add("Data", 80, HorizontalAlignment.Center);
            this.listViewFat.Columns.Add("Numero", 80, HorizontalAlignment.Center);
            this.listViewFat.Columns.Add("Cliente", 400, HorizontalAlignment.Left);
            this.listViewFat.Columns.Add("Importo", 70, HorizontalAlignment.Right);
            this.listViewFat.Columns.Add("Tipo", 40, HorizontalAlignment.Center);

            String q = "SELECT fat_id, fat_dat, fat_num, fat_ndc, cli_nom, SUM(fatrig_imp) as totale FROM Fat ";
            q += " LEFT JOIN Cli ON cli_id=fat_cli_id";
            q += " LEFT JOIN fatrig ON fat_id=fatrig_fat_id";
            q += " GROUP BY fat_id";
            q += " ORDER BY fat_dat DESC, ABS(fat_num) DESC LIMIT 100";
            DataTable dt = clsDB.QueryDataTable(q);

            foreach (DataRow row in dt.Rows)
            {
                dbGet.setRow(row);
                ListViewItem item = new ListViewItem(dbGet.getStr("fat_id"));
                item.SubItems.Add(dbGet.getDat("fat_dat"));
                item.SubItems.Add(dbGet.getStr("fat_num"));
                item.SubItems.Add(dbGet.getStr("cli_nom"));
                item.SubItems.Add(dbGet.getImp("totale"));
                myGlobal.ClsDocument doc = myGlobal.listDocument[dbGet.getInt("fat_ndc")];
                item.SubItems.Add(doc.strCode);

                item.UseItemStyleForSubItems = false;
                this.listViewFat.Items.Add(item);
            }
        }

        private void listViewCms_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.FocusedItem.Bounds.Contains(e.Location) == false)
                return;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            DataRow row = dtCms.Rows[item.Index];

            myGlobal.cms_id = item.Text;
            if (e.Button == MouseButtons.Left)
                subFat.addCms(row);
        }

 
        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            subFat.AddInt((TreeView)sender);
        }

        private void listViewCms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
