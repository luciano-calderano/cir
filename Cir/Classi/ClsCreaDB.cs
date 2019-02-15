using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Cir.Classi
{
    class ClsCreaDB
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;

        private void openDB ()
        {
            this.insertRap();
        }

        //        00001|ALTINO N. 15 - CONDOMINIO|VIA ALTINO N. 15|00183|ROMA|RM|ALLEGRETTI CRISTIANO
        private void insertFrn()
        {
            string s = File.ReadAllText(@"D:\Lc\Src\clifor.dat.txt");
            string[] rig = s.Split('\n');
            foreach (string riga in rig)
            {
                string[] campi = riga.Split('|');
                if (campi[0] == "C")
                    continue;
                string q;

                if (campi.Count() < 10)
                    continue;
                q = "INSERT INTO frn (id) VALUES  ('" + campi[1] + "')";
                clsDB.exec(q);

                q = "UPDATE frn SET ";
                q += " nome='" + campi[2].Replace("'", "''") + "'";
                q += ",indirizzo='" + campi[3].Replace("'", "''") + "'";
                q += ",cap='" + campi[4] + "'";
                q += ",loc='" + campi[5].Replace("'", "''") + "'";
                q += ",prov='" + campi[6] + "'";
                q += ",partIva='" + campi[12] + "'";
                q += ",codFisc='" + campi[11] + "'";
                q += ",titolare='" + campi[7].Replace("'", "''") + "'";
                q += ",contatto='" + campi[13].Replace("'", "''") + "'";
                q += ",tel1='" + campi[8] + "'";
                q += ",tel2='" + campi[9] + "'";
                q += ",tel3='" + campi[10] + "'";
                q += " WHERE id='" + campi[1] + "'";
                // Console.Write(q);
                clsDB.exec(q);
            }

        }

        private void insertCli()
        {
            string s = File.ReadAllText(@"D:\Lc\Src\clifor.dat.txt");
            string[] rig = s.Split('\n');
            foreach (string riga in rig)
            {
                string[] campi = riga.Split('|');
                if (campi[0] == "F")
                    continue;
                string q;

                MySqlDataReader rdr;
                if (campi.Count() < 10)
                    continue;
                string amm = campi[7].Replace("'", "''");
                int idAmm = 0;
                q = "SELECT id FROM amm WHERE nome='" + amm + "'";
                rdr = clsDB.query(q);
                if (rdr.HasRows)
                {
                    rdr.Read();
                    idAmm = rdr.GetInt32("id");
                    rdr.Close();
                }
                else
                {
                    rdr.Close();
                    q = "SELECT MAX(id) FROM amm";
                    rdr = clsDB.query(q);
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        idAmm = rdr.GetInt32(0) + 1;
                        rdr.Close();
                    }
                    q = "INSERT INTO amm (id, nome) VALUES ('" + idAmm + "','" + amm + "')";
                    clsDB.exec(q);
                }

                q = "INSERT INTO cli (id) VALUES  ('" + campi[1] + "')";
                clsDB.exec(q);


                q = "UPDATE cli SET ";
                q += " nome='" + campi[2].Replace("'", "''") + "'";
                q += ",indirizzo='" + campi[3].Replace("'", "''") + "'";
                q += ",cap='" + campi[4] + "'";
                q += ",loc='" + campi[5].Replace("'", "''") + "'";
                q += ",prov='" + campi[6] + "'";
                q += ",partIva='" + campi[12] + "'";
                q += ",idAmm='" + idAmm + "'";
                q += ",datInizAmm='0'";
                q += " WHERE id='" + campi[1] + "'";
                // Console.Write(q);
                clsDB.exec(q);
            }
        }
        //        C|00001|ALTINO N. 15 - CONDOMINIO|VIA ALTINO N. 15|00183|ROMA|RM|ALLEGRETTI CRISTIANO|||||80313340582|

        private void insertRap()
        {
            string s = File.ReadAllText(@"D:\Lc\Src\RapFinale.txt");
            string[] rig = s.Split('\n');
            int idRap = 1;
            foreach (string riga in rig)
            {

                string[] campi = riga.Split('|');
                if (campi.Count() < 9)
                    continue;
                string cms = campi[2];
                string tec = campi[3];
                string q = "INSERT INTO interv VALUES ('" + idRap++ + "','0','" + campi[0] + "','"
                    + cms + "','" + tec + "','" + campi[4] + "','"
                    + campi[1] + "','" + campi[5] + "','" + campi[6] + "','"
                    + campi[7] + "','" + campi[8] + "','" + campi[9].Replace("'", "''") + "','0','0','0','')";
                // Console.Write(q);
                clsDB.exec(q);
            }
        }

        /*
         * 
         * INSERT INTO interv VALUES ('2','0','00001','','6','2','20031020','1120','1500','A','','CHIUSURA TRACCE,NEL LOCALE CALDAIA,DELLA CANNA FUMARIA.MONTAGGIO DI SOSTEGNO CANNA FUMARIACON mt.6 DI CATENELLA.',','0','0','','')
        id` int(5) NOT NULL,
  `idRich` int(5) DEFAULT NULL,
  `codCli` int(5) DEFAULT NULL,
  `idCms` int(4) DEFAULT NULL,
  `idTec` int(4) DEFAULT NULL,
  `qtaTec` int(2) DEFAULT NULL,
  `datIniz` int(8) DEFAULT NULL,
  `oraIniz` int(4) DEFAULT NULL,
  `oraFine` int(4) DEFAULT NULL,
  `tipo` text COLLATE utf8_bin,
  `codice` text COLLATE utf8_bin,
  `descri` varchar(300) COLLATE utf8_bin DEFAULT NULL,
  `importo` float DEFAULT NULL,
  `datFatt` int(8) DEFAULT NULL,
  `numFatt` text COLLATE utf8_bin,
  `note` varchar(80) COLLATE utf8_bin NOT NULL,
        */
        //cliente,data,commessa,tecnico,numero operai,ora inizio, ora fine,tipo intervento,codice intervento, descrizione
        //00001|20020404|2|1|1|1100|1200|A||VOGLIO ANDARE AL MARE

        private void insertTec()
        {
            string s = File.ReadAllText(@"D:\Lc\Src\Cirtec.txt");
            string[] rig = s.Split('\n');
            foreach (string riga in rig)
            {
                string[] campi = riga.Split('|');
                int cod = int.Parse(campi[0]);
                string nome = campi[1].Substring(0, 20);
                nome = nome.Trim();
                string q = "INSERT INTO tec VALUES ('" + campi[0] + "','" + nome + "')";
                clsDB.exec(q);
            }
        }

        private void insertTip()
        {
            string s = File.ReadAllText(@"D:\Lc\Src\CIRtipInt.txt");
            string[] rig = s.Split('\n');
            foreach (string riga in rig)
            {
                string[] campi = riga.Split('|');
                string nome = campi[1];
                nome = nome.Trim();
                string q = "INSERT INTO tipint VALUES ('" + campi[0] + "','" + nome + "')";
                clsDB.exec(q);
            }
        }





    }
}
