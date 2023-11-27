using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RM___SAP_Connector
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = SettingsProperties.autoGenTime;
            autoGenCheckBox.Checked = SettingsProperties.isAutoGen;
            sourceTextBox.Text = SettingsProperties.sourceFolder;
            destTextBox.Text = SettingsProperties.destFolder;
            branchCodeTextBox.Text = SettingsProperties.branchCode;
            warehouseCodeTextBox.Text = SettingsProperties.warehouseCode;
            prefixTextBox.Text = SettingsProperties.prefix;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            sourceTextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            destTextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save changes?", "Save?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @sourceTextBox.Text + "\\; Extended Properties=dBase III";

                SettingsProperties.saveSettings(sourceTextBox.Text, conStr, autoGenCheckBox.Checked, dateTimePicker1.Value.ToShortTimeString(), destTextBox.Text, branchCodeTextBox.Text, warehouseCodeTextBox.Text, prefixTextBox.Text);
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
