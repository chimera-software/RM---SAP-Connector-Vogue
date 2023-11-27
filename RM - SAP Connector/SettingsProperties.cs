using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace RM___SAP_Connector
{
    class SettingsProperties
    {

        public static string connectionString;
        public static string sourceFolder;
        public static string destFolder;
        public static DateTime autoGenTime;
        public static StringBuilder sb = new StringBuilder();
        public static bool isAutoGen;
        public static string appSettingsJSON;


        public static DataTable sls = new DataTable();
        public static DataTable sdet = new DataTable();
        public static DataTable rep = new DataTable();
        public static DataTable menu = new DataTable();
        public static DataTable pages = new DataTable();
        public static DataTable revCent = new DataTable();
        public static DataTable tipopag = new DataTable();
        public static DataTable dataTable = new DataTable();
        public static DataTable payments = new DataTable();
        public static DataTable emp = new DataTable();

        public static string billNoList;
        public static string sessNoList;

        public static string branchCode;
        public static string warehouseCode;

        public static string prefix;

        #region "JSON APP SETTINGS"
        public static void createDefaultJSON()
        {
            AppSettings settings = new AppSettings()
            {
                sourceFolder = "D:\\Rmwin",
                connectionString = "Driver ={ Microsoft dBASE Driver(*.dbf)}; DriverID = 227; Dbq = D:\\Rmwin; ",
                isAutoGen = false,
                destFolder = "D:\\Rmwin",
                branchCode = "123",
                warehouseCode = "123",
                prefix = "123"
            };

            string jsonSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);
            using (StreamWriter tw = File.CreateText(Environment.CurrentDirectory + "\\Settings.json"))
            {
                tw.WriteLine(jsonSettings);
            }
        }

        public static void getSettings()
        {
            using (StreamReader r = new StreamReader(Environment.CurrentDirectory + "\\Settings.json"))
            {
                appSettingsJSON = r.ReadToEnd();
            }

            var root = JsonConvert.DeserializeObject<AppSettings>(appSettingsJSON);
            sourceFolder = root.sourceFolder;
            connectionString = root.connectionString;
            isAutoGen = root.isAutoGen;
            autoGenTime = Convert.ToDateTime(root.autoGenTime);
            destFolder = root.destFolder;
            branchCode = root.branchCode;
            warehouseCode = root.warehouseCode;
            prefix = root.prefix;
        }

        public static void saveSettings(string rmFolder, string conString, bool autoGen, string time, string destFold, string branchCode, string warehouseCode, string prefix)
        {
            AppSettings appSettings = new AppSettings()
            {
                sourceFolder = rmFolder,
                connectionString = conString,
                isAutoGen = autoGen,
                autoGenTime = time,
                destFolder = destFold,
                branchCode = branchCode,
                warehouseCode = warehouseCode,
                prefix = prefix

            };

            string jsonSettings = JsonConvert.SerializeObject(appSettings, Formatting.Indented);

            using (StreamWriter tw = File.CreateText(Environment.CurrentDirectory + "\\Settings.json"))  // overwrites existing file w/ new values 
            {
                tw.WriteLine(jsonSettings);
            }
        }
        #endregion

        #region "INITIALIZE TABLES
        public static void initializeTables()
        {
            menu = Queries.loadMenu();
            pages = Queries.loadPages();
            revCent = Queries.loadRevCent();
            tipopag = Queries.loadPaymentTypes();
            emp = Queries.loadEmployees();
        }

        public static void initializeTablesPerDay(DateTime fromDate, DateTime toDate)
        {
            rep = Queries.loadSessions(fromDate, toDate);
            if (rep.Rows.Count == 0)
            {
                return;
            }
            sessNoList = "";
            sessNoList = Queries.loadSessNos();
            sls = Queries.loadSalesHeader(fromDate, sessNoList);
            billNoList = "";
            billNoList = Queries.loadBillNos();
            sdet = Queries.loadSalesDetails(fromDate, billNoList);
            payments = Queries.loadPayments(fromDate, billNoList);

        }
        #endregion

    }

    public class AppSettings
    {
        public string sourceFolder { get; set; }
        public string connectionString { get; set; }
        public bool isAutoGen { get; set; }
        public string autoGenTime { get; set; }
        public string destFolder { get; set; }
        public string branchCode { get; set; }
        public string warehouseCode { get; set; }
        public string prefix { get; set; }
    }
}
