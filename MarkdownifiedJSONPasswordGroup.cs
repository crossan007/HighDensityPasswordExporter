using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeePass.DataExchange;
using KeePassLib;
using KeePassLib.Interfaces;
using Newtonsoft.Json;

namespace HighDensityPasswordExporter
{
    class MarkdownifiedJSONPasswordGroup
    {

        private PwGroup pwGroup;
        int headingDepth;
        public MarkdownifiedJSONPasswordGroup(PwGroup pwGroup, int headingDepth)
        {
            this.pwGroup = pwGroup;
            this.headingDepth = headingDepth;
        }

        private string GetMarkdownHeadingHashes()
        {
            var hashes = "";
            for (var i=0;i<headingDepth;i++)
            {
                hashes += "#";
            }
            return hashes;
        }

        private string GetJSONIfiedPasswordBlock()
        {
            var pwBlock = "```";


            var entries = new List<ExportableEntry>();
            
            foreach (var pwEntry in pwGroup.Entries)
            {
                entries.Add(new ExportableEntry(pwEntry));
            }

            pwBlock += JsonConvert.SerializeObject(entries);

            pwBlock += "```";
            return pwBlock;


        }

        public string GetMarkdown()
        {

            var groupMarkdown = "";

            groupMarkdown += this.GetMarkdownHeadingHashes() + " " + this.pwGroup.Name+"\n";

            groupMarkdown += this.GetJSONIfiedPasswordBlock() + "\n";

            try
            {

                foreach (var pwSubGroup in pwGroup.Groups)
                {
                    groupMarkdown += new MarkdownifiedJSONPasswordGroup(pwSubGroup, this.headingDepth + 1).GetMarkdown() ;
                }
            }
            catch (Exception e)
            {
                groupMarkdown += "Couldn't create group markdown: " + e.ToString();
            }
            return groupMarkdown;

            
        }
    }
}
