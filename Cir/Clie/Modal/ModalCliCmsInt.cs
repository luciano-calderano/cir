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
    public partial class ModalCliCmsInt : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        string result = "";
        public ModalCliCmsInt()
        {
            InitializeComponent();

            myGlobal.defaultListView(listViewInt);
            this.listViewInt.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewInt.Columns.Add("Data", 80, HorizontalAlignment.Center);
            this.listViewInt.Columns.Add("Orario", 85, HorizontalAlignment.Center);
            this.listViewInt.Columns.Add("Descrizione", 500, HorizontalAlignment.Left);
            this.listViewInt.Columns.Add("Importo", 80, HorizontalAlignment.Right);

            float tot = 0;

            clsDB.QueryString = "SELECT * FROM interv ";
            clsDB.QueryAppend("WHERE int_cms_id='" + myGlobal.cms_id + "' ORDER BY int_datIni");
            clsDB.QueryDB();
            DataTable dtInt = clsDB.dt;
            string z;

            foreach (DataRow row in dtInt.Rows)
            {
                ListViewItem item = new ListViewItem(row["int_id"].ToString());
                int i;
                string s = clsDB.dateFormatFromLong(row["int_datIni"].ToString());
                result += (s + " : ");
                item.SubItems.Add(s);

                i = int.Parse(row["int_oraIni"].ToString());
                s = String.Format("{0:00}", i / 100) + ":" + String.Format("{0:00}", i % 100);
                i = int.Parse(row["int_oraFin"].ToString());
                s += " - " + String.Format("{0:00}", i / 100) + ":" + String.Format("{0:00}", i % 100);
                result += (s + "\t\t");
                item.SubItems.Add(s);
                s = row["int_descri"].ToString();
                if (s.IndexOf("\n") > 0)
                    s = s.Substring(0, s.IndexOf("\n")) + "...";
                if (s.Length > 60)
                    s = s.Substring(0, 60) + " ...";
                item.SubItems.Add(s);
                result += (s + System.Environment.NewLine);

                item.SubItems.Add("");
                /*
                s = row["cms_descri"].ToString();
                if (s.Length > 0)
                    s += " - ";
                if (row["fat_dat"].ToString().Length > 0)
                    s += "Fatt. n. ["+ row["fat_num"].ToString() + "] del " + clsDB.dateFormatFromDB (row["fat_dat"]);
                else if (s.Length == 0)
                    s = row["tip_descri"].ToString();
                if (s.Length > 40)
                    s = s.Substring(0, 40) + " ...";
                item.SubItems.Add(s);
                 * */
                item.UseItemStyleForSubItems = false;
                this.listViewInt.Items.Add(item);
                clsDB.QueryString = "SELECT * FROM intrig ";
                clsDB.QueryAppend("WHERE intrig_int_id='" + row["int_id"] + "'");
                clsDB.QueryDB();
                foreach (DataRow rowRig in clsDB.dt.Rows)
                {
                    item = new ListViewItem(rowRig["intrig_int_id"].ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    s = rowRig["intrig_des"].ToString();
                    if (s.IndexOf("\n") > 0)
                        s = s.Substring(0, s.IndexOf("\n")) + "...";
                    if (s.Length > 60)
                        s = s.Substring(0, 60) + " ...";
                    item.SubItems.Add(s);
                    z = "              " + clsDB.convertImporto(rowRig["intrig_imp"]) + " €";
                    z = z.Substring(z.Length - 12, 12);
                    result += ("\t\t\t" + z);
                    result += ("\t" + s + System.Environment.NewLine);

                    item.SubItems.Add(clsDB.convertImporto(rowRig["intrig_imp"]));

                    item.UseItemStyleForSubItems = false;
                    this.listViewInt.Items.Add(item);

                    float f = 0;
                    float.TryParse(rowRig["intrig_imp"].ToString(), out f);
                    tot += f;
                }
            }
            this.listViewInt.Items.Add("");
            ListViewItem itemTot = new ListViewItem("");
            itemTot.SubItems.Add("");
            itemTot.SubItems.Add("");
            itemTot.SubItems.Add("Totale Interventi");
            itemTot.SubItems.Add(tot.ToString(myGlobal.fmtImporto));
            this.listViewInt.Items.Add(itemTot);

            this.Text = "Totale interventi: " + tot.ToString(myGlobal.fmtImporto);
            z = "              " + tot.ToString(myGlobal.fmtImporto) + " €";
            z = z.Substring(z.Length - 12, 12);
            result += ("Totale interventi:\t" + z + System.Environment.NewLine);
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            string strPath = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);
            string filename = strPath + @"\Intervento.txt";
            System.IO.File.WriteAllText(filename, result);
            System.Diagnostics.Process.Start(filename);
        } 
    }
}
