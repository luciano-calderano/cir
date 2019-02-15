using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Clie
{
    public partial class FrmCms : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private DataTable dataTableListCms;

        public FrmCms()
        {
            InitializeComponent();
            loadTree();
            //treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }
        private void loadTree()
        {
            treeView.Nodes.Clear();
 //           myGlobal.cli_id = "6";
            String q = "SELECT  cms.*, COUNT(DISTINCT int_id) AS numint, SUM(intRig_imp) AS totale FROM cms";
            q += " LEFT JOIN interv ON int_cms_id=cms_id";
            q += " LEFT JOIN intrig ON intrig_int_id=int_id";
            q += " WHERE cms_cli_id='" + myGlobal.cli_id + "' GROUP BY cms_id ORDER BY cms_scaden desc";
            
            dataTableListCms = clsDB.QueryDataTable(q);
            foreach (DataRow row in dataTableListCms.Rows)
            {               
                float f = float.Parse(row["cms_imp"].ToString());
                float t = float.Parse(row["totale"].ToString());
                string s = String.Format("{0,-45} ", row["cms_descri"].ToString());
                s += String.Format("{0,10} ", f.ToString("####0.00 €"));
                s += String.Format(" > {0,2} ", row["numint"].ToString());
                s += String.Format(" x {0,10} ", t.ToString("####0.00 €"));

                TreeNode treeNode = new TreeNode(s);
                treeNode.Tag = row;
                treeView.Nodes.Add(treeNode);

                int i = System.Convert.ToInt32(row["cms_tip"]);
                Color c;
                switch (i)
                {
                    case 1:
                        c = Color.Green;
                        break;
                    case 2:
                        c = Color.Red;
                        break;
                    default:
                        c = Color.Blue;
                        break;
                }
                treeNode.ForeColor = c;
                treeNode.BackColor = Color.Yellow;
            }
            treeView.SelectedNode = null;
        }

        private void treeView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeView.SelectedNode;

            if (node.Level > 1)
                return;
            if (node.Level == 1)
            {
                openInterv(node);
                return;
            }
            if (node.Nodes.Count > 0)
                return;
            DataRow rowParent = (DataRow)node.Tag;
            String q = "SELECT * FROM interv WHERE int_cms_id='" + rowParent["cms_id"].ToString() + "'"; 
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                TreeNode treeNode = new TreeNode(row["int_descri"].ToString());
                treeNode.Tag = row;
                node.Nodes.Add(treeNode);

                addIntervRig(treeNode);
            }
            node.ExpandAll();
        }

        private void addIntervRig(TreeNode node)
        {
            DataRow rowParent = (DataRow)node.Tag;
            String q = "SELECT * FROM intrig WHERE intrig_int_id='" + rowParent["int_id"].ToString() + "'"; 
            DataTable dt = clsDB.QueryDataTable(q);
            foreach (DataRow row in dt.Rows)
            {
                float f = (float) row["intrig_imp"];
                TreeNode treeNode = new TreeNode(String.Format("{0,-40} {1,10}", row["intrig_des"].ToString(), f.ToString("#####.00 €")));
                treeNode.Tag = row;
                node.Nodes.Add(treeNode);
            }
        }

        private void openInterv(TreeNode node)
        {
            DataRow row = (DataRow)node.Tag;
            myGlobal.int_id = row["int_id"].ToString();
            Cir.SubForm.ModalFormInterv modal = new Cir.SubForm.ModalFormInterv();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
                this.loadTree();

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        /*
        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Color nodeColor = Color.Red;
            if ((e.State & TreeNodeStates.Selected) != 0)
                nodeColor = SystemColors.HighlightText;

            TextRenderer.DrawText(e.Graphics,
                                  e.Node.Text,
                                  e.Node.NodeFont,
                                  e.Bounds,
                                  nodeColor,
                                  Color.Empty,
                                  TextFormatFlags.VerticalCenter);
        }
         */
    }
}
