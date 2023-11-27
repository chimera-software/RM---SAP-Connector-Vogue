using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace RM___SAP_Connector
{
    class Queries
    {
        #region "LOAD DATA TABLE FOR EXPORT"
        public static DataTable loadSalesTable(DateTime fromDate)
        {
            DataTable data = new DataTable();

            data.Columns.Add("DATE"); //0
            data.Columns.Add("BRANCHCODE"); //1
            data.Columns.Add("WAREHOUSECODE");//2
            data.Columns.Add("CURRENCY");//3
            data.Columns.Add("ERPCODE");//4
            data.Columns.Add("ITEMNAME");//5
            data.Columns.Add("RAWPRICE");//6
            data.Columns.Add("GROSSAMT");//7
            data.Columns.Add("NETVALUE");//8
            data.Columns.Add("QTYSOLD");//9
            data.Columns.Add("REVENUECENTER");//10
            data.Columns.Add("EMPNAME");//11
            data.Columns.Add("INVOICENO");//12

            if (SettingsProperties.rep.Rows.Count > 0)
            {
                //foreach (DataRow dr in SettingsProperties.menu.Rows)
                //{
                //    string[] itemData = getFoodData(dr["REF_NO"].ToString()).Split(',');

                //    //if (itemData[0] != "0" && itemData[1] != "0")
                //    if (itemData[1] != "0")
                //    {
                //        foreach (DataRow dr2 in SettingsProperties.revCent.Rows)
                //        {
                //            string[] itemData2 = getFoodDataRevCent(dr["REF_NO"].ToString(), dr2["REV_CENTER"].ToString()).Split(',');

                //            if (itemData2[1] != "0")
                //            {
                //                DataRow newRow = data.NewRow();
                //                newRow[0] = fromDate.ToString("MM/dd/yyyy");
                //                newRow[1] = SettingsProperties.branchCode;
                //                newRow[2] = SettingsProperties.warehouseCode;
                //                newRow[3] = "QAR";
                //                if (dr["BAR_CODE"].ToString() != "")
                //                {
                //                    newRow[4] = dr["BAR_CODE"].ToString();
                //                }
                //                else
                //                {
                //                    newRow[4] = "";
                //                }
                //                newRow[5] = dr["DESCRIPT"].ToString().Replace(',', ' ');
                //                newRow[6] = itemData2[3];
                //                newRow[7] = itemData2[2];
                //                newRow[8] = itemData2[0];
                //                newRow[9] = itemData2[1];
                //                newRow[10] = dr2["RC_NAME"].ToString();

                //                data.Rows.Add(newRow);
                //            }

                            
                //        }
                //    }
                //}

                foreach(DataRow dr in SettingsProperties.sdet.Rows)
                {

                    double tempAmt = 0;
                    double tempGrossAmt = 0;


                    double pricePaid = Convert.ToDouble(dr["PRICE_PAID"].ToString());
                    double rawPrice = Convert.ToDouble(dr["RAW_PRICE"].ToString());
                    double qty = Convert.ToDouble(dr["QUANTY"].ToString());

                    tempAmt = pricePaid * qty;
                    tempGrossAmt = rawPrice * qty;


                    DataRow newRow = data.NewRow();

                    string[] itemData = getBarcode(dr["REF_NO"].ToString()).Split(',');
                    string[] salesData = getSalesData(dr["BILL_NO"].ToString()).Split(',');

                    newRow[0] = fromDate.ToString("MM/dd/yyyy");
                    newRow[1] = SettingsProperties.branchCode;
                    newRow[2] = SettingsProperties.warehouseCode;
                    newRow[3] = "QAR";
                    newRow[4] = itemData[0];
                    newRow[5] = itemData[1].Replace(',', ' ');
                    newRow[6] = rawPrice.ToString();
                    newRow[7] = tempGrossAmt.ToString();
                    newRow[8] = tempAmt.ToString();
                    newRow[9] = qty.ToString();
                    newRow[10] = salesData[0];
                    newRow[11] = salesData[1];
                    newRow[12] = dr["BILL_NO"].ToString();

                    data.Rows.Add(newRow);

                }
            }

            return data;
        }

        public static DataTable loadFinanceTable(DateTime fromDate)
        {
            DataTable data = new DataTable();

            data.Columns.Add("DATE");
            data.Columns.Add("INVOICENO");
            data.Columns.Add("TOTALAMT");
            data.Columns.Add("PAYMENTNAME");


            if (SettingsProperties.rep.Rows.Count > 0)
            {
                foreach (DataRow dr in SettingsProperties.sls.Rows)
                {
                    if (dr["PAY_TYPE"].ToString() == "5")
                    {
                        continue;
                    }
                    string[] pmtDetails = getPaymentData(dr["BILL_NO"].ToString()).Split(',');
                    DataRow newRow = data.NewRow();
                    newRow[0] = fromDate.ToString("MM/dd/yyyy");
                    newRow[1] = dr["BILL_NO"].ToString();
                    newRow[2] = pmtDetails[0];
                    newRow[3] = pmtDetails[1];

                    data.Rows.Add(newRow);
                }
            }

            return data;
        }
        #endregion
        #region "LOAD RM DATA TABLES"

        public static DataTable loadEmployees()
        {
            string cmdString = "SELECT EMP_NO, EMP_NAME, EMP_ACTIVE FROM EMPLOYEE.DBF WHERE EMP_NAME <> '' ";
            DataTable tempdetails = new DataTable();
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadMenu()
        {
            string tableToUse = "MENU";
            string cmdString = "SELECT REF_NO, DESCRIPT, PAGE_NUM, BAR_CODE FROM " + tableToUse + " WHERE DESCRIPT <> '' AND REF_NO < 10000";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadRevCent()
        {
            string tableToUse = "REVCENT.DBF";
            string cmdString = "SELECT RC_NAME, REV_CENTER FROM " + tableToUse + " WHERE RC_NAME <> '' ";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadPages()
        {
            string tableToUse = "PAGES";
            string cmdString = "SELECT PAGE_NUM, PAGE_NAME, PAGE_TYPE FROM " + tableToUse + " WHERE PAGE_NAME <> ' ' ";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadPaymentTypes()
        {
            string tableToUse = "TIPOPAG";
            string cmdString = "SELECT TPAGO_NO, TPAGO_NAME FROM " + tableToUse + " WHERE TPAGO_NAME <> ' ' ";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadSessions(DateTime fromDate, DateTime toDate)
        {
            string tableToUse = "REP" + fromDate.ToString("yy");
            string cmdString = "SELECT SESSION_NO, SALES, TABLES, CUSTOMERS, DATE_START, FIRST_BILL, LAST_BILL, TIME_START, DATE_END FROM " + tableToUse + " WHERE DATE_START BETWEEN #" + fromDate.ToString("MM/dd/yyyy") + "# AND #" + toDate.ToString("MM/dd/yyyy") + "# ";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadSalesHeader(DateTime fromDate, string sessionNo)
        {
            string tableToUse = "SLS" + fromDate.ToString("MM") + fromDate.ToString("yy");
            string cmdString = "SELECT BILL_NO, SESSION_NO, PAY_TYPE, OPEN_TIME, BILL_TIME, REV_CENTER, WAITER FROM " + tableToUse + " WHERE SESSION_NO IN (" + sessionNo + ") ORDER BY BILL_NO ASC ";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadSalesDetails(DateTime fromDate, string billNos)
        {
            string tableToUse = "SDET" + fromDate.ToString("MM") + fromDate.ToString("yy");
            string cmdString = "SELECT BILL_NO, REF_NO, QUANTY, PRICE_PAID, RAW_PRICE, ITEM_ADJ, DISC_ADJ FROM " + tableToUse +
                " WHERE BILL_NO IN (" + billNos + ")";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadPayments(DateTime fromDate, string billNos)
        {
            string tableToUse = "PMT" + fromDate.ToString("MM") + fromDate.ToString("yy");
            string cmdString = "SELECT BILL_NO, PAY_TYPE, BASE_AMT FROM " + tableToUse +
                " WHERE BILL_NO IN (" + billNos + ")";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }

        public static DataTable loadDeletions(DateTime fromDate, string billNos)
        {
            string tableToUse = "IDEL" + fromDate.ToString("MM") + fromDate.ToString("yy");
            string cmdString = "SELECT BILL_NO, REF_NO, QUANTY, PRICE_PAID, RAW_PRICE, ORD_TIME, SEND_TIME FROM " + tableToUse +
                " WHERE BILL_NO IN (" + billNos + ")";
            DataTable tempdetails = new DataTable();

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmdString, SettingsProperties.connectionString))
            {
                da.Fill(tempdetails);
                da.Dispose();
            }

            return tempdetails;
        }
        #endregion

        #region "Load Details"
        public static string loadSessNos()
        {
            string temp = "";
            foreach (DataRow dr in SettingsProperties.rep.Rows)
            {

                temp = temp + dr["SESSION_NO"].ToString() + ",";
            }

            temp = temp.Remove(temp.Length - 1);

            return temp;
        }

        public static string loadBillNos()
        {
            string temp = "";
            foreach (DataRow dr in SettingsProperties.sls.Rows)
            {
                temp = temp + dr["BILL_NO"].ToString() + ",";
            }

            temp = temp.Remove(temp.Length - 1);

            return temp;
        }
        #endregion

        #region "GET DETAILS"
        public static string getFoodData(string refNo)
        {
            double tempQty = 0;
            double tempAmt = 0;
            double tempGrossAmt = 0;
            double rawPriceList = 0;

            DataRow[] dRows = SettingsProperties.sdet.Select("REF_NO = " + refNo);

            foreach (DataRow dr in dRows)
            {
                double pricePaid = Convert.ToDouble(dr["PRICE_PAID"].ToString());
                double rawPrice = Convert.ToDouble(dr["RAW_PRICE"].ToString());
                double qty = Convert.ToDouble(dr["QUANTY"].ToString());
                tempQty = tempQty + qty;
                tempAmt = tempAmt + (pricePaid * qty);
                tempGrossAmt = tempGrossAmt + (rawPrice * qty);
                rawPriceList = rawPrice;
            }

            return tempAmt.ToString() + "," + tempQty.ToString() + "," + tempGrossAmt.ToString() + "," + rawPriceList.ToString();
        }

        public static string getFoodDataRevCent(string refNo, string revCent)
        {
            double tempQty = 0;
            double tempAmt = 0;
            double tempGrossAmt = 0;
            double rawPriceList = 0;

            DataRow[] dRows = SettingsProperties.sdet.Select("REF_NO = " + refNo);

            foreach (DataRow dr in dRows)
            {
                DataRow[] dRows2 = SettingsProperties.sls.Select("BILL_NO = " + dr["BILL_NO"].ToString());

                if (dRows2.Length != 0 && dRows2[0]["REV_CENTER"].ToString() == revCent)
                {
                    double pricePaid = Convert.ToDouble(dr["PRICE_PAID"].ToString());
                    double rawPrice = Convert.ToDouble(dr["RAW_PRICE"].ToString());
                    double qty = Convert.ToDouble(dr["QUANTY"].ToString());
                    tempQty = tempQty + qty;
                    tempAmt = tempAmt + (pricePaid * qty);
                    tempGrossAmt = tempGrossAmt + (rawPrice * qty);
                    rawPriceList = rawPrice;
                }
            }

            return tempAmt.ToString() + "," + tempQty.ToString() + "," + tempGrossAmt.ToString() + "," + rawPriceList.ToString();
        }

        public static string getSalesData(string billNo)
        {
            string revCentName = "";
            string empName = "";
            DataRow[] dRows = SettingsProperties.sls.Select("BILL_NO = " + billNo);

            if (dRows.Length != 0)
            {
                revCentName = getRevCent(dRows[0]["REV_CENTER"].ToString());
                empName = getEmpName(dRows[0]["WAITER"].ToString());

            }

            return revCentName + "," + empName;
        }

        public static string getPaymentData(string billNo)
        {
            double total = 0.00;
            string payment = "CASH";

            DataRow[] dRows = SettingsProperties.payments.Select("BILL_NO = " + billNo);

            foreach (DataRow dr in dRows)
            {
                total = total + Convert.ToDouble(dr["BASE_AMT"].ToString());
                payment = getPayName(dr["PAY_TYPE"].ToString());
            }

            return total.ToString() + "," + payment;

        }

        public static string getPayName(string payTypeNo)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            DataRow[] dRow = SettingsProperties.tipopag.Select("TPAGO_NO = '" + payTypeNo + "'");
            return textInfo.ToTitleCase(dRow[0]["TPAGO_NAME"].ToString().ToLower());
        }

        public static string getRevCent(string revCent)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            DataRow[] dRow = SettingsProperties.revCent.Select("REV_CENTER = '" + revCent + "'");
            return textInfo.ToTitleCase(dRow[0]["RC_NAME"].ToString().ToLower());
        }

        public static string getEmpName(string empNo)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            DataRow[] dRow = SettingsProperties.emp.Select("EMP_NO = '" + empNo + "'");
            return textInfo.ToTitleCase(dRow[0]["EMP_NAME"].ToString().ToLower());
        }

        public static string getBarcode(string refNo)
        {
            string barcode = "";
            string name = "";
            DataRow[] dRow = SettingsProperties.menu.Select("REF_NO = '" + refNo + "'");

            if (dRow.Length != 0)
            {
                barcode = dRow[0]["BAR_CODE"].ToString().ToLower();
                name = dRow[0]["DESCRIPT"].ToString().ToLower();
            }
            return barcode + "," + name;

        }
        #endregion
    }
}
