using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ffxiv_eureka
{
    public enum Lang { Japanese, English, Deutsch, Français , Chinese, Korean };
    public enum AutoImport { None , Once , Always};

    public class EurekaPlugin : IActPluginV1
    {
        Label lblStatus;

        MainTabPage mainTabPage;
        TabPage tpEureka;
        NMListPage nmlistPage;
        public String dllpath;
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, @"Config\FFXIV_Eureka.config.xml");
        public SettingsSerializer XmlSettings;
        public String YamlFolder="";
        public String YamlFile="";
        
        public volatile YamlNMList NMList;
        public Regex Added;
        public Regex Import;
        public List<Regex> Imports;
        public int TimeStampLen=15;
        public int RequiredLen = 20;
        public AutoImport Autoimport = AutoImport.None;
        string lastZone="";
        bool autoimported=false;
        private bool eurekaZone=false;
        static Regex timezoneRegex = new Regex(@"(?:GMT|UTC)\s*\+?(\-?\d?\d)(?::(\d\d))?");
        public TimeSpan DefaultTimezone = new TimeSpan(9, 0, 0);
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            YamlFolder = Path.Combine(GetPluginDirectory(), "EurekaYaml");

            XmlSettings = new SettingsSerializer(this);
            dllpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            mainTabPage = new MainTabPage(this);
            pluginScreenSpace.Controls.Add(mainTabPage);
            mainTabPage.Dock = DockStyle.Fill;
            lblStatus = pluginStatusText;
            lblStatus.Text = "Plugin Started";
            pluginScreenSpace.Text = "Eureka Settings";

            tpEureka = new TabPage();
            tpEureka.Text = "Eureka";

            nmlistPage = new NMListPage(this);
            tpEureka.Controls.Add(nmlistPage);
            nmlistPage.Dock = DockStyle.Fill;

            ActGlobals.oFormActMain.Controls["tc1"].Controls.Add(tpEureka);
            LoadSettings();
            Start();

        }
        void IActPluginV1.DeInitPlugin()
        {
            if (tpEureka != null)
                ActGlobals.oFormActMain.Controls["tc1"].Controls.Remove(tpEureka);
            SaveSettings();
        }

        private void BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            var nmlist = NMList;
            if (logInfo.detectedZone != lastZone)
            {
                eurekaZone = false;
                autoimported = false;
                lastZone = logInfo.detectedZone;

                var zonefile = lastZone;
                if (zonefile == "Unknown Zone (31B)")
                    zonefile = "The Forbidden Land, Eureka Pyros";
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    zonefile = zonefile.Replace(c, '_');
                }
                string[] zonefiles = Directory.GetFiles(YamlFolder, zonefile + ".yaml", SearchOption.TopDirectoryOnly);
                if(zonefiles.Length > 0)
                {
                    var filename = Path.GetFileName(zonefiles[0]);
                    if (YamlFile != filename)
                    {
                        YamlFile = filename;
                        nmlistPage.LoadYaml(filename);
                        nmlist = NMList;
                    }
                }
                if (nmlist != null)
                {
                    nmlist.Reset();
                    if (nmlist.Zone != null)
                    {
                        eurekaZone = nmlist.Zone.Any(x => x.Equals(lastZone));
                    }
                }
                nmlistPage.OnOff(eurekaZone);
            }
            if (nmlist == null)
                return;
            if (!isImport && eurekaZone && Added != null && logInfo.logLine.Length > RequiredLen)
            {
                var match = Added.Match(logInfo.logLine.Substring(TimeStampLen));
                if (match.Success)
                {
                    var g = match.Groups;
                    var name = g["Name"].Value.ToLower();
                    var i = nmlist.FindNM(name);
                    if (i >= 0)
                    {
                        if (nmlist.List[i].Self)
                        {
                            if ((DateTime.Now - nmlist.List[i].PopTime).TotalMinutes < (nmlist.List[i].Repop / 2))
                            {
                                return;
                            }
                        }
                        nmlist.List[i].Self = true;
                        nmlist.List[i].SetPopTime( DateTime.Now);

                    }
                }
                else if (Autoimport != AutoImport.None && !autoimported && Import != null)
                {
                    var m = Import.Match(logInfo.logLine.Substring(TimeStampLen));
                    if (m.Success)
                    {
                        var b = ImportNM(logInfo.logLine.Substring(TimeStampLen));
                        if (b)
                        {
                            if (Autoimport == AutoImport.Once)
                                autoimported = true;
                        }

                    }
                }
            }
        }
        public void Start()
        {
            lastZone = "";
            ActGlobals.oFormActMain.BeforeLogLineRead += new LogLineEventDelegate(BeforeLogLineRead);
        }
        public void Stop()
        {
            ActGlobals.oFormActMain.BeforeLogLineRead -= new LogLineEventDelegate(BeforeLogLineRead);
        }

        public bool ImportNM(string text)
        {
            bool ret = false;
            if (Imports == null)
                return false;
            var nmlist = NMList;
            if (nmlist == null)
                return false;
            var tz = DefaultTimezone;
            var tz_m = timezoneRegex.Match(text);
            if (tz_m.Success)
            {
                string min = "00";
                if (!string.IsNullOrEmpty(tz_m.Groups[2].Value))
                    min = tz_m.Groups[2].Value;
                try
                {
                    tz = TimeSpan.Parse(tz_m.Groups[1].Value + ":" + min);
                }catch (Exception) {

                }
            }
            foreach (var regexp in Imports)
            {
                var m = regexp.Match(text);
                while (m.Success)
                {
                    var g = m.Groups;
                    var name = g["Name"].Value.ToLower();
                    var i = nmlist.FindNM(name);
                    if (i == -1 || nmlist.List[i].Self)
                    {
                        m = m.NextMatch();
                        continue;
                    }
                    var minstr = g["Min"].Value;
                    var now = DateTime.Now;
                    if (minstr != "")
                    {
                        int min = Int32.Parse(minstr);
                        nmlist.List[i].SetPopTime(now.AddMinutes(min - nmlist.List[i].Repop));
                        m = m.NextMatch();
                        continue;
                    }
                    var hhstr = g["HH"].Value;
                    var mmstr = g["MM"].Value;
                    if (hhstr != "" && mmstr != "")
                    {
                        var pop = DateTime.UtcNow.Add(tz);
                        int hh = Int32.Parse(hhstr);
                        int mm = Int32.Parse(mmstr);
                        if (hh < pop.Hour || (hh == pop.Hour && mm <= pop.Minute))
                        {
                        }
                        else
                        {
                            pop = pop.AddDays(-1);
                        }
                        pop = new DateTimeOffset(pop.Year, pop.Month, pop.Day, hh, mm, 0, tz).LocalDateTime;
                        if ((now - pop).TotalMinutes < nmlist.List[i].Repop)
                        {
                            nmlist.List[i].SetPopTime(pop);
                        }
                        else
                        {
                            nmlist.List[i].Reset();
                        }
                        ret = true;
                    }
                    m = m.NextMatch();
                }
                if (ret)
                    break;
            }
            if (ret)
                nmlist.Refresh = true;
            return ret;
        }
        void LoadSettings()
        {
            if (!File.Exists(settingsFile))
                return;
            FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlTextReader xReader = new XmlTextReader(fs);
            while (xReader.Read())
            {
                if (xReader.NodeType == XmlNodeType.Element && xReader.LocalName == "SettingsSerializer")
                    XmlSettings.ImportFromXml(xReader);
            }
            xReader.Close();
        }

        public void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");
            xWriter.WriteStartElement("SettingsSerializer");
            XmlSettings.ExportToXml(xWriter);
            xWriter.WriteEndElement();
            xWriter.WriteEndElement();
            xWriter.WriteEndDocument();
            xWriter.Flush();
            xWriter.Close();
        }

        public bool LoadYaml()
        {
            NMList = null;
            Stop();
            Added = null;
            TimeStampLen = 15;
            RequiredLen = 20;
            Autoimport = AutoImport.None;
            var yfile = Path.Combine(YamlFolder, YamlFile);
            Imports = new List<Regex>();
            if(System.IO.File.Exists(yfile))
            {
                using (var file = new StreamReader(yfile, Encoding.UTF8))
                {
                    var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(new CamelCaseNamingConvention())
                        .Build();
                    var nmlist = deserializer.Deserialize<YamlNMList>(file);
                    if (nmlist.List == null)
                        throw new FormatException("need list");
                    if (nmlist.Added == "")
                        throw new FormatException("need added Regex");
                    if (nmlist.Importnm == null)
                        throw new FormatException("need importnm");
                    if (nmlist.Weather == null)
                        throw new FormatException("need weather");
                    if (nmlist.Import == "")
                        throw new FormatException("need import");
                    Added = new Regex(nmlist.Added, RegexOptions.Compiled);
                    TimeStampLen = nmlist.Timestamplen;
                    RequiredLen = nmlist.Requiredlen;
                    switch (nmlist.Autoimport.ToLower())
                    {
                        case "none":
                            Autoimport = AutoImport.None;
                            break;
                        case "once":
                            Autoimport = AutoImport.Once;
                            break;
                        case "always":
                            Autoimport = AutoImport.Always;
                            break;
                    }
                    nmlist.MakeDict();
                    foreach (var nm in nmlist.List)
                    {
                        nm.PopTime = DateTime.MinValue;
                    }
                    Import = new Regex(nmlist.Import, RegexOptions.Compiled);

                    foreach (var regexp in nmlist.Importnm)
                    {
                        var r = new Regex(regexp, RegexOptions.Compiled);
                        Imports.Add(r);
                    }
                    NMList = nmlist;
                }
            }
            Start();
            return true;
        }
        //https://github.com/RainbowMage/OverlayPlugin/blob/master/OverlayPlugin/PluginLoader.cs
        private string GetPluginDirectory()
        {
            // ACT のプラグインリストからパスを取得する
            // Assembly.CodeBase からはパスを取得できない
            var plugin = ActGlobals.oFormActMain.ActPlugins.Where(x => x.pluginObj == this).FirstOrDefault();
            if (plugin != null)
            {
                return System.IO.Path.GetDirectoryName(plugin.pluginFile.FullName);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}