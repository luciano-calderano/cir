using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Classi
{
    public class ClsDocTypes
    {
        public string strCode;
        public string strDesc;
        public float  fltMult;
    }
    public class ClsDocument
    {
        private static ClsDocument instance = null;
        private static object syncLock = new object();
        private ClsDocument()
        {
        }
        public static ClsDocument Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (ClsDocument.instance == null)
                    {
                        ClsDocument.instance = new ClsDocument();
                    }
                    return ClsDocument.Instance;
                }
            }
        }
        public List<ClsDocTypes> docType = new List<ClsDocTypes>();
        void open()
        {
            ClsDocTypes clsDoc;
            clsDoc = new ClsDocTypes();
            listAppend("FV", "Fattura di vendita", 1);
            listAppend("NC", "Nota di credito", -1);
            listAppend("FF", "Fattura fiscale", 1);
        }

        void listAppend(string code, string desc, float mult)
        {
            ClsDocTypes clsDoc;
            clsDoc = new ClsDocTypes();
            clsDoc.strCode = code;
            clsDoc.strDesc = desc;
            clsDoc.fltMult = mult;
            docType.Add(clsDoc);
        }
    }
}
