namespace CC.Common.JSON.Demo
{
  partial class frmMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.btnDefaults = new System.Windows.Forms.Button();
      this.txtPages = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(12, 12);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(80, 17);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // dateTimePicker1
      // 
      this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dateTimePicker1.Location = new System.Drawing.Point(12, 35);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new System.Drawing.Size(273, 20);
      this.dateTimePicker1.TabIndex = 1;
      this.dateTimePicker1.Value = new System.DateTime(2014, 2, 28, 0, 0, 0, 0);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(12, 61);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(273, 20);
      this.textBox1.TabIndex = 2;
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(12, 87);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(273, 20);
      this.numericUpDown1.TabIndex = 3;
      // 
      // btnDefaults
      // 
      this.btnDefaults.Location = new System.Drawing.Point(12, 217);
      this.btnDefaults.Name = "btnDefaults";
      this.btnDefaults.Size = new System.Drawing.Size(75, 23);
      this.btnDefaults.TabIndex = 4;
      this.btnDefaults.Text = "Defaults";
      this.btnDefaults.UseVisualStyleBackColor = true;
      this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
      // 
      // txtPages
      // 
      this.txtPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPages.Location = new System.Drawing.Point(11, 113);
      this.txtPages.Multiline = true;
      this.txtPages.Name = "txtPages";
      this.txtPages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtPages.Size = new System.Drawing.Size(274, 98);
      this.txtPages.TabIndex = 9;
      this.txtPages.Text = resources.GetString("txtPages.Text");
      this.txtPages.WordWrap = false;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(298, 252);
      this.Controls.Add(this.txtPages);
      this.Controls.Add(this.btnDefaults);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.dateTimePicker1);
      this.Controls.Add(this.checkBox1);
      this.Name = "frmMain";
      this.Text = "CC.Common.JSON Test";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Button btnDefaults;
    private System.Windows.Forms.TextBox txtPages;
  }
}

