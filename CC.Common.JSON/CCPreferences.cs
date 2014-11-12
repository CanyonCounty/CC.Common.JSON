using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace CC.Common.JSON
{
  public class CCPreferences: IEnumerable
  {
    internal string _fileName;
    internal Hashtable ht;
    internal Hashtable defaults;
    internal readonly object sync = new object();

    private string FileNameOrDefault(string file)
    {
      if (file.Equals("__default__"))
      {
        // Change Environment.SpecialFolder.ApplicationData to Environment.SpecialFolder.LocalApplicationData
        // If you don't want the settings in "Roaming"
        file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar
        + Application.CompanyName + Path.DirectorySeparatorChar
          //+ Application.ProductName + Path.DirectorySeparatorChar
        + Application.ProductName + ".json";
      }
      return file;
    }

    public bool Load(string file = "__default__")
    {
      _fileName = FileNameOrDefault(file);
      if (File.Exists(_fileName))
      {
        using (StreamReader sr = new StreamReader(_fileName))
        {
          string data = sr.ReadToEnd();
          ht = (Hashtable)JSON.JsonDecode(data);
        }
      }
      return ht != null;
    }

    public void Save(string file = "__default__")
    {
      if (IsDirty)
      {
        _fileName = FileNameOrDefault(file);

        Hashtable n = new Hashtable();
        foreach (DictionaryEntry e in ht)
        {
          if (!IsDefault((string)e.Key))
          {
            n.Add(e.Key, e.Value);
          }
        }
        string data = JSON.JsonEncode(n);
        Directory.CreateDirectory(Path.GetDirectoryName(_fileName));
        using (StreamWriter sw = new StreamWriter(_fileName))
        {
          sw.Write(data);
          sw.Flush();
          sw.Close();
        }
      }
    }

    public string FileName
    {
      get { return _fileName; }
    }

    public CCPreferences()
    {
      ht = new Hashtable();
      defaults = new Hashtable();
      //Load(); // <-- NEVER DO THIS!
    }

    public bool IsDirty
    {
      get
      {
        bool ret = false;
        foreach (DictionaryEntry e in ht)
        {
          if (!IsDefault((string)e.Key))
          {
            ret = true;
            break;
          }
        }
        return ret;      
      }
    }

    public bool IsDefault(string key)
    {
      bool ret = false;
      if (defaults.ContainsKey(key))
        ret = (ht[key].ToString() == defaults[key].ToString());
      return ret;
    }

    public bool ContainsKey(string key)
    {
      return ht.ContainsKey(key);
    }

    public void ResetToDefaults()
    {
      foreach (DictionaryEntry e in defaults)
      {
        ht[e.Key] = e.Value;
      }
    }

    #region Base Methods
    private void _set(string key, object value)
    {
      lock (sync)
      {
        if (ht.ContainsKey(key))
        {
          if (ht[key] != value)
          {
            ht[key] = value;
          }
        }
        else
        {
          if (value != defaults[key])
          {
            ht[key] = value;
          }
        }
      }
    }

    private object _get(string key, object defaultValue)
    {
      lock (sync)
      {
        if (defaultValue is DateTime)
          defaults[key] = DateTimeEx.ToUnixTimestamp((DateTime)defaultValue);
        else
          defaults[key] = defaultValue;

        if (ht.ContainsKey(key))
          return ht[key];
        else
        {
          //if (defaultValue != null && (!String.IsNullOrEmpty(defaultValue.ToString())))
          //{
          //  //defaults.Add(key, defaultValue);
          //  //_dirty = false;
          //}
          return defaultValue;
        }
      }
    }
    #endregion

    #region Objects
    public void Set(string key, object value)
    {
      _set(key, value);
    }
    public object Get(string key, object defaultValue)
    {
      return _get(key, defaultValue);
    }
    #endregion

    #region Integers
    public void Set(string key, int value)
    {
      _set(key, value);
    }
    public int Get(string key, int defaultValue)
    {
      int ret = defaultValue;
      try
      {
        object temp = _get(key, defaultValue);
        ret = Int32.Parse(temp.ToString());
      }
      catch (Exception e) { throw e; }
      return ret;
    }
    #endregion

    #region Strings
    public void Set(string key, string value)
    {
      _set(key, value);
    }
    public string Get(string key, string defaultValue)
    {
      string ret = defaultValue;
      try
      {
        ret = _get(key, defaultValue).ToString(); // <<<---- May want to remove this
      }
      catch { }
      return ret;
    }
    #endregion

    #region Floats
    public void Set(string key, double value)
    {
      //_items[name] = item;
      _set(key, value);
    }
    public double Get(string key, double defaultValue)
    {
      double ret = defaultValue;
      try
      {
        ret = (double)_get(key, defaultValue);
      }
      catch { }
      return ret;
    }
    #endregion

    #region DateTimes
    public void Set(string key, DateTime value)
    {
      _set(key, DateTimeEx.ToUnixTimestamp(value));
    }
    
    public DateTime Get(string key, DateTime defaultValue)
    {
      DateTime ret = defaultValue;
      try
      {
        object temp = Get(key, (object)defaultValue);
        if (temp is DateTime)
          ret = (DateTime)temp;
        else
          ret = DateTimeEx.ParseUnixTimestamp((double)temp);
      }
      catch { }
      return ret;
    }
    #endregion

    #region Booleans
    public void Set(string key, Boolean value)
    {
      _set(key, value);
    }
    public Boolean Get(string key, Boolean defaultValue)
    {
      Boolean ret = defaultValue;
      try
      {
        ret = (Boolean)_get(key, defaultValue);
      }
      catch { }
      return ret;
    }
    #endregion

    #region Size
    public void Set(string key, Size value)
    {
      _set(key, String.Format("[{0}, {1}]", value.Width, value.Height));
    }
    public Size Get(string key, Size defaultValue)
    {
      Size ret = defaultValue;
      try
      {
        string temp = _get(key, String.Format("[{0}, {1}]", defaultValue.Width, defaultValue.Height)).ToString();
        string[] data = temp.Replace("[", "").Replace("]", "").Split(',');
        int width;
        int height;
        Int32.TryParse(data[0].Trim(), out width);
        Int32.TryParse(data[1].Trim(), out height);
        ret = new Size(width, height);
      }
      catch { }
      return ret;
    }
    #endregion

    #region Point
    public void Set(string key, Point value)
    {
      _set(key, String.Format("[{0}, {1}]", value.X, value.Y));
    }
    public Point Get(string key, Point defaultValue)
    {
      Point ret = defaultValue;
      try
      {
        string temp = _get(key, String.Format("[{0}, {1}]", defaultValue.X, defaultValue.Y)).ToString();
        string[] data = temp.Replace("[", "").Replace("]", "").Split(',');
        int x;
        int y;
        Int32.TryParse(data[0].Trim(), out x);
        Int32.TryParse(data[1].Trim(), out y);
        ret = new Point(x, y);
      }
      catch { }
      return ret;
    }
    #endregion

    #region Methods
    public void Remove(string key)
    {
      ht.Remove(key);
    }

    public void Clear()
    {
      ht.Clear();
    }
    #endregion
  
    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ht.GetEnumerator();
    }

    #endregion

  }
}
