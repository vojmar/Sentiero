using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentiero
{
    static class Program
    {
        [STAThread]
        static void Main(string[] Args)
        {
            string Argument = string.Join(" ",Args);
            Deparser deparser = new Deparser(Argument);
            deparser.RemoveProtocol(Glovar.ProtocolName);
            string callName = deparser.GetCallName();
            string[] newArgs = deparser.GetArgs();
            Execute(callName,newArgs);
        }

        private static void Execute(string callName, string[] Args)
        {
            if (callName == string.Empty)
                return;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = callName;
            p.StartInfo.UseShellExecute = false;
            if (Args != null)
            {
                p.StartInfo.Arguments = "\"" + string.Join("\" \"", Args) + "\"";
            }
            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Sentiero core error");
            }
        }
    }
}
