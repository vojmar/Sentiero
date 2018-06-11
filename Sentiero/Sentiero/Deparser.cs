using System;
using System.Linq;

namespace Sentiero
{
    internal class Deparser
    {
        private string argument;

        public Deparser(string argument)
        {
            this.argument = argument;
        }

        internal void RemoveProtocol(string protocolName)
        {
            if (argument.StartsWith(protocolName + ":"))
            {
                argument = argument.Remove(0,protocolName.Length+1);
            }
        }

        internal string GetCallName()
        {
            return argument.Split('|')[0];
        }

        internal string[] GetArgs()
        {
            string[] args = argument.Split('|');
            if (args.Length > 1)
            {
                return args.Skip(1).ToArray();
            }
            else 
            {
                return null;
            }
        }
    }
}