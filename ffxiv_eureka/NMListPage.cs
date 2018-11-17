using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using YamlDotNet.Core;

namespace ffxiv_eureka
{
    public partial class NMListPage : UserControl
    {
        EurekaPlugin eurekaPlugin;
        public NMListPage(EurekaPlugin parent)
        {
            InitializeComponent();
            eurekaPlugin = parent;
            foreach (var lang in Enum.GetNames(typeof(Lang))) {
                cbLang.Items.Add(lang);
            }
            eurekaPlugin.XmlSettings.AddControlSetting("Lang", cbLang);
            eurekaPlugin.XmlSettings.AddControlSetting("Yaml", cbYamlFile);
            cbYamlFile.MouseWheel += new System.Windows.Forms.MouseEventHandler(cbYamlFile_MouseWheel);
        }

        private void cbYamlFile_DropDown(object sender, EventArgs e)
        {
            var tmp = cbYamlFile.Text;
            cbYamlFile.Items.Clear();
            cbYamlFile.Items.Add("");
            try
            {
                string[] files = Directory.GetFiles(eurekaPlugin.YamlFolder, "*.yaml", SearchOption.TopDirectoryOnly);
                cbYamlFile.Items.AddRange(files.Select(f => Path.GetFileName(f)).ToArray());
            }
            catch
            {

            }
            cbYamlFile.Text = tmp;
        }


        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            YamlNMList.Lang = (Lang)cbLang.SelectedIndex;
            var nmlist = eurekaPlugin.NMList;
            if (nmlist == null || nmlist.List == null)
                return;
            foreach (var nm in nmlist.List)
            {
                if (nm.Item == null)
                    continue;
                nm.Item.SubItems[1].Text = nm.Name();
            }
            ViewWeather();
        }

        private void cbYamlFile_TextChanged(object sender, EventArgs e)
        {
            if (eurekaPlugin.YamlFile != cbYamlFile.Text)
            {
                if (cbYamlFile.DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    if (cbYamlFile.Text != "")
                    {
                        eurekaPlugin.YamlFile = cbYamlFile.Text;
                        cbYamlFile.Items.Add(cbYamlFile.Text);
                        cbYamlFile.SelectedIndex = 0;
                        load_yaml();
                    }
                }
            }
        }

        private void cbYamlFile_MouseWheel(object sender, EventArgs e)
        {
            var eventArgs = e as HandledMouseEventArgs;
            eventArgs.Handled = true;
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            eurekaPlugin.YamlFile = cbYamlFile.Text;
            load_yaml();
        }
        public void LoadYaml(string yaml)
        {
            if (cbYamlFile.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () {
                    cbYamlFile.Text = yaml;
                    load_yaml();
                });
            }
            else
            {
                cbYamlFile.Text = yaml;
                load_yaml();
            }
        }

        private void load_yaml()
        {
            timer1.Stop();
            listView_NM.Items.Clear();
            comboBox_export.Items.Clear();
            try
            {
                if (eurekaPlugin.LoadYaml())
                {
                    var nmlist = eurekaPlugin.NMList;
                    if (nmlist == null || nmlist.List == null)
                        return;
                    foreach (var nm in nmlist.List)
                    {
                        var i = new ListViewItem(nm.Lv.ToString());
                        i.SubItems.Add(nm.Name());
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        listView_NM.Items.Add(i);
                        nm.Item = i;
                    }
                    if (nmlist.Export == null)
                    {
                        var ex = new YamlExport();
                        ex.Text = "<Name> (<RepopMin>)";
                        ex.Join = " > ";
                        nmlist.Export = new List<YamlExport>();
                        nmlist.Export.Add(ex);
                    }
                    comboBox_export.Items.AddRange(nmlist.Export.Select(x=>x.Text).ToArray());
                    timer1.Start();
                    listView_NM.Columns[0].Width = -1;
                    listView_NM.Columns[1].Width = -1;
                    ViewWeather();
                }
            }
            catch (YamlException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var nmlist = eurekaPlugin.NMList;
            if (nmlist == null || nmlist.List == null)
                return;
            DateTime datetime_now = DateTime.Now;
            var refresh = nmlist.Refresh;
            foreach (var nm in nmlist.List)
            {
                if(nm.PopTime != DateTime.MinValue)
                {
                    var poptime = "";
                    var repoptime = nm.GetRepop(datetime_now);
                    if (repoptime != "")
                    {
                        if (!nm.Self)
                            repoptime += "?";
                        poptime = nm.PopTime.ToString("HH:mm");
                    }
                    
                    if (nm.Item.SubItems[2].Text != poptime)
                        nm.Item.SubItems[2].Text = poptime;
                    if (nm.Item.SubItems[3].Text != repoptime)
                        nm.Item.SubItems[3].Text = repoptime;
                }
                else if (refresh)
                {
                    if (nm.Item.SubItems[2].Text != "")
                        nm.Item.SubItems[2].Text = "";
                    if (nm.Item.SubItems[3].Text != "")
                        nm.Item.SubItems[3].Text = "";
                }
            }
            if (refresh)
                nmlist.Refresh = false;

        }

        private void button_Import_Click(object sender, EventArgs e)
        {
            var text = textBox_Chat.Text;
            eurekaPlugin.ImportNM(text);

        }

        private void button_Paste_Click(object sender, EventArgs e)
        {
            textBox_Chat.Text = Clipboard.GetText();
        }

        private void button_Copy_Click(object sender, EventArgs e)
        {
            var txt = textBox_Chat.Text;
            if (txt == null || txt == "")
                Clipboard.Clear();
            else
                Clipboard.SetText(txt);
            
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            var nmlist = eurekaPlugin.NMList;
            if (nmlist == null || nmlist.List == null)
                return;

            string text = "";
            var q = nmlist.List.AsEnumerable();
            if (!checkBox_Full.Checked)
                q = q.Where(x => x.RepopTime != DateTime.MinValue);
            if (!checkBox_LvSort.Checked)
                q = q.OrderBy(x => ( x.PopTime == DateTime.MinValue ? DateTime.MaxValue : x.RepopTime));
            var i  = nmlist.Export.FindIndex(x => x.Text.Contains(comboBox_export.Text));
            if (i < 0)
                i = 0;
            var ex = nmlist.Export[i];

            text = string.Join(ex.Join, q.Select(x=> x.GetExport(ex)));
            if (text != "")
            {
                if (checkBox_Sh.Checked)
                    text = "/sh " + text;
            }
            if (ex.Text.IndexOf("<PopTime>") >= 0)
            {
                var tzi = TimeZoneInfo.Local.BaseUtcOffset;
                if (tzi != eurekaPlugin.DefaultTimezone)
                {
                    var timezoneText = " (GMT";
                    timezoneText += tzi.TotalMinutes > 0 ? "+" : "-";
                    timezoneText += tzi.ToString(@"%h");
                    if (tzi.TotalMinutes % 60 != 0)
                        timezoneText += tzi.ToString(@"\:mm");
                    timezoneText += ")";
                    text += timezoneText;
                }
            }
            textBox_Chat.Text = text;
        }
        public void OnOff(bool onoff)
        {
            if (listView_NM.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () {
                    listView_NM.Enabled = onoff;
                });
            }
            else
            {
                listView_NM.Enabled = onoff;
            }
        }
        private void ViewWeather()
        {
            var nmlist = eurekaPlugin.NMList;
            if (nmlist == null|| nmlist.Weather == null)
                return;
            var w = nmlist.Weather;
            var et = new EorzeaTime(DateTime.Now);
            var lt = new EorzeaTime(DateTime.Now);
            et.Add(-2*60*60);
            et.Chop();
            lt.Chop();
            string nowtime = lt.LT();

            listView_Weather.Items.Clear();

            for (int i = 0; i < 24; ++i)
            {
                var str = et.LT();
                var item = new ListViewItem(str);
                if (nowtime == str)
                    item.Selected = true;
                item.SubItems.Add(et.ET());
                item.SubItems.Add(w.Name(et.Calculate()));
                listView_Weather.Items.Add(item);
                et.Add(1400);
            }
            listView_Weather.Columns[0].Width = -1;
            listView_Weather.Columns[1].Width = -1;
            listView_Weather.Columns[2].Width = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewWeather();
        }

        private void cbYamlFile_VisibleChanged(object sender, EventArgs e)
        {
            if (cbYamlFile.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                cbYamlFile.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }

        private void cbLang_VisibleChanged(object sender, EventArgs e)
        {
            if (cbLang.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                cbLang.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}