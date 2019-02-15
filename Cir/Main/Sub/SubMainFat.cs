using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir
{
    public partial class SubMainFat : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Classi.ClsDbGet dbGet = new Cir.Classi.ClsDbGet();
        private int maxRow = 250;
        private int iniRow = 0;
        public SubMainFat()
        {
            InitializeComponent();
            pickDatFin.Value = DateTime.Today;
            pickDatIni.Value = pickDatIni.Value.AddMonths(-3);
        }

        private void SubFormFat_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                return;
            ShowFat();
        }

        private void ShowFat()
        {
            myGlobal.defaultListView(listView);

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Data", 80, HorizontalAlignment.Center);
            this.listView.Columns.Add("", 30, HorizontalAlignment.Center);
            this.listView.Columns.Add("Numero", 80, HorizontalAlignment.Center);
            this.listView.Columns.Add("Cliente", 380, HorizontalAlignment.Left);
            this.listView.Columns.Add("Importo", 80, HorizontalAlignment.Right);
            this.listView.Columns.Add("Commessa", 310, HorizontalAlignment.Left);

            clsDB.QueryString = "SELECT fat_id, fat_dat, fat_num, fat_tot, fat_ndc, cli_nom, cms_descri FROM Fat ";
            clsDB.QueryAppend(" LEFT JOIN Cli ON cli_id=fat_cli_id");
            clsDB.QueryAppend(" LEFT JOIN fatrig ON fat_id=fatrig_fat_id");
            clsDB.QueryAppend(" LEFT JOIN Cms ON cms_id=fat_cms_id");
            clsDB.QueryAppend(" WHERE fat_dat BETWEEN '" + pickDatIni.Value.ToString(myGlobal.fmtDataYMD) + "' AND '" + pickDatFin.Value.ToString(myGlobal.fmtDataYMD) + "'");
            clsDB.QueryAppend(" GROUP BY fat_id");
            clsDB.QueryAppend(" ORDER BY fat_dat DESC, ABS(fat_num) DESC LIMIT " + iniRow + "," + (iniRow + maxRow));
            clsDB.QueryDB();

            foreach (DataRow row in clsDB.dt.Rows)
            {
                dbGet.setRow(row);
                ListViewItem item = new ListViewItem(dbGet.getStr("fat_id"));
                item.SubItems.Add(dbGet.getDat("fat_dat"));
                myGlobal.ClsDocument doc = myGlobal.listDocument[dbGet.getInt("fat_ndc")];
                item.SubItems.Add(doc.strCode);
                item.SubItems.Add(dbGet.getStr("fat_num"));
                item.SubItems.Add(dbGet.getStr("cli_nom"));
                item.SubItems.Add(dbGet.getImp("fat_tot"));
                item.SubItems.Add(dbGet.getStr("cms_descri"));
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void btnNewFat_Click(object sender, EventArgs e)
        {
            Cir.Fatt.ModalFatCreate modal = new Cir.Fatt.ModalFatCreate();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                 this.ShowFat();
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listView.FocusedItem.Bounds.Contains(e.Location) == false)
                return;
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.cli_id = item.Text;

            if (e.Button == MouseButtons.Right)
            {
               /*
                ContextMenuStrip mnu = new ContextMenuStrip();
                ToolStripMenuItem mnuCli = new ToolStripMenuItem("Scheda cliente");
                ToolStripMenuItem mnuFat = new ToolStripMenuItem("Fattura");

                mnuCli.Click += new EventHandler(mnuCli_Click);
                mnuFat.Click += new EventHandler(mnuFat_Click);

                mnu.Items.AddRange(new ToolStripItem[] { mnuCli, mnuFat });
                this.listView.ContextMenuStrip = mnu;
                * */
            }
            else
            {                
                Cir.Clie.Modal.ModalFatRigMod modal = new Cir.Clie.Modal.ModalFatRigMod(item.Text);
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                    ShowFat();
            }
        }

        private void mnuCli_Click(object sender, EventArgs e)
        {
            myGlobal.frmMain.Hide();
            Cir.Clie.FrmClie frm = new Cir.Clie.FrmClie();
        }
        private void mnuFat_Click(object sender, EventArgs e)
        {
            /*
            Cir.Clie.Modal.ModalShowFatRig modal = new Cir.Clie.Modal.ModalShowFatRig(item.Text);
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                ShowFat();            
*/
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            iniRow = 0;
            ShowFat();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            iniRow += maxRow;
            ShowFat();
        }
    }
}
