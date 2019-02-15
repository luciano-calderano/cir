using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Cir.Classi
{
    class ClsDbGet
    {
        private DataRow row;
        public void setRow(DataRow dbRow)
        {
            row = dbRow;
        }
        public string getStr(string campo)
        {
            return getStr(row, campo);
        }
        public string getStr(DataRow row, string campo)
        {
            if (row[campo] == null)
                return "";
            return row[campo].ToString();
        }
        public string getImp(string campo)
        {
            return getImp(row, campo);
        }
        public string getImp(DataRow row, string campo)
        {
            if (row[campo] == null)
                return "";
            float f = 0;
            float.TryParse(row[campo].ToString(), out f);
            return f.ToString(myGlobal.fmtImporto);
        }
        public float getFlt(string campo)
        {
            return getFlt(row, campo);
        }
        public float getFlt(DataRow row, string campo)
        {
            if (row[campo] == null)
                return 0;
            float f = 0;
            float.TryParse(row[campo].ToString(), out f);
            return f;
        }
        public int getInt(string campo)
        {
            return getInt(row, campo);
        }
        public int getInt(DataRow row, string campo)
        {
            if (row[campo] == null)
                return 0;
            int i = 0;
            int.TryParse(row[campo].ToString(), out i);
            return i;
        }
        public string getDat(string campo)
        {
            return getDat(row, campo);
        }
        public string getDat(DataRow row, string campo)
        {
            if (row[campo] == null)
                return "";
            int i = 0;
            int.TryParse(row[campo].ToString(), out i);
            if (i == 0)
                return "";
            string s = String.Format("{0:00}", i % 100) + "/" + String.Format("{0:00}", (i / 100) % 100) + "/" + String.Format("{0:0000}", i / 10000);
            return (s);
        }
        public DateTime getDatVal(string campo)
        {
            return getDatVal(row, campo);
        }
        public DateTime getDatVal(DataRow row, string campo)
        {
            DateTime d;
            DateTime.TryParseExact(row[campo].ToString(), myGlobal.fmtDataYMD, null, System.Globalization.DateTimeStyles.None, out d);
            if (d <= DateTime.MinValue)
                d = DateTime.Today;
            return d;
        }
    }
}
