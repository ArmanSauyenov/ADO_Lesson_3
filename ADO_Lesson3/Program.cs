using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Lesson3
{
    class Program
    {

        private static SqlConnection con = new SqlConnection();
        static void Main(string[] args)
        {
            con.ConnectionString = "Data Source=192.168.110.195; Initial Catalog=MCS; User ID=sa; Password=Ev4865";
            Task3();
            #region
            //DataSet ds = new DataSet();
            //DataTable tbl = ds.Tables.Add("newEquipment");
            //SqlDataAdapter da = new SqlDataAdapter("select * from newEquipment", con);

            ////инициализируем объект TblMapping
            //DataTableMapping tblMap;
            //DataColumnMapping colMap = new DataColumnMapping();
            //tblMap = da.TableMappings.Add("Table", "newEquipment");
            //colMap = tblMap.ColumnMappings.Add("intEquipmentID", "EquipmentID");
            //colMap = tblMap.ColumnMappings.Add("intGarageRoom", "GarageRoom");
            //colMap = tblMap.ColumnMappings.Add("strSerialNo", "SerialNo");

            ////tblMap.ColumnMappings.AddRange(;
            ////da.TableMappings.AddRange(tblMap);
            //con.Open();

            //da.Fill(ds);
            ////деление на страницы
            //int start = 0;
            //int numRec = 10;
            //da.Fill(ds, start, numRec, "newEquipment");

            //con.Close();

            //foreach (DataTable table in ds.Tables)
            //{
            //    Console.WriteLine(table.TableName);
            //    //foreach (DataColumn column in table.Columns)
            //    //{
            //    //    Console.WriteLine("\t{0}", column.ColumnName);
            //    //    //
            //    //    // Console.WriteLine("{0,-10}", "Hello"); // Hello[5 пробелов]

            //    //}
            //    foreach (DataRow row in table.Rows)
            //    {
            //        //   Console.WriteLine( "\t\t|" + row["EquipmentID"] + " | "+ row["GarageRoom"] + " | " + row["SerialNo"]);
            //        Console.WriteLine("\t|{0,5} | {1, 40} | {2, 30} |", row["EquipmentID"], row["GarageRoom"], row["SerialNo"]);

            //    }
            //}

            #endregion



        }



        static void Task3()
        {
            SqlDataAdapter da = new SqlDataAdapter("select top 10 * from TablesModel", con);

            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            //
            DataRow row = dt.NewRow();
            row["strName"] = "Outback";
            row["intManufacturerID"] = 1;
            row["intSMCSFamilyID"] = 1;
            row["strImage"] = "19.png";
            dt.Rows.Add(row);

            //создать объект
            SqlCommandBuilder cmBuilder = new SqlCommandBuilder(da);
            da.Update(ds);

            ds.Clear();

            da.Fill(ds);


            foreach (DataRow rowItem in ds.Tables[0].Rows)
            {
                for (int i = 0; i < rowItem.ItemArray.Length; i++)
                {
                    Console.Write("\t {0, 10}|", rowItem[i]);
                }
                Console.WriteLine("");
            }
        }


    }
}

