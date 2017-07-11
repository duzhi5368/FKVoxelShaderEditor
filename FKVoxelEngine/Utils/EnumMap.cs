//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    
//-------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class EnumMap<T> : Dictionary<string, T>
    {
        public void Load(string resource)
        {
            TextReader textReader = new StreamReader(resource);
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                int indexEqu = line.IndexOf('=');
                if (indexEqu > 0)
                {
                    string enumName = line.Substring(0, indexEqu);
                    string value = line.Substring(indexEqu + 1, line.Length - indexEqu - 1).Trim();
                    string[] values = Regex.Split(value, @"[\t ]+");
                    T enumValue = (T)Enum.Parse(typeof(T), enumName);
                    foreach (string token in values)
                    {
                        if (!ContainsKey(token))
                        {
                            Add(token, enumValue);
                        }
                        else
                        {
                            Trace.WriteLine(string.Format("警告: token {0} for enum {1} already added for {2}",
                                token, enumValue, this[token]));
                        }
                    }
                }
            }
        }
    }
}
