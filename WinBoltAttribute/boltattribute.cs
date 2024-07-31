#pragma reference "Tekla.Macros.Runtime"
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Tekla.Technology.Akit;

namespace Tekla.Technology.Akit.UserScript
{
    public class Script {
        [Tekla.Macros.Runtime.MacroEntryPointAttribute()]
        public static void Run(Tekla.Macros.Runtime.IMacroRuntime runtime) {
            string applicationName = "WinBoltAttribute.exe";
            string applicationFolder1 = @"C:\TeklaStructures\2024.0\Environments\common\macros\modeling";
            string applicationFolder2 = @"C:\ProgramData\Trimble\TeklaStructures\2024.0\Environments\common\macros\modeling";
            string applicationFile1 = Path.Combine(applicationFolder1, applicationName);
            string applicationFile2 = Path.Combine(applicationFolder2, applicationName);

            if (File.Exists(applicationFile1)) {
                Process.Start(applicationFile1);
            }
            else if (File.Exists(applicationFile1))
            {
                Process.Start(applicationFile2);
            }
            else
            {
				MessageBox.Show("Application file doesn't exist.");
			}
		}
	}
}
