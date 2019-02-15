using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Fatt
{
    public partial class SubFatt : Form
    {
        private class ClsIva
        {
            public float Alq;
            public float Imp;
            public float Iva;
        }
        private class Fat
        {
            public static int _id = 0;
            public static int des = 1;
            public static int qta = 2;
            public static int imp = 3;
            public static int alq = 4;
        }
        private float totFat = 0;
        private float totImp = 0;
        private float totIva = 0;
        private string strCliInd;

        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Classi.ClsDbGet dbGet = new Cir.Classi.ClsDbGet();
        private Form frmMain;

        public SubFatt(Form main)
        {
            InitializeComponent();
            frmMain = main;
            lblFatId.Text = "";
            btnDel.Hide();
            CreaMenuAliqIva();
            foreach (myGlobal.ClsDocument doc in myGlobal.listDocument)
            {
                comboTipoDoc.Items.Add(doc.strDesc);
            }

            /*
            comboTipoDoc.Items.Add("Fattura di vendita");
            comboTipoDoc.Items.Add("Nota di credito");
            comboTipoDoc.Items.Add("Fattura fiscale");
            */
            comboTipoDoc.SelectedIndex = 0;
            comboTipoDoc.Text = comboTipoDoc.Items[comboTipoDoc.SelectedIndex].ToString();

            dataGrid.ColumnCount = 5;
            dataGrid.RowHeadersWidth = 30;
            dataGrid.Columns[Fat._id].Name = "Id";
            dataGrid.Columns[Fat._id].Width = 0;
            dataGrid.Columns[Fat.des].Name = "Descrizione";
            dataGrid.Columns[Fat.des].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[Fat.qta].Name = "Q.ta";
            dataGrid.Columns[Fat.qta].Width = 30;
            dataGrid.Columns[Fat.qta].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGrid.Columns[Fat.imp].Name = "Importo";
            dataGrid.Columns[Fat.imp].Width = 80;
            dataGrid.Columns[Fat.imp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGrid.Columns[Fat.alq].Name = "Alq.";
            dataGrid.Columns[Fat.alq].Width = 30;
            dataGrid.Columns[Fat.alq].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            myGlobal.defaultListView(listViewIva);
            this.listViewIva.Columns.Add("Alq.", 35, HorizontalAlignment.Center);
            this.listViewIva.Columns.Add("Imp.", 95, HorizontalAlignment.Right);
            this.listViewIva.Columns.Add("Iva", 90, HorizontalAlignment.Right);

            myGlobal.defaultListView(listViewTot);
            listViewTot.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewTot.Columns.Add("Des.", 130, HorizontalAlignment.Right);
            this.listViewTot.Columns.Add("Imp.", 90, HorizontalAlignment.Right);

            ListViewItem itemTot;
            itemTot = new ListViewItem("Imponibile");
            itemTot.SubItems.Add("");
            this.listViewTot.Items.Add(itemTot);
            itemTot = new ListViewItem("Iva");
            itemTot.SubItems.Add("");
            this.listViewTot.Items.Add(itemTot);
            itemTot = new ListViewItem("Totale");
            itemTot.SubItems.Add("");
            this.listViewTot.Items.Add(itemTot);
            readCli();
        }

        private void CreaMenuAliqIva()
        {
            if (myGlobal.mnuAliqIva != null)
                return;
            clsDB.QueryString = "SELECT aliq_iva_1, aliq_iva_2, aliq_iva_3, aliq_iva_4 FROM tabpar";
            clsDB.QueryDB();
            DataRow row = clsDB.dt.Rows[0];

            myGlobal.mnuAliqIva = new ContextMenuStrip();
            for (int i = 0; i < 4; i++)
            {
                float f = (float)row[i];
                if (f == 0)
                    continue;
                if (myGlobal.mnuAliqIva.Tag == null)
                    myGlobal.mnuAliqIva.Tag = f;
                ToolStripMenuItem mnuItem = new ToolStripMenuItem(f.ToString() + "%");
                mnuItem.Click += new EventHandler(mnuItem_Click);
                myGlobal.mnuAliqIva.Items.Add(mnuItem);
            }
        }

        /* */
        
        public void Open(string fatId)
        {
            btnDel.Show();

            lblFatId.Text = fatId;
            clsDB.QueryString = "SELECT fat.*, cli_nom,cli_pariva FROM fat ";
            clsDB.QueryAppend(" LEFT JOIN cli ON cli_id=fat_cli_id");
            clsDB.QueryAppend(" WHERE fat_id='" + fatId + "'");
            clsDB.QueryDB();

            DataRow rowFat = clsDB.dt.Rows[0];
            dbGet.setRow(rowFat);
            myGlobal.cli_id = dbGet.getStr("fat_cli_id");
            readCli();

            dbGet.setRow(rowFat);
            myGlobal.ClsDocument doc = myGlobal.listDocument[dbGet.getInt("fat_ndc")];
            comboTipoDoc.Text = doc.strDesc;
//            comboTipoDoc.SelectedIndex = dbGet.getInt("fat_ndc");
//            comboTipoDoc.Text = comboTipoDoc.Items[comboTipoDoc.SelectedIndex].ToString();
           
            if (dbGet.getStr("fat_intest").Length > 0)
                txtCliNom.Text = dbGet.getStr("fat_intest");
            else
                txtCliNom.Text = dbGet.getStr("cli_nom");
            if (dbGet.getStr("fat_codfis").Length > 0)
                txtCliIva.Text = dbGet.getStr("fat_codfis");
            else
                txtCliIva.Text = dbGet.getStr("cli_pariva");

            txtFatNum.Text = dbGet.getStr("fat_num");
            datePicker.Value = dbGet.getDatVal("fat_dat");

            clsDB.QueryString = "SELECT * FROM fatrig ";
            clsDB.QueryAppend(" WHERE fatrig_fat_id='" + fatId + "'");
            clsDB.QueryAppend(" ORDER BY fatrig_rig");
            clsDB.QueryDB();

            foreach (DataRow row in clsDB.dt.Rows)
            {
                dbGet.setRow(row);
                dataGrid.Rows.Add(dbGet.getStr("fatrig_int_id"), dbGet.getStr("fatrig_descri"), dbGet.getImp("fatrig_qta"), dbGet.getImp("fatrig_imp"), dbGet.getStr("fatrig_alq"));
            }
            totale();
        }

        private void readCli()
        {
            clsDB.QueryString = "SELECT cli_nom,cli_pariva,cli_ind,cli_cap,cli_loc FROM cli";
            clsDB.QueryAppend(" WHERE cli_id='" + myGlobal.cli_id + "'");
            clsDB.QueryDB();
            if (clsDB.dt.Rows.Count == 0)
                return;
            dbGet.setRow(clsDB.dt.Rows[0]);
            txtCliNom.Text = dbGet.getStr("cli_nom");
            txtCliIva.Text = dbGet.getStr("cli_pariva");
            strCliInd = dbGet.getStr("cli_ind") + " " + dbGet.getStr("cli_cap") + " " + dbGet.getStr("cli_loc") + " ";
        }
        public void Clear()
        {
            myGlobal.cms_id = "";
            lblFatId.Text = "";
            listViewIva.Items.Clear();
            listViewTot.Items[0].SubItems[1].Text = listViewTot.Items[1].SubItems[1].Text = listViewTot.Items[2].SubItems[1].Text = "";
            dataGrid.Rows.Clear();
        }

        public void addCms(DataRow row)
        {
            dbGet.setRow(row);
            /*
            txtFatNum.Text = dbGet.getStr("fat_num");
            datePicker.Value = dbGet.getDatVal("fat_dat");
            lblFatId.Text = dbGet.getStr("fat_id");
            */
           // dataGrid.Rows.Clear();
            dataGrid.Rows.Add(dbGet.getStr("cms_id"), dbGet.getStr("cms_descri"), "1", dbGet.getImp("cms_imp"), myGlobal.mnuAliqIva.Tag.ToString());
            totale();
        }

        public void AddInt(TreeView treeView)
        {
            //dataGrid.Rows.Clear();

            float tot = 0;
            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.Level > 0)
                    continue;
                if (node.Checked == false)
                {
                    node.Collapse();
                    continue;
                }
                dbGet.setRow((DataRow)node.Tag);
                float f = dbGet.getFlt("totale");
                dataGrid.Rows.Add(dbGet.getStr("int_id"), "Intervento del " + dbGet.getDat("int_datini"), "", "");
                dataGrid.Rows.Add(dbGet.getStr("int_id"), dbGet.getStr("int_descri"), "1", f.ToString(myGlobal.fmtImporto), myGlobal.mnuAliqIva.Tag.ToString());
                tot += f;

                if (node.Nodes.Count == 0)
                {
                    String q = "SELECT * FROM intrig WHERE intrig_int_id='" + dbGet.getStr("int_id") + "'";
                    DataTable dt = clsDB.QueryDataTable(q);
                    foreach (DataRow row in dt.Rows)
                    {
                        dbGet.setRow(row);
                        string s = dbGet.getImp("intrig_imp");
                        string strDes = dbGet.getStr("intrig_des");
                        if (strDes.Length > 50)
                            strDes = strDes.Substring(0, 50);
                        else
                            strDes = strDes + "".PadLeft(50 - strDes.Length);

                        TreeNode treeNode = new TreeNode(strDes + "".PadLeft(10 - s.Length) + s + " €");
                        node.Nodes.Add(treeNode);
                    }
                }
                node.ExpandAll();
            }
            totale();
        }

        /* */

        private void totale()
        {
            Dictionary<float, ClsIva> dicIva = new Dictionary<float, ClsIva>();
            totFat = totImp = totIva = 0;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[Fat.imp].Value == null)
                    continue;
                float fImp;
                string s = row.Cells[Fat.imp].Value.ToString().Replace ('.', ',');
                float.TryParse(s, out fImp);
                if (fImp == 0)
                {
                    row.Cells[Fat.qta].Value = "";
                    row.Cells[Fat.imp].Value = "";
                    row.Cells[Fat.alq].Value = "";
                    continue;
                }

                row.Cells[Fat.imp].Value = fImp.ToString(myGlobal.fmtImporto);

                float fAlq = (float) myGlobal.mnuAliqIva.Tag;
                if (row.Cells[Fat.alq].Value == null)
                    row.Cells[Fat.alq].Value = fAlq.ToString();
                else
                    float.TryParse(row.Cells[Fat.alq].Value.ToString(), out fAlq);

                float fQta = 0;
                float.TryParse(row.Cells[Fat.qta].Value.ToString(), out fQta);
                if (fQta == 0)
                    fQta = 1;
                row.Cells[Fat.qta].Value = fQta.ToString();
                fImp *= fQta;

                float fIva = (fImp / 100) * fAlq;
                fIva += 0.0049F;
                fIva = (float) Math.Round(fIva, 2);
                if (dicIva.ContainsKey(fAlq))
                {
                    ClsIva iva = dicIva[fAlq];
                    iva.Imp += fImp;
                    iva.Iva += fIva;
                    dicIva[fAlq] = iva;
                }
                else
                {
                    ClsIva iva = new ClsIva();
                    iva.Alq = fAlq;
                    iva.Imp = fImp;
                    iva.Iva = fIva;
                    dicIva.Add(fAlq, iva);
                }
                totImp += fImp;
                totIva += fIva;
            }
            dataGrid.Refresh();

            listViewIva.Items.Clear();
            foreach (var iva in dicIva)
            {
                ClsIva clsIva = iva.Value;
                ListViewItem item = new ListViewItem(clsIva.Alq.ToString());
                item.SubItems.Add(clsIva.Imp.ToString(myGlobal.fmtImporto));
                item.SubItems.Add(clsIva.Iva.ToString(myGlobal.fmtImporto));
                this.listViewIva.Items.Add(item);
            }

            listViewTot.Items[0].SubItems[1].Text = totImp.ToString(myGlobal.fmtImporto);
            listViewTot.Items[1].SubItems[1].Text = totIva.ToString(myGlobal.fmtImporto);
            listViewTot.Items[2].SubItems[1].Text = (totImp + totIva).ToString(myGlobal.fmtImporto);
            totFat = totImp + totIva;
            double totRitAcc = totFat * 0.04;
            Math.Round((Decimal)totRitAcc, 2, MidpointRounding.AwayFromZero);
            lblRitAcc.Text = totRitAcc.ToString(myGlobal.fmtImporto);
            lblTotDaPag.Text = (totFat - totRitAcc).ToString(myGlobal.fmtImporto);
        }

        /* */

        private void mnuItem_Click(object sender, EventArgs e)
        {
            if (dataGrid.CurrentCell == null)
                return;
            ToolStripMenuItem mnuItem = (ToolStripMenuItem)sender;
            dataGrid.CurrentCell.Value = mnuItem.Text.Replace("%", "");
            dataGrid.Refresh();
            totale();
            dataGrid.CurrentCell.Selected = false;
        }

        private void dataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            var hti = dataGrid.HitTest(e.X, e.Y);
            if (hti.RowIndex < 0 || hti.ColumnIndex < 0)
                return;
            dataGrid.ClearSelection();
//            dataGrid.Rows[hti.RowIndex].Selected = true;
            dataGrid.CurrentCell = dataGrid.Rows[hti.RowIndex].Cells[hti.ColumnIndex];
            dataGrid.CurrentCell.Selected = true;
            dataGrid.ContextMenuStrip = null;
            if (hti.ColumnIndex != Fat.alq)
                return;
            this.dataGrid.ContextMenuStrip = myGlobal.mnuAliqIva;
        }

        private void dataGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Fat.imp)
                totale();
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (dataGrid.SelectedCells.Count == 0)
                return;
            DataGridViewCell cell = dataGrid.SelectedCells[0];
            dataGrid.CurrentCell.Selected = false;
        }

        private void dataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (dataGrid.SelectedCells.Count == 0)
                return;
            DataGridViewCell cell = dataGrid.SelectedCells[0];
            if (cell.ColumnIndex == Fat.imp)
                totale();
            if (cell.ColumnIndex < dataGrid.ColumnCount - 1)
            {
                dataGrid.CurrentCell = dataGrid.Rows[cell.RowIndex - 1].Cells[cell.ColumnIndex + 1];
                dataGrid.CurrentCell.Selected = true;
            }
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != Fat.alq)
                return;
            totale();
        }

        /* */
        
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedo ?", "Cancellazione Fattura", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            clsDB.QueryString = "DELETE FROM fat WHERE fat_id=$1";
            clsDB.QueryReplace(1, lblFatId.Text);
            clsDB.QueryExec();
            frmMain.DialogResult = DialogResult.OK;
        }

        private void btnInsRow_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedCells.Count == 0)
                return;
            DataGridViewCell cell = dataGrid.SelectedCells[0];
            dataGrid.Rows.Insert(cell.RowIndex, " ", "", "", "");
            dataGrid.CurrentCell = dataGrid.Rows[cell.RowIndex - 1].Cells[Fat.des];
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedCells.Count == 0)
                return;
            DataGridViewCell cell = dataGrid.SelectedCells[0];
            dataGrid.Rows.RemoveAt(cell.RowIndex);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblFatId.Text == "")
            {
                lblFatId.Text = clsDB.nextId("fat", "fat_id");
                clsDB.QueryString = "INSERT INTO fat (fat_id) VALUES ($1)";
                clsDB.QueryReplace(1, lblFatId.Text);
                clsDB.QueryExec();
            }
            clsDB.QueryString = "UPDATE fat SET fat_dat=$1, fat_num=$2, fat_cli_id=$3, fat_cms_id=$4, fat_intest=$5, fat_codfis=$6, fat_tot=$7, fat_imp=$8, fat_iva=$9, fat_ndc=$10  WHERE fat_id=$99";
            clsDB.QueryReplace(1, this.datePicker.Value.ToString(myGlobal.fmtDataYMD));
            clsDB.QueryReplace(2, this.txtFatNum.Text);
            clsDB.QueryReplace(3, myGlobal.cli_id);
            clsDB.QueryReplace(4, myGlobal.cms_id);
            clsDB.QueryReplace(5, this.txtCliNom.Text);
            clsDB.QueryReplace(6, this.txtCliIva.Text);
            clsDB.QueryReplace(7, totFat.ToString(myGlobal.fmtImporto).Replace(',', '.'));
            clsDB.QueryReplace(8, totImp.ToString(myGlobal.fmtImporto).Replace(',', '.'));
            clsDB.QueryReplace(9, totIva.ToString(myGlobal.fmtImporto).Replace(',', '.'));
            clsDB.QueryReplace(10,comboTipoDoc.SelectedIndex.ToString());
//            clsDB.QueryReplace(10, radioBtnNdc.Checked == true ? "1" : "0");
            clsDB.QueryReplace(99, lblFatId.Text);
            clsDB.QueryExec();

            if (myGlobal.cms_id != "")
            {
                clsDB.QueryString = "UPDATE cms SET cms_fat_id=$1 WHERE cms_id=$99";
                clsDB.QueryReplace(1, lblFatId.Text);
                clsDB.QueryReplace(99, myGlobal.cms_id);
                clsDB.QueryExec();
            }

            clsDB.QueryString = "DELETE FROM fatrig WHERE fatrig_fat_id=$1";
            clsDB.QueryReplace(1, lblFatId.Text);
            clsDB.QueryExec();

            int rig = 1;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Index == dataGrid.Rows.Count - 1)
                    break;
                clsDB.QueryString = "INSERT INTO fatrig VALUES ($1,$2,$3,$4,$5,$6,$7)";
                clsDB.QueryReplace(1, lblFatId.Text);
                clsDB.QueryReplace(2, rig.ToString());
                string strInt_Id = "";
                if (row.Cells[Fat._id].Value != null)
                    strInt_Id = row.Cells[Fat._id].Value.ToString();
                clsDB.QueryReplace(3, strInt_Id);
                string strDes = row.Cells[Fat.des].Value == null ? "" : row.Cells[Fat.des].Value.ToString();
                clsDB.QueryReplace(4, strDes);
                if (row.Cells[Fat.imp].Value != null)
                {
                    clsDB.QueryReplace(5, row.Cells[Fat.qta].Value.ToString());
                    clsDB.QueryReplace(6, row.Cells[Fat.imp].Value.ToString().Replace (',', '.'));
                    if (row.Cells[Fat.alq].Value != null)
                        clsDB.QueryReplace(7, row.Cells[Fat.alq].Value.ToString());
                    else
                        clsDB.QueryReplace(7, myGlobal.mnuAliqIva.Tag.ToString());
                }
                else
                {
                    clsDB.QueryReplace(5, "");
                    clsDB.QueryReplace(6, "");
                    clsDB.QueryReplace(7, "");
                }
                clsDB.QueryExec();
                rig++;
                if (strInt_Id == "")
                    continue;
                clsDB.QueryString = "UPDATE interv SET int_fat_id=$1 WHERE int_id=$99";
                clsDB.QueryReplace(1, lblFatId.Text);
                clsDB.QueryReplace(99, strInt_Id);
                clsDB.QueryExec();
            }
            frmMain.DialogResult = DialogResult.OK;
        }

        private void btnStm_Click(object sender, EventArgs e)
        {
            Cir.Classi.ClsStampa stm = new Cir.Classi.ClsStampa(txtCliNom.Text, strCliInd, txtCliIva.Text,
                txtFatNum.Text, this.datePicker.Value.ToString(myGlobal.fmtDataUsr),
                totImp, totIva, dataGrid);
            frmMain.DialogResult = DialogResult.OK;        
        }

        private void txtFatNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFatNum_DoubleClick(object sender, EventArgs e)
        {
            if (txtFatNum.Text.Length > 0)
                return;
            int numFat = 0;
            String q = "SELECT fat_num FROM fat WHERE fat_dat <= " + datePicker.Value.ToString(myGlobal.fmtDataYMD) + " ORDER BY fat_dat DESC, fat_num DESC";
            DataTable dt = clsDB.QueryDataTable(q);
            if (dt.Rows.Count > 0)
            {
                q = dt.Rows[0][0].ToString();
                int.TryParse(q, out numFat);
            }
            txtFatNum.Text = (numFat + 1).ToString();

        }
    }
}
