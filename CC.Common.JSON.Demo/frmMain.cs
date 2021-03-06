﻿using System;
using System.Collections;
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
    private string _defaultKeyText = @"Rename 'key_docs' to 'key' and change this text!";
    private string _userKeyText;

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

      this.Size = prefs.Get("size", new Size(314, 290));
      this.Location = prefs.Get("location", new Point(0, 0));

      ArrayList list = new ArrayList();
      String text = String.Empty;
      list = (ArrayList)prefs.Get("pages", (ArrayList)list);
      if (list != null)
      {
        foreach (string line in list)
        {
          text += line + Environment.NewLine;
        }
      }
      txtPages.Text = text;

      if (prefs.ContainsKey("key"))
      {
        _userKeyText = prefs.Get("key", _defaultKeyText);
        if (!_userKeyText.Equals(_defaultKeyText))
        {
          MessageBox.Show("You renamed key!" + Environment.NewLine + _userKeyText);
        }
        else
        {
          MessageBox.Show("You need to change the text");
        }
      }
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

      // New thing
      if (!prefs.ContainsKey("key"))
      {
        prefs.Set("key_docs", _defaultKeyText);
      }
      else
      {
        prefs.Set("key", _userKeyText);
      }

      // ArrayLists seem to be clunky
      string[] lines = txtPages.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
      ArrayList list = new ArrayList(lines);
      prefs.Set("pages", list);

      prefs.Save(@"C:\Temp\Test.json");
    }
  }
}
