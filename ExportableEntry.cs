using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeePass.DataExchange;
using KeePassLib;
using KeePassLib.Security;
using KeePassLib.Interfaces;

namespace HighDensityPasswordExporter
{
    class ExportableEntry
    {
        public string Title;
        public Dictionary<string,string> properties;
        public ExportableEntry(PwEntry pwEntry) 
        {
            try
            {
                Title = pwEntry.Strings.Get("Title").ReadString();
            }
            catch
            {
                Title = "";
            }
            
           // var strings = new List<KeyValuePair<string, object>> { kvp };
           //v//ar dictionary = list.ToDictionary(x => x.Key, x => x.Value);
            var strings = new List<KeyValuePair<string, string>>();
            foreach (var s in pwEntry.Strings)
            {
                if (s.Key != "Title")
                {
                    try
                    {
                        strings.Add(new KeyValuePair<string, string>(s.Key, s.Value.ReadString()));
                    }
                    catch (Exception e)
                    {
                        strings.Add(new KeyValuePair<string, string>(s.Key, "PROTECTED"));
                    }
                }
            }
            properties = strings.ToDictionary(x => x.Key, x => x.Value);
        }

    }
}
