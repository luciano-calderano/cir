using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace Pdf
{
    public class ClsPdf
    {
        public enum TextAlign
        {
            Left,
            Right,
            Center,
        }

        private const float rapp = 28.3333f;
        private string nomeFile;
        private PdfDocument pdfDoc = new PdfDocument();
        private XGraphics pdfOut;
        public Font pdfTxtFnt;
        public Brush pdfTxtCol;
        public double pdfW;
        public double pdfH;
        public ClsPdf(string filename)
        {
            nomeFile = filename;
            PdfPage page = pdfDoc.AddPage();
            pdfOut = XGraphics.FromPdfPage(page);
            pdfW = pdfOut.PageSize.Width / rapp;
            pdfH = pdfOut.PageSize.Height / rapp;
        }

        public void SavePdf ()
        {
            pdfDoc.Save(nomeFile);
        }

        public void ShowPdf()
        {
            System.Diagnostics.Process.Start(nomeFile);
        }
        public void StmPict(double X, double Y, double W, double H, Image image)
        {
            pdfOut.DrawImage(image, X * rapp, Y * rapp, W * rapp, H * rapp);
        }

        public void StmRect(double X, double Y, double W, double H, Brush backColor)
        {
            XRect rect = new XRect(X * rapp, Y * rapp, W * rapp, H * rapp);
            pdfOut.DrawRectangle(backColor, rect);
        }

        public void StmRect(double X, double Y, double W, double H, Pen borderColor)
        {
            XRect rect = new XRect(X * rapp, Y * rapp, W * rapp, H * rapp);
            pdfOut.DrawRectangle(borderColor, rect);
        }
        public void StmRect(XUnit X, XUnit Y, XUnit W, XUnit H, Brush backColor, Pen borderColor)
        {
            if (X < 0)
                X += pdfOut.PageSize.Width;
            XRect rect = new XRect(X * rapp, Y * rapp, W * rapp, H * rapp);
            pdfOut.DrawRectangle(borderColor, backColor, rect);
        }

        public void StmText(double X, double Y, double W, double H, string txt)
        {
            StmText(X, Y, W, H, txt, TextAlign.Left, pdfTxtFnt, pdfTxtCol);
        }
        public void StmText(double X, double Y, double W, double H, string txt, TextAlign align)
        {
            StmText(X, Y, W, H, txt, align, pdfTxtFnt, pdfTxtCol);
        }
        public void StmText(double X, double Y, double W, double H, string txt, TextAlign align, Font font, Brush setColor)
        {
            if (X < 0)
                X += pdfOut.PageSize.Width;
            XParagraphAlignment xAlign;
            switch (align)
            {
                case TextAlign.Right:
                    xAlign = XParagraphAlignment.Right;
                    break;
                case TextAlign.Center:
                    xAlign = XParagraphAlignment.Center;
                    break;
                default:
                    xAlign = XParagraphAlignment.Left;
                    break;
            }
            XRect rect = new XRect(X * rapp, Y * rapp, W * rapp, H * rapp);
            XTextFormatter tf = new XTextFormatter(pdfOut);
            tf.Alignment = xAlign;
            XFont xFont = new Font(font.FontFamily, font.Size, font.Style, GraphicsUnit.World);
            tf.DrawString(txt, xFont, setColor, rect);
        }
    }
}
