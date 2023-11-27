using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RM___SAP_Connector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TimeSpan intervalTime = (SettingsProperties.autoGenTime.AddSeconds(30)) - DateTime.Now;
        public static int i = 1;

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day;
        }

        private void refreshForm()
        {
            SettingsProperties.getSettings();
            if (SettingsProperties.isAutoGen == true)
            {
                isAutoGenLabel.Text = "Auto Generation: ON";
                isAutoGenLabel.BackColor = Color.Green;
                startButton.Enabled = true;
                generatelButton.Enabled = false;
                groupBox1.Enabled = false;
                selectDatesCheckBox.Enabled = false;
                timer1.Start();
            }
            else
            {
                isAutoGenLabel.Text = "Auto Generation: OFF";
                isAutoGenLabel.BackColor = Color.Red;
                startButton.Enabled = false;
                stopButton.Enabled = false;
                generatelButton.Enabled = true;
                groupBox1.Enabled = true;
                selectDatesCheckBox.Enabled = true;
                timer1.Enabled = false;
            }
        }

        private void generateReport(DateTime day)
        {
            SettingsProperties.initializeTablesPerDay(day, day);
            if (SettingsProperties.rep.Rows.Count == 0)
            {
                return;
            }
            SettingsProperties.dataTable = Queries.loadSalesTable(day);
            Utilities.exportToCSV(SettingsProperties.dataTable, SettingsProperties.destFolder, day, "PRODUCTSALES", SettingsProperties.warehouseCode);

            SettingsProperties.dataTable.Dispose();

            SettingsProperties.dataTable = Queries.loadFinanceTable(day);
            Utilities.exportToCSV(SettingsProperties.dataTable, SettingsProperties.destFolder, day, "PAYMENTS", SettingsProperties.warehouseCode);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory + "\\Settings.json") == false)
            {
                SettingsProperties.createDefaultJSON();
            }

            refreshForm();

            if (!Directory.Exists(Environment.CurrentDirectory + "\\Log"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Log");
            }
        }

        private void generatelButton_Click(object sender, EventArgs e)
        {
            SettingsProperties.initializeTables();
            foreach (DateTime day in EachDay(fromDateTimePicker.Value, toDateTimePicker.Value))
            {
                generateReport(day);
            }

            //SettingsProperties.initializeTables();
            //DateTime nowDate = DateTime.Now;
            //DateTime from = fromDateTimePicker.Value;
            //DateTime to = toDateTimePicker.Value;
            //generateReportMonthly(from, to);
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setup setupForm = new Setup();
            setupForm.ShowDialog();
            refreshForm();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            intervalTime = (SettingsProperties.autoGenTime.AddDays(i)) - DateTime.Now;

            timeLabel.Text = intervalTime.Hours + ":" + intervalTime.Minutes + ":" + intervalTime.Seconds;
            if (intervalTime.ToString("hh\\:mm\\:ss") == TimeSpan.Zero.ToString("hh\\:mm\\:ss"))
            {
                //this.WindowState = FormWindowState.Minimized;

                timer1.Enabled = false;

                SettingsProperties.initializeTables();

                generateReport(DateTime.Now.AddDays(-1));

                i = i + 1;
                timer1.Start();

                this.WindowState = FormWindowState.Normal;
            }
        }

        private void generateReportMonthly(DateTime fromDate, DateTime toDate)
        {
            while (fromDate < toDate)
            {
                SettingsProperties.initializeTablesPerDay(fromDate, fromDate.AddMonths(1));
                if (SettingsProperties.rep.Rows.Count == 0)
                {
                    return;
                }
                SettingsProperties.dataTable = Queries.loadSalesTable(fromDate);
                Utilities.exportToCSV(SettingsProperties.dataTable, SettingsProperties.destFolder, fromDate, "PRODUCTSALES", SettingsProperties.warehouseCode);

                SettingsProperties.dataTable.Dispose();

                //SettingsProperties.dataTable = Queries.loadFinanceTable(fromDate);
                //Utilities.exportToCSV(SettingsProperties.dataTable, SettingsProperties.destFolder, fromDate, "PAYMENTS");

                fromDate = fromDate.AddMonths(1);
            }
            
        }
    }
}
