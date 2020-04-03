/*
  HighDensityPasswordExporter - A KeePass plugin for generating 
  near-raw serializations of KeePass data structures designed for
  printing/archival.

  Copyright (C) 2003-2019 Dominik Reichl <dominik.reichl@t-online.de>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/


using KeePass.Plugins;

namespace HighDensityPasswordExporter
{
	// Namespace name 'SamplePlugin' + 'Ext' = 'SamplePluginExt'
	public sealed class HighDensityPasswordExporterExt : Plugin
	{

		
		public override bool Initialize(IPluginHost host)
		{
			if(host == null) return false; // Fail; we need the host

			host.FileFormatPool.Add(new MarkdownJSONFormatProvider());

			return true; // Initialization successful
		}

		
	}
}
