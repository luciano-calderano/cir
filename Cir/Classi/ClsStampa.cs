using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cir.Classi
{
    class ClsStampa
    {
        private class Fat
        {
            public static int _id = 0;
            public static int des = 1;
            public static int qta = 2;
            public static int imp = 3;
            public static int alq = 4;
        }
 
        public ClsStampa(string strCliNom, string strCliInd, string strCliIva, string strFatNum, string strFatDat, double totImp, double totIva, DataGridView dataGrid)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\FattProva.pdf";
            /*
            path += "\\Fatture";
            if (System.IO.Directory.Exists (path) == false)
                System.IO.Directory.CreateDirectory(path);
            path += "\\" + this.datePicker.Value.ToString("yyyy");
            if (System.IO.Directory.Exists (path) == false)
                System.IO.Directory.CreateDirectory(path);
            path += "\\" + this.datePicker.Value.ToString("MMdd") + " (" + "Data " + this.datePicker.Value.ToString("dd-MM-yyyy") + " - Num. " + txtFatNum.Text + ") " + txtCliNom.Text + ".pdf";
             * */
            Pdf.ClsPdf clsPdf = new Pdf.ClsPdf(path);

            clsPdf.pdfTxtFnt = new Font("Arial", 10, FontStyle.Regular);
            clsPdf.pdfTxtCol = Brushes.Black;

            clsPdf.StmPict(0.5, 0.5, 4.0, 2.5, GetResourceImageByName("logo"));
            clsPdf.StmRect(0.4, 0.4, 4.2, 2.7, new Pen(Color.DarkGray, 0.5F));
            clsPdf.StmText(0.5, 3.2, 4.2, 0.3, "Via Castel di Leva", Pdf.ClsPdf.TextAlign.Center, new Font("Verdana", 5, FontStyle.Regular), Brushes.DarkGray);
            clsPdf.StmText(0.5, 3.6, 4.2, 0.3, "00100 Roma", Pdf.ClsPdf.TextAlign.Center, new Font("Verdana", 5, FontStyle.Regular), Brushes.DarkGray);

            double xPos = 14.9;
            clsPdf.StmRect(xPos, 2.0, 6.0, 2.0, Brushes.Gainsboro, new Pen(Color.DarkGray, 0.5F));
            clsPdf.StmText(xPos, 2.1, 5.8, 0.5, strCliNom, Pdf.ClsPdf.TextAlign.Right);
            clsPdf.StmText(xPos, 2.7, 5.8, 0.5, strCliInd, Pdf.ClsPdf.TextAlign.Right);
            clsPdf.StmText(xPos, 3.3, 5.8, 0.5, "Partita IVA: " + strCliIva, Pdf.ClsPdf.TextAlign.Right);
            clsPdf.StmText(xPos, 4.1, 5.8, 0.5, "Fattura n. " + strFatNum + " del " + strFatDat, Pdf.ClsPdf.TextAlign.Right);

            clsPdf.StmRect(00.1, 5.0, clsPdf.pdfW - 0.2, 06.0, Brushes.Gainsboro, new Pen(Color.DarkGray, 0.5F));
            clsPdf.StmRect(00.1, 5.6, clsPdf.pdfW - 0.2, 20.0, Brushes.White, new Pen(Color.DarkGray, 0.5F));

            clsPdf.StmText(00.2, 5.1, 15.5, 0.5, "Descrizione", Pdf.ClsPdf.TextAlign.Left);
            clsPdf.StmText(16.0, 5.1, 01.0, 0.5, "Q.tà", Pdf.ClsPdf.TextAlign.Right);
            clsPdf.StmText(17.0, 5.1, 03.0, 0.5, "Importo", Pdf.ClsPdf.TextAlign.Right);
            clsPdf.StmText(20.0, 5.1, 01.0, 0.5, "Iva", Pdf.ClsPdf.TextAlign.Center);
            clsPdf.pdfTxtFnt = new Font("Arial", 8, FontStyle.Regular);
            double yPos = 5.8;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Index == dataGrid.Rows.Count - 1)
                    break;
                string strDes = row.Cells[Fat.des].Value == null ? "" : row.Cells[Fat.des].Value.ToString();
                clsPdf.StmText(00.2, yPos, 15.5, 0.5, strDes, Pdf.ClsPdf.TextAlign.Left);
                clsPdf.StmText(16.0, yPos, 01.0, 0.5, row.Cells[Fat.qta].Value.ToString(), Pdf.ClsPdf.TextAlign.Right);
                clsPdf.StmText(17.0, yPos, 03.0, 0.5, row.Cells[Fat.imp].Value.ToString(), Pdf.ClsPdf.TextAlign.Right);
                clsPdf.StmText(20.0, yPos, 01.0, 0.5, row.Cells[Fat.alq].Value.ToString(), Pdf.ClsPdf.TextAlign.Center);
                yPos += 0.6;
            }
            
            clsPdf.StmRect(14.9, 26.0, 6.0, 2.5, Brushes.Gainsboro, new Pen(Color.DarkGray, 0.5F));
            clsPdf.pdfTxtFnt = new Font("Arial", 10, FontStyle.Regular);
            clsPdf.StmText(15.1, 26.2, 2.0, 0.7, "Imponibile", Pdf.ClsPdf.TextAlign.Left);
            clsPdf.StmText(17.2, 26.2, 3.6, 0.7, totImp.ToString(myGlobal.fmtImporto), Pdf.ClsPdf.TextAlign.Right);
            clsPdf.StmText(15.1, 26.9, 2.0, 0.7, "IVA", Pdf.ClsPdf.TextAlign.Left);
            clsPdf.StmText(17.2, 26.9, 3.6, 0.7, totIva.ToString(myGlobal.fmtImporto), Pdf.ClsPdf.TextAlign.Right);
            clsPdf.pdfTxtFnt = new Font("Arial", 10, FontStyle.Bold);
            clsPdf.StmText(15.1, 27.8, 2.0, 0.7, "Totale", Pdf.ClsPdf.TextAlign.Left);
            clsPdf.StmText(17.2, 27.6, 3.6, 0.7, (totImp + totIva).ToString(myGlobal.fmtImporto), Pdf.ClsPdf.TextAlign.Right);
            
            clsPdf.SavePdf();
            clsPdf.ShowPdf();
        }
        private Bitmap GetResourceImageByName(string imageName)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name + ".Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            return (Bitmap)rm.GetObject(imageName);
        }
    }
}
