using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Cir
{
    public class ClsDataBase
    {
        // .NET guarantees thread safety for static initialization
        /*
        private string conf_dbSrv = @"dbSrv";
        private string conf_dbNam = @"dbNam";
        private string conf_dbUsr = @"dbUsr";
        private string conf_dbPwd = @"dbPwd";
        */
        private static ClsDataBase instance = null;
        private ClsDataBase()
        {
        }
        private static object syncLock = new object();
        public static ClsDataBase Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (ClsDataBase.instance == null)
                        ClsDataBase.instance = new ClsDataBase();
                    return ClsDataBase.instance;
                }
            }
        }

        private string logFile;
        private MySqlConnection _DBConn;

        public MySqlConnection dbConn
        {
            get { return _DBConn; }
        }

        public bool dbCheck()
        {
            bool dbExisits = this.openMySql();
            logFile = System.IO.Path.GetTempPath() + "Db.log";
            FileStream fileStream = new FileStream(logFile, FileMode.Create);
            fileStream.Close();

            return dbExisits;
        }
        /*
        public void saveParam(string strParam)
        {
            using (StreamWriter outfile = new StreamWriter(fileConf))
            {
                outfile.Write(strParam);
            }
        }
        */
        private bool openMySql()
        {
            string[] dbParam = myGlobal.db_param.Split(',');
            string MyConString = "SERVER=" + dbParam[0] + ";" +
                "DATABASE=" + dbParam[1] + ";" +
                "UID=" + dbParam[2] + ";" +
                "PASSWORD=" + dbParam[3] + ";";

            this._DBConn = new MySqlConnection(MyConString);

            bool ret = false;
            try
            {
                this._DBConn.Open();
                ret = true;
                this._DBConn.Close();
            }
            catch (ArgumentException a_ex)
            {
                Console.WriteLine("Check the Connection String.");
                Console.WriteLine(a_ex.Message);
                Console.WriteLine(a_ex.ToString());
            }
            catch (MySqlException ex)
            {
                string sqlErrorMessage = "Message: " + ex.Message + "\n" +
                "Source: " + ex.Source + "\n" +
                "Number: " + ex.Number;
                Console.WriteLine(sqlErrorMessage);
                
                switch (ex.Number)
                {
                    case 1042: // Unable to connect to any of the specified MySQL hosts (Check Server,Port)
                        break;
                    case 0: // Access denied (Check DB name,username,password)
                        break;
                    default:
                        break;
                }
            }
            finally
            {
            }
            return ret;
        }

        public DataTable dt;
        public DataTable QueryDataTable(String q)
        {
            using (StreamWriter w = File.AppendText(logFile))
            {
                w.WriteLine(q);
                w.Flush();
                w.Close();
            }

            MySqlDataAdapter adr = new MySqlDataAdapter(q, this._DBConn);
            adr.SelectCommand.CommandType = CommandType.Text;
            dt = new DataTable();
            adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)
            return dt;
        }
         public string QueryString { get; set; }

        public void QueryAppend(string strQuery)
        {
            QueryString += strQuery;
        }

        public void QueryReplace(int campo, string strQuery)
        {
            this.QueryReplace(campo.ToString(), strQuery);
        }

        public void QueryReplace(string campo, string strQuery)
        {
            campo = "$" + campo;
            string s = "'" + strQuery.Replace("'", "''") + "'";
            var regex = new Regex(Regex.Escape(campo));
            QueryString = regex.Replace(QueryString, s, 1);
        }

        public void QueryExec()
        {
            this.exec(QueryString);
        }

        public void QueryDB()
        {
            this.QueryDataTable(QueryString);
        }
        /*
        public DataTable Query()
        {
            return this.QueryDataTable(QueryString);
        }
        */
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
                var temp = this._DBConn.State.ToString();
                if (temp != "Open")
                    this._DBConn.Open();
                MySqlCommand command = this._DBConn.CreateCommand();
                command.CommandText = q;
                command.ExecuteNonQuery();
                this._DBConn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString() + "\n" + q);
                MessageBox.Show(q, "Errore query !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string dateFormatFromDB(object input)
        {
            int i = int.Parse(input.ToString());
            string s = String.Format("{0:00}", i % 100) + "/" + String.Format("{0:00}", (i / 100) % 100) + "/" + String.Format("{0:0000}", i / 10000);
            return (s);
        }

        public string dateFormatFromLong(string input)
        {
            int i = int.Parse(input);
            string s = String.Format("{0:00}", i % 100) + "/" + String.Format("{0:00}", (i / 100) % 100) + "/" + String.Format("{0:0000}", i / 10000);
            return (s);
        }

        public DateTime dateFromDB(object input)
        {
            return this.dateFromDB(input.ToString(), true);
        }
        public DateTime dateFromDB(object input, bool nullIsToday)
        {
            return this.dateFromDB(input.ToString(), nullIsToday);
        }
        public DateTime dateFromDB(string input, bool nullIsToday)
        {
            DateTime d;
            DateTime.TryParseExact(input.ToString(), myGlobal.fmtDataYMD, null, System.Globalization.DateTimeStyles.None, out d);
            if (nullIsToday == true && d <= DateTime.MinValue)
                d = DateTime.Today;
            return d;
        }

        public string datePickerToDB(DateTimePicker input)
        {
            return input.Value.ToString(myGlobal.fmtDataYMD);
        }

        public string convertImporto(object input)
        {
            float f = 0;
            float.TryParse(input.ToString(), out f);
            return f.ToString(myGlobal.fmtImporto);
        }

        public string nextId(string tabell, string field)
        {
            int intId = 0;
            String q = "SELECT MAX(" + field + ") FROM " + tabell;
            DataTable dt = this.QueryDataTable(q);
            if (dt.Rows.Count > 0)
            {
                q = dt.Rows[0][0].ToString();
                int.TryParse(q, out intId);
            }
            return (intId + 1).ToString();
        }
    }
 }
