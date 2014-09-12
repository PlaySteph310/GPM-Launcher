using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://vote1.gpm-server.de");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://vote2.gpm-server.de");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("http://vote3.gpm-server.de");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("http://vote4.gpm-server.de");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://map.gpm-server.de");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://stats.gpm-server.de");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://ban.gpm-server.de");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(ParsePath(@"%localappdata%\\gpm.txt"), Encoding.UTF8))
                {
                    // liest von der aktuellen Position im StreamReader bis zum Ende der Datei ein
                    //this.txtContent.Text = sr.ReadToEnd();
                    string start = sr.ReadToEnd();
                    //MessageBox.Show(start);
                    Process.Start(@"" + start + "");
                    Application.Exit();
                }
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Ich kann die Datei nicht finden :/");
            }
        }
        static public string ParsePath(string path)
        {
            var newPath = new StringBuilder();
            var folders = path.Split(Path.DirectorySeparatorChar);
            foreach (var folder in folders) newPath.Append((Regex.IsMatch(folder, "%.+%")) ? Environment.GetEnvironmentVariable(Regex.Match(folder, "(?:%)(.+)(?:%)").Groups[1].Value) : folder).Append((folders[folders.Length - 1] == folder) ? string.Empty : new string(Path.DirectorySeparatorChar, 1));
            return newPath.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var x = new Form2();
            x.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://map.gpm-server.de");
            this.StartPosition = FormStartPosition.CenterScreen;
            if (File.Exists(ParsePath("%localappdata%\\gpm.txt")))
            {
            }

            else
            {

                Hide();
                var x = new Form2();
                x.Show();
            }
        }
    }
}
