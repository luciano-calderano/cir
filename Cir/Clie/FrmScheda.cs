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
    public partial class FrmScheda : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Clie.Modal.ModalSchCld modalSchCld = new Cir.Clie.Modal.ModalSchCld();
 
        public FrmScheda()
        {
            InitializeComponent();
            ApriScheda();
            ShowScaden();
            modalSchCld.ListShow(listViewCld);
            comboCmbTip.Items.Add("Gas");
            comboCmbTip.Items.Add("Gasolio");
        }

        private void ShowScaden()
        {
            myGlobal.defaultListView(listViewSca);

            this.listViewSca.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listViewSca.Columns.Add("Data", 70, HorizontalAlignment.Left);
            this.listViewSca.Columns.Add("Descrizione", 400, HorizontalAlignment.Left);
            this.listViewSca.Columns.Add("DataDB", 0, HorizontalAlignment.Left);

            String q = "SELECT * FROM scaden WHERE scaden_cli_id='" + myGlobal.cli_id + "' ORDER BY scaden_dat DESC";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["scaden_id"].ToString());
                item.SubItems.Add(clsDB.dateFormatFromLong(row["scaden_dat"].ToString()));
                item.SubItems.Add(row["scaden_des"].ToString());
                item.SubItems.Add(row["scaden_dat"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listViewSca.Items.Add(item);
            }
        }

        private void ApriScheda()
        {
            String q = "SELECT cli_nom FROM cli WHERE cli_id='"+ myGlobal.cli_id + "'";
            DataTable dt = clsDB.QueryDataTable(q);
            DataRow rdr = dt.Rows[0];
            this.Text = rdr[0].ToString();
 
            q = "SELECT * FROM scheda WHERE sch_id='" + myGlobal.cli_id + "'";
            dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count == 0)
            {
                clsDB.QueryString = "INSERT INTO scheda (sch_id) VALUES ('" + myGlobal.cli_id + "')";               
                clsDB.QueryExec();
                return;
            }
            rdr = dt.Rows[0];

            txtVoltEs.Text = rdr["sch_cldVoltEs"].ToString();
            comboCmbTip.Text = rdr["sch_cmbtip"].ToString();
            txtDiaRam.Text = rdr["sch_diarmp"].ToString();
            txtDiaTub.Text = rdr["sch_diatub"].ToString();
            txtValLav.Text = rdr["sch_modvallav"].ToString();
            txtValSic.Text = rdr["sch_modvalsic"].ToString();
            txtDiaCanFum.Text = rdr["sch_diacanfum"].ToString();
            txtDiaTubSic.Text = rdr["sch_diatubsic"].ToString();
            txtDiaTubARC.Text = rdr["sch_diatubarc"].ToString();

            chk01.Checked = (rdr["sch_chk001"].ToString() == "1");
            chk02.Checked = (rdr["sch_chk002"].ToString() == "1");
            chk03.Checked = (rdr["sch_chk003"].ToString() == "1");
            chk04.Checked = (rdr["sch_chk004"].ToString() == "1");
            chk05.Checked = (rdr["sch_chk005"].ToString() == "1");
            chk11.Checked = (rdr["sch_chk011"].ToString() == "1");
            chk12.Checked = (rdr["sch_chk012"].ToString() == "1");
            chk13.Checked = (rdr["sch_chk013"].ToString() == "1");
            chk14.Checked = (rdr["sch_chk014"].ToString() == "1");
            chk15.Checked = (rdr["sch_chk015"].ToString() == "1");
            chk91.Checked = (rdr["sch_chk091"].ToString() == "1");
            chk92.Checked = (rdr["sch_chk092"].ToString() == "1");
            chk93.Checked = (rdr["sch_chk093"].ToString() == "1");

            txtNumPia.Text = rdr["sch_numPia"].ToString();
            txtNot.Text = rdr["sch_not"].ToString();

            // pag 2

            chk101.Checked = (rdr["sch_chk101"].ToString() == "1");
            chk102.Checked = (rdr["sch_chk102"].ToString() == "1");

            txtVasoLt.Text = rdr["sch_VasoLt"].ToString();
            radioVasApe.Checked = (rdr["sch_VasTip"].ToString() == "0");
            radioVasChi.Checked = (rdr["sch_VasTip"].ToString() == "1");

            txtCarMan.Text = rdr["sch_CarMan"].ToString();
            txtCarNHO.Text = rdr["sch_CarNHO"].ToString();
            txtCarDar.Text = rdr["sch_CarDar"].ToString();

            txtTerCen.Text = rdr["sch_TerCen"].ToString();
            txtTerMod.Text = rdr["sch_TerMod"].ToString();

            txtMisMod.Text = rdr["sch_ValMisMod"].ToString();
            txtMisDia.Text = rdr["sch_ValMisDia"].ToString();
            txtMisVie.Text = rdr["sch_ValMisVie"].ToString();
        }
        private void btnSave1_Click(object sender, EventArgs e)
        {
            clsDB.QueryString = "UPDATE scheda SET ";

            clsDB.QueryAppend("sch_cldVoltEs=$10, ");
            clsDB.QueryAppend("sch_chk101=$11, ");
            clsDB.QueryAppend("sch_chk102=$12, ");
            clsDB.QueryAppend("sch_numPia=$13, ");

            clsDB.QueryAppend("sch_cmbtip=$21, ");
            clsDB.QueryAppend("sch_diarmp=$22, ");
            clsDB.QueryAppend("sch_diatub=$23, ");
            clsDB.QueryAppend("sch_modvallav=$24, ");
            clsDB.QueryAppend("sch_modvalsic=$25, ");

            clsDB.QueryAppend("sch_diacanfum=$31, ");
            clsDB.QueryAppend("sch_diatubsic=$32, ");
            clsDB.QueryAppend("sch_diatubarc=$33, ");

            clsDB.QueryAppend("sch_chk001=$41, ");
            clsDB.QueryAppend("sch_chk002=$42, ");
            clsDB.QueryAppend("sch_chk003=$43, ");
            clsDB.QueryAppend("sch_chk004=$44, ");
            clsDB.QueryAppend("sch_chk005=$45, ");
            clsDB.QueryAppend("sch_chk011=$51, ");
            clsDB.QueryAppend("sch_chk012=$52, ");
            clsDB.QueryAppend("sch_chk013=$53, ");
            clsDB.QueryAppend("sch_chk014=$54, ");
            clsDB.QueryAppend("sch_chk015=$55, ");

            clsDB.QueryAppend("sch_chk091=$91, ");
            clsDB.QueryAppend("sch_chk092=$92, ");
            clsDB.QueryAppend("sch_chk093=$93, ");

            clsDB.QueryAppend("sch_not=$98 ");
            clsDB.QueryAppend("WHERE sch_id=$99 ");

            clsDB.QueryReplace(10, this.txtVoltEs.Text);
            clsDB.QueryReplace(11, chk101.Checked ? "1" : "0");
            clsDB.QueryReplace(12, chk102.Checked ? "1" : "0");
            clsDB.QueryReplace(13, txtNumPia.Text);

            clsDB.QueryReplace(21, this.comboCmbTip.Text);
            clsDB.QueryReplace(22, this.txtDiaRam.Text);
            clsDB.QueryReplace(23, this.txtDiaTub.Text);
            clsDB.QueryReplace(24, this.txtValLav.Text);
            clsDB.QueryReplace(25, this.txtValSic.Text);
            clsDB.QueryReplace(31, this.txtDiaCanFum.Text);
            clsDB.QueryReplace(32, this.txtDiaTubSic.Text);
            clsDB.QueryReplace(33, this.txtDiaTubARC.Text);

            clsDB.QueryReplace(41, this.chk01.Checked ? "1" : "0");
            clsDB.QueryReplace(42, this.chk02.Checked ? "1" : "0");
            clsDB.QueryReplace(43, this.chk03.Checked ? "1" : "0");
            clsDB.QueryReplace(44, this.chk04.Checked ? "1" : "0");
            clsDB.QueryReplace(45, this.chk05.Checked ? "1" : "0");
            clsDB.QueryReplace(51, this.chk11.Checked ? "1" : "0");
            clsDB.QueryReplace(52, this.chk12.Checked ? "1" : "0");
            clsDB.QueryReplace(53, this.chk13.Checked ? "1" : "0");
            clsDB.QueryReplace(54, this.chk14.Checked ? "1" : "0");
            clsDB.QueryReplace(55, this.chk15.Checked ? "1" : "0");

            clsDB.QueryReplace(91, this.chk91.Checked ? "1" : "0");
            clsDB.QueryReplace(92, this.chk92.Checked ? "1" : "0");
            clsDB.QueryReplace(93, this.chk93.Checked ? "1" : "0");

            clsDB.QueryReplace(98, txtNot.Text);
            clsDB.QueryReplace(99, myGlobal.cli_id);
            clsDB.QueryExec();
            tabControl1.SelectedIndex = 1;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            clsDB.QueryString = "UPDATE scheda SET ";

            clsDB.QueryAppend("sch_VasoLt=$5, ");
            clsDB.QueryAppend("sch_VasTip=$6, ");

            clsDB.QueryAppend("sch_CarMan=$11, ");
            clsDB.QueryAppend("sch_CarNHO=$12, ");
            clsDB.QueryAppend("sch_CarDar=$13, ");

            clsDB.QueryAppend("sch_TerCen=$21, ");
            clsDB.QueryAppend("sch_TerMod=$22, ");

            clsDB.QueryAppend("sch_ValMisMod=$31, ");
            clsDB.QueryAppend("sch_ValMisDia=$32, ");
            clsDB.QueryAppend("sch_ValMisVie=$33 ");

            clsDB.QueryAppend("WHERE sch_id=$99 ");

            clsDB.QueryReplace(5, txtVasoLt.Text);
            clsDB.QueryReplace(6, radioVasApe.Checked ?  "1" : "0");

            clsDB.QueryReplace(11, txtCarMan.Text);
            clsDB.QueryReplace(12, txtCarNHO.Text);
            clsDB.QueryReplace(13, txtCarDar.Text);

            clsDB.QueryReplace(21, txtTerCen.Text);
            clsDB.QueryReplace(22, txtTerMod.Text);

            clsDB.QueryReplace(31, txtMisMod.Text);
            clsDB.QueryReplace(32, txtMisDia.Text);
            clsDB.QueryReplace(33, txtMisVie.Text);

            clsDB.QueryReplace(99, myGlobal.cli_id);
            clsDB.QueryExec();
            tabControl1.SelectedIndex = 0;
        }

        private void listViewCld_MouseClick(object sender, MouseEventArgs e)
        {
            modalSchCld.listViewClicked(sender, e);
        }

        private void listViewSca_Click(object sender, EventArgs e)
        {
            Cir.Clie.Modal.ModalCliScaden modal = new Cir.Clie.Modal.ModalCliScaden();
            var result = modal.ShowDialog();
            ShowScaden();
        }

        private void btnNewCld_Click(object sender, EventArgs e)
        {
            modalSchCld.OpenNew();
        }

    }
}
