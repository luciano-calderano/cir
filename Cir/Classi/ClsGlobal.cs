using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    public static class myGlobal
    {
        public const string conf_dbSrv = @"dbSrv";
        public const string conf_dbNam = @"dbNam";
        public const string conf_dbUsr = @"dbUsr";
        public const string conf_dbPwd = @"dbPwd";

        public const string fmtImporto = "######0.00";
        public const string fmtDataYMD = "yyyyMMdd";
        public const string fmtDataUsr = "dd/MM/yyyy";

        public static string cli_id { get; set; }
        public static string int_id { get; set; }
        public static string ric_id { get; set; }
        public static string amm_id { get; set; }
        public static string cms_id { get; set; }
        public static string scaden_id { get; set; }
        public static Cir.FormMain frmMain { get; set; }

        public static string fileConf { get; set; }
        public static string db_param { get; set; }
        public static string pathDotx { get; set; }
        public static string pathDocx { get; set; }

        public static float costoOra { get; set; }
        public static System.Windows.Forms.ContextMenuStrip mnuAliqIva = null;

        public class ClsDocument
        {
            public string strCode;
            public string strDesc;
            public float fltMult;
        }
        public static List<ClsDocument> listDocument = new List<ClsDocument>();
        public static void listDocs()
        {
            ClsDocument clsDoc = new ClsDocument();
            listAppend("FV", "Fattura di vendita", 1);
            listAppend("NC", "Nota di credito", -1);
            listAppend("FF", "Fattura fiscale", 1);
        }

        public static void listAppend(string code, string desc, float mult)
        {
            ClsDocument clsDoc = new ClsDocument();
            clsDoc.strCode = code;
            clsDoc.strDesc = desc;
            clsDoc.fltMult = mult;
            listDocument.Add(clsDoc);
        }
        /*
        public static float[] aliqIva = { 0, 0, 0, 0 }; 
        public static System.Windows.Forms.DataGridViewComboBoxColumn comboIva ()
        {
            System.Windows.Forms.DataGridViewComboBoxColumn cmb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            cmb.HeaderText = "Aliq. Iva";
            cmb.Name = "cmbAliqIva";
            cmb.MaxDropDownItems = 4;
            for (int i = 0; i < 4; i++)
            {
                if (myGlobal.aliqIva[i] > 0)
                    cmb.Items.Add(myGlobal.aliqIva[i].ToString());
            }
            return cmb;
        }

        public static void initAliqIva(object alq1,object alq2,object alq3,object alq4)
        {
            myGlobal.aliqIva[0] = (float)alq1;
            myGlobal.aliqIva[1] = (float)alq2;
            myGlobal.aliqIva[2] = (float)alq3;
            myGlobal.aliqIva[3] = (float)alq4;
        }
        */

        public static void loadDefault()
        {
            db_param = "";
            pathDotx = "";
            pathDocx = "";
            listDocs();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Cir";
            fileConf = path + "\\Config.ini";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
                string s = "IP ?,cir,root,";
                using (StreamWriter outfile = new StreamWriter(myGlobal.fileConf))
                {
                    outfile.Write(s);
                }
 
            }
            string[] tmp = File.ReadAllLines(fileConf);
            if (tmp.Count() > 0)
                db_param = tmp[0];
            if (tmp.Count() > 1)
                pathDotx = tmp[1];
            if (tmp.Count() > 2)
                pathDocx = tmp[2];
        }

        public static void defaultListView(System.Windows.Forms.ListView listView)
        {
            myGlobal.defaultListView(listView, true);
        }
        public static void defaultListView(System.Windows.Forms.ListView listView, bool ownerDraw)
        {
            listView.Clear();
            listView.View = System.Windows.Forms.View.Details;
            listView.LabelEdit = false;
            listView.AllowColumnReorder = false;
            listView.CheckBoxes = false;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Sorting = System.Windows.Forms.SortOrder.None;
            listView.OwnerDraw = ownerDraw;
            if (ownerDraw == false)
                return;
            listView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(listView_DrawColumnHeader);
            listView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(listView_DrawSubItem);
        }
        public static void listView_DrawColumnHeader(object sender, System.Windows.Forms.DrawListViewColumnHeaderEventArgs e)
        {
            if (e.Bounds.Width == 0)
                return;

            using (System.Drawing.StringFormat sf = new System.Drawing.StringFormat())
            {
                switch (e.Header.TextAlign)
                {
                    case System.Windows.Forms.HorizontalAlignment.Center:
                        sf.Alignment = System.Drawing.StringAlignment.Center;
                        break;
                    case System.Windows.Forms.HorizontalAlignment.Right:
                        sf.Alignment = System.Drawing.StringAlignment.Far;
                        break;
                }
                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.LightGray), e.Bounds);
                e.Graphics.DrawRectangle(new System.Drawing.Pen(new System.Drawing.SolidBrush(System.Drawing.Color.White), 2), e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 2);
                using (System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold))
                {
                    System.Drawing.Rectangle rect = e.Bounds;
                    rect.Y += 4;
                    if (sf.Alignment == System.Drawing.StringAlignment.Near)
                        rect.X += 2;                        
                    e.Graphics.DrawString(e.Header.Text, headerFont, new System.Drawing.SolidBrush(System.Drawing.Color.Black), rect, sf);
                }
            }
            return;
        }
        public static void listView_DrawSubItem(object sender, System.Windows.Forms.DrawListViewSubItemEventArgs e)
        {
            if (e.Bounds.Width == 0)
                return;
            if (e.SubItem.Text.Length == 0)
                return;

            using (System.Drawing.StringFormat sf = new System.Drawing.StringFormat())
            {
                switch (e.Header.TextAlign)
                {
                    case System.Windows.Forms.HorizontalAlignment.Center:
                        sf.Alignment = System.Drawing.StringAlignment.Center;
                        break;
                    case System.Windows.Forms.HorizontalAlignment.Right:
                        sf.Alignment = System.Drawing.StringAlignment.Far;
                        break;
                }
                using (System.Drawing.Font subItemFont = new System.Drawing.Font("System", 9))
                {
                    e.Graphics.DrawString(e.SubItem.Text, subItemFont, new System.Drawing.SolidBrush(System.Drawing.Color.Black), e.Bounds, sf);
                }
            }
        }

    }
