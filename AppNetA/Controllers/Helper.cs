using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using DataTable = System.Data.DataTable;
using DataSet = System.Data.DataSet;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace AppNetA.Controllers
{
    public class Helper
    {
        //DecemberFilteredMonthlyNetworkD
        public static DataTable ReadExcelFile(string sheetName, string path)
        {

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = System.IO.Path.GetExtension(Import_FileName);
                var connString = string.Format(
                     @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""",
                     Path.GetDirectoryName(Import_FileName)
                 );
                conn.ConnectionString = connString;
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + "DecemberFilteredMonthlyNetworkData.csv" + "]";

                    comm.Connection = conn;

                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
            }
        }


        }
}