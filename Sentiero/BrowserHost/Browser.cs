using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserHost
{
    public partial class SentieroBrowserForm : Form
    {
        public SentieroBrowserForm(string Args)
        {
            InitializeComponent();
            webBrowser1.Navigate("Whatismyip.com");
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }
    }
}
