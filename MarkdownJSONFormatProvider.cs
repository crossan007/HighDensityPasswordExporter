using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeePass.DataExchange;
using KeePassLib;
using KeePassLib.Interfaces;
using System.IO;

namespace HighDensityPasswordExporter
{
    class MarkdownJSONFormatProvider : FileFormatProvider
    {
        public override bool SupportsImport
        {
            get { return false; }
        }
        public override bool SupportsExport
        {
            get { return true; }
        }

        public override string FormatName
        {
            get { return "Markdownified JSON backup"; }
        }
        public override string DefaultExtension
        {
            get { return "md"; }
        }



        public override bool Export(PwExportInfo pwExportInfo, Stream sOutput, IStatusLogger slLogger)
        {

            slLogger.SetText("Collecting entries...", LogStatusType.Info);

            var entries = ConvertGroup(pwExportInfo.DataGroup, slLogger);

            slLogger.SetText("Encrypting backup...", LogStatusType.Info);

            var filewriter = new StreamWriter(sOutput);

            filewriter.Write(entries);
            filewriter.Flush();

            return true;
        }


        private string ConvertGroup(PwGroup pwGroup, IStatusLogger slLogger)
        {
            var mdP = new MarkdownifiedJSONPasswordGroup(pwGroup, 1);

            return mdP.GetMarkdown();
        }

    }
}
