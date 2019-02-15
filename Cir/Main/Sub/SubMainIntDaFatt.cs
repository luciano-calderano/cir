using System;
using System.Data;
using System.Windows.Forms;

namespace Cir.SubForm
{
    public partial class SubMainIntDaFatt : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private int pag = 0;

        public SubMainIntDaFatt()
        {
            InitializeComponent();
        }
        private void SubFormDaFatt_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                this.ShowInt();
        }

        public void ShowInt()
        {
            myGlobal.defaultListView(listView);
            this.listView.Clear();

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Data", 80, HorizontalAlignment.Left);
            this.listView.Columns.Add("Orario", 80, HorizontalAlignment.Left);
            this.listView.Columns.Add("Cliente", 300, HorizontalAlignment.Left);
            this.listView.Columns.Add("Descrizione", 500, HorizontalAlignment.Left);
            this.listView.Columns.Add("cli_id", 0, HorizontalAlignment.Left);

            String q = "SELECT * FROM interv ";
            q += "LEFT JOIN cli on int_cli_id=cli_id ";
            q += "WHERE int_fatnum='' OR int_fatnum='0' ";
            q += "ORDER BY int_datIni DESC LIMIT " + pag * 100 + ",100";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["int_id"].ToString());
                int i;
                string s = clsDB.dateFormatFromLong(row["int_datIni"].ToString());
                item.SubItems.Add(s);
                i = int.Parse(row["int_oraIni"].ToString());
                s = String.Format("{0:00}", i / 100) + ":" + String.Format("{0:00}", i % 100);
                i = int.Parse(row["int_oraFin"].ToString());
                s += " - " + String.Format("{0:00}", i / 100) + ":" + String.Format("{0:00}", i % 100);
                item.SubItems.Add(s);
                item.SubItems.Add(row["cli_nom"].ToString());
                item.SubItems.Add(row["int_descri"].ToString());
                item.SubItems.Add(row["cli_id"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listView.FocusedItem.Bounds.Contains(e.Location) == false)
                return;
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lv.SelectedItems[0];
            myGlobal.int_id = item.Text;
            myGlobal.cli_id = item.SubItems[5].Text;
            
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip mnu = new ContextMenuStrip();
                ToolStripMenuItem mnuCli = new ToolStripMenuItem("Scheda cliente");
                ToolStripMenuItem mnuFat = new ToolStripMenuItem("Inserisci fattura");

                mnuCli.Click += new EventHandler(mnuCli_Click);
                mnuFat.Click += new EventHandler(mnuFat_Click);

                mnu.Items.AddRange(new ToolStripItem[] { mnuCli, mnuFat });
                this.listView.ContextMenuStrip = mnu;
            }
            else
            {
                myGlobal.frmMain.Hide();
                Clie.FrmClie frm = new Clie.FrmClie();
            }
        }

        private void mnuFat_Click(object sender, EventArgs e)
        {
            Cir.Fatt.ModalFatCreate modal = new Cir.Fatt.ModalFatCreate();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowInt();
        }
        private void mnuCli_Click(object sender, EventArgs e)
        {
            myGlobal.frmMain.Hide();
            Cir.Clie.FrmClie frm = new Cir.Clie.FrmClie();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pag++;
            this.ShowInt();
        }
    }
}
