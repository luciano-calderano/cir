using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.SubForm
{
    public partial class SubMainFrn : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;

        public SubMainFrn()
        {
            InitializeComponent();
        }

        private void SubFormFrn_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                return;
            this.listView.Height = (this.panelInfo.Top + this.panelInfo.Size.Height) - this.listView.Top;
            this.panelInfo.Hide();
            this.txtSrch.Text = "";
            this.ShowFrn("");
        }

        public void ShowFrn (string strSrch)
        {
            this.listView.Clear();
            this.listView.View = View.Details;
            this.listView.LabelEdit = false;
            this.listView.AllowColumnReorder = false;
            this.listView.CheckBoxes = false;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Sorting = SortOrder.None;

            this.listView.Columns.Add("Id", 0, HorizontalAlignment.Center);
            this.listView.Columns.Add("Nome", 300, HorizontalAlignment.Left);
            this.listView.Columns.Add("Indirizzo", 300, HorizontalAlignment.Left);
            this.listView.Columns.Add("Telefono", 300, HorizontalAlignment.Left);
            
            String q = "SELECT * FROM frn";
            if (strSrch.Length > 0)
                q += " WHERE frn_nom LIKE '%" + strSrch.Replace("'", "''").ToUpper() + "%'";
            q += " ORDER BY frn_nom LIMIT 1000";
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["frn_id"].ToString());
                item.SubItems.Add(row["frn_nom"].ToString());
                item.SubItems.Add(row["frn_ind"].ToString());
                item.SubItems.Add(row["frn_tel1"].ToString() + " " + row["frn_tel2"].ToString() + " " + row["frn_tel3"].ToString());
                item.UseItemStyleForSubItems = false;
                this.listView.Items.Add(item);
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 0)
                return;
            this.listView.Height = this.panelInfo.Top - this.listView.Top;
            this.panelInfo.Show();

            ListViewItem item = lv.SelectedItems[0];
            String q = "SELECT * FROM frn WHERE frn_id='" + item.Text + "'";

            DataTable dt = clsDB.QueryDataTable(q);
            DataRow rdr = dt.Rows[0];

            lblId.Text = item.Text;
            lblNom.Text = rdr["frn_nom"].ToString();
            lblInd.Text = rdr["frn_ind"].ToString();
            lblCapLoc.Text = "";
            string s;
            s = rdr["frn_cap"].ToString();
            if (s.Length > 0)
                lblCapLoc.Text += s + " ";
            s = rdr["frn_loc"].ToString();
            if (s.Length > 0)
            {
                if (lblCapLoc.Text.Length > 0)
                    lblCapLoc.Text += "- ";
                lblCapLoc.Text += s + " ";
            }
            s = rdr["frn_prv"].ToString();
            if (s.Length > 0)
                lblCapLoc.Text += "(" + s + ")";
            lblParIva.Text = "Partita Iva: " + rdr["frn_parIva"].ToString();
        
            s = rdr["frn_tit"].ToString();
            if (s.Length > 0)
                lblTit.Text = "Titolare: " + s;
            else
                lblTit.Text = "";

            s = rdr["frn_cnt"].ToString();
            if (s.Length > 0)
                lblCnt.Text = "Contatto: " + s;
            else
                lblCnt.Text = "";
        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            this.ShowFrn(txtSrch.Text);
        }

        private void btnNewFrn_Click(object sender, EventArgs e)
        {
            Cir.SubForm.ModalFormFrn modal = new Cir.SubForm.ModalFormFrn("");
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowFrn("");
        }

        private void btnModFrn_Click(object sender, EventArgs e)
        {
            Cir.SubForm.ModalFormFrn modal = new Cir.SubForm.ModalFormFrn(lblId.Text);
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.ShowFrn("");
        }
    }
}
