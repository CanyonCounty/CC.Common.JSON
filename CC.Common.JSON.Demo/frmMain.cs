using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Common.JSON;

namespace CC.Common.JSON.Demo
{
  public partial class frmMain : Form
  {
    private CCPreferences prefs;
    private double _openCount;

    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      prefs = new CCPreferences();
      LoadPreferences();
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      SavePreferences();
    }

    private void btnDefaults_Click(object sender, EventArgs e)
    {
      prefs.ResetToDefaults();
      LoadPreferences();
    }

    private void LoadPreferences()
    {
      prefs.Load(@"C:\Temp\Test.json");
      checkBox1.Checked = prefs.Get("checkBox", false);
      DateTime now = DateTime.Now;
      dateTimePicker1.Value = prefs.Get("dateTime", new DateTime(now.Year, now.Month, now.Day, 23, 0, 0));
      textBox1.Text = prefs.Get("text", String.Empty);
      numericUpDown1.Value = prefs.Get("integer", 0);
      _openCount = prefs.Get("float", 0.0f);
      Text = _openCount.ToString();
      this.Size = prefs.Get("size", new Size(314, 202));
      this.Location = prefs.Get("location", new Point(0, 0));
    }
    
    private void SavePreferences()
    {
      prefs.Set("checkBox", checkBox1.Checked);
      prefs.Set("dateTime", dateTimePicker1.Value);
      prefs.Set("text", textBox1.Text);
      prefs.Set("integer", numericUpDown1.Value);
      prefs.Set("float", ++_openCount);

      prefs.Set("size", this.Size);
      prefs.Set("location", this.Location);

      prefs.Save(@"C:\Temp\Test.json");
    }
  }
}
