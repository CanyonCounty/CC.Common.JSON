using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CC.Common.JSON
{
  public static class HashtableEx
  {
    internal static readonly object sync = new object();

    public static object ParseObject(this Hashtable ht, string key, object defaultValue)
    {
      object ret;
      if (ht.ContainsKey(key))
        ret = ht[key];
      else
        ret = defaultValue;
      return ret;
    }

    public static object ParseObject(this Hashtable ht, string key)
    {
      return ParseObject(ht, key, null);
    }

    public static String ParseString(this Hashtable ht, string key, string defaultValue)
    {
      string ret;
      if (ht.ContainsKey(key))
        ret = ht[key].ToString();
      else
        ret = defaultValue;
      return ret;
    }

    public static String ParseString(this Hashtable ht, string key)
    {
      return ParseString(ht, key, String.Empty);
    }

    public static DateTime ParseDate(this Hashtable ht, string key, DateTime defaultValue)
    {
      DateTime ret = defaultValue;
      if (ht.ContainsKey(key))
        try
        {
          //DateTime dt = new DateTime();
          ret = DateTimeEx.ParseUnixTimestamp(Double.Parse(ht[key].ToString()));
        }
        catch { }
      return ret;
    }

    public static DateTime ParseDate(this Hashtable ht, string key)
    {
      return ParseDate(ht, key, DateTime.Now);
    }

    public static Guid ParseGuid(this Hashtable ht, string key, Guid defaultValue)
    {
      Guid ret = defaultValue;
      if (ht.ContainsKey(key))
        ret = new Guid(ht[key].ToString());
      return ret;
    }

    public static Guid ParseGuid(this Hashtable ht, string key)
    {
      return ParseGuid(ht, key, Guid.NewGuid());
    }

    public static Double ParseDouble(this Hashtable ht, string key, double defaultValue)
    {
      Double ret = defaultValue;
      if (ht.ContainsKey(key))
        try
        {
          ret = Double.Parse(ht[key].ToString());
        }
        catch { }
      return ret;
    }

    public static Double ParseDouble(this Hashtable ht, string key)
    {
      return ParseDouble(ht, key, 0f);
    }

    public static int ParseInt(this Hashtable ht, string key, int defaultValue)
    {
      int ret = defaultValue;
      if (ht.ContainsKey(key))
        try
        {
          ret = Int32.Parse(ht[key].ToString());
        }
        catch { }
      return ret;
    }

    public static int ParseInt(this Hashtable ht, string key)
    {
      return ParseInt(ht, key, 0);
    }

    public static Int64 ParseInt64(this Hashtable ht, string key, Int64 defaultValue)
    {
      Int64 ret = defaultValue;
      if (ht.ContainsKey(key))
        try
        {
          ret = Int64.Parse(ht[key].ToString());
        }
        catch { }
      return ret;
    }

    public static Int64 ParseInt64(this Hashtable ht, string key)
    {
      return ParseInt64(ht, key, 0);
    }

    // True = 1, False = 0 (non 1?)
    public static Boolean ParseBoolean(this Hashtable ht, string key, Boolean defaultValue)
    {
      Boolean ret = defaultValue;
      if (ht.ContainsKey(key))
        try
        {
          ret = Boolean.Parse(ht[key].ToString());
        }
        catch
        {
          try
          {
            //ret = Int32.Parse(ht[key].ToString()) != 0;
            ret = ParseInt(ht, key) != 0;
          }
          catch { }
        }
      return ret;
    }

    public static Boolean ParseBoolean(this Hashtable ht, string key)
    {
      return ParseBoolean(ht, key, false);
    }

  }
}
