using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Cir
{
    public class ClsDB
    {
        private string logFile;
        private OleDbConnection _DBConn;

        public OleDbConnection dbConn
        {
            get { return _DBConn; }
        }

        public bool dbConnAtPath(String dbPath)
        {
            if (File.Exists(dbPath) == false)
                return false;

            String strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath + ";";
            this._DBConn = new OleDbConnection(strConn);
            if (this._DBConn == null)
                return false;
            logFile = dbPath + ".log";
            FileStream fileStream = new FileStream(logFile, FileMode.OpenOrCreate);
            fileStream.Close();
            return true;
        }
        
        public OleDbDataReader query(String q)
        {
            using (StreamWriter w = File.AppendText(logFile))
            {
                w.WriteLine(q);
                w.Flush();
                w.Close();
            }

            OleDbDataReader ret = null;
            try
            {
                if (this._DBConn.State == ConnectionState.Closed)
                    this._DBConn.Open();
                OleDbCommand cmd = new OleDbCommand(q, this._DBConn);
                ret = cmd.ExecuteReader();
            }
            catch (System.Data.OleDb.OleDbException exp)
            {
                Console.Write(exp.ToString(), q);
                MessageBox.Show(q, "Errore query !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret;
        }

        public void exec(String q)
        {
            using (StreamWriter w = File.AppendText(logFile))
            {
                w.WriteLine(q);
                w.Flush();
                w.Close();
            }
            try
            {
                if (this._DBConn.State == ConnectionState.Closed)
                    this._DBConn.Open();
                OleDbCommand cmd = new OleDbCommand(q, this._DBConn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                _DBConn.Close();
            }
            catch (System.Data.OleDb.OleDbException exp)
            {
                Console.Write(exp.ToString(), q);
                MessageBox.Show(q, "Errore query !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        public float getDbFlt(object r)
        {
            float f = 0;
            try { f = float.Parse(r.ToString()); } catch {}
            return f;
        }

        public int getDbInt(object r)
        {
            int i = 0;
            try { i = int.Parse(r.ToString()); } catch { }
            return i;
        }
    }
}
