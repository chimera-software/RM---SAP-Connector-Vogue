using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace RM___SAP_Connector
{
    class Utilities
    {
        public static void exportToCSV(DataTable datatable, string savePath, DateTime saveDate, string fileType, string warehouse)
        {
            StringBuilder sb = new StringBuilder();

            string[] columnNames = datatable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();

            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in datatable.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();

                sb.AppendLine(string.Join(",", fields));
            }

            if (savePath.Substring(savePath.Length - 2) != "\\")
            {
                string fileName = savePath + "\\" + "_" + saveDate.ToString("yyyyMMdd") + "_" + fileType + "_" + warehouse + ".csv";
                File.WriteAllText(fileName, sb.ToString());
                SettingsProperties.sb.AppendLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] - Generated File " + fileName + " Successfully! ");

            }
            else
            {
                string fileName = savePath + saveDate.ToString("yyyyMMdd")+ "_" + fileType + "_" + warehouse + ".csv";
                File.WriteAllText(fileName, sb.ToString());
                SettingsProperties.sb.AppendLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] - Generated File " + fileName + " Successfully! ");
            }

            File.AppendAllText(Environment.CurrentDirectory + "\\Log.txt", SettingsProperties.sb.ToString());
            SettingsProperties.sb.Clear();
        }
    }
}

