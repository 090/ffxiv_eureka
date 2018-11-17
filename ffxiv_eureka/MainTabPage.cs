using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace ffxiv_eureka
{
    public partial class MainTabPage : UserControl
    {
        EurekaPlugin eurekaPlugin;
        public MainTabPage(EurekaPlugin parent)
        {
            InitializeComponent();
            eurekaPlugin = parent;
            eurekaPlugin.XmlSettings.AddControlSetting("YamlFolder", textBox_yamlfolder);
            textBox_yamlfolder.Text = eurekaPlugin.YamlFolder;
        }

        private void button_folder_Click(object sender, EventArgs e)
        {
            var tmp = textBox_yamlfolder.Text;
            if(tmp == "")
            {
                tmp = System.IO.Directory.GetCurrentDirectory();
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = tmp;
            if (fbd.ShowDialog() == DialogResult.OK)
                textBox_yamlfolder.Text = fbd.SelectedPath;
        }

        private void textBox_yamlfolder_TextChanged(object sender, EventArgs e)
        {
            eurekaPlugin.YamlFolder = textBox_yamlfolder.Text;
        }
    }
}
