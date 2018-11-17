using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ffxiv_eureka
{
    public class YamlNM
    {
        public string ID;
        public List<string> Ja { get; set; }
        public List<string> En { get; set; }
        public List<string> De { get; set; }
        public List<string> Fr { get; set; }
        public List<string> Cn { get; set; }
        public List<string> Kr { get; set; }
        public int Lv { get; set; }
        public int Repop { get; set; }
        public string Prefix { get; set; }
        public ListViewItem Item;
        public bool Self;
        public DateTime PopTime;
        public DateTime RepopTime;

        public string Name()
        {
            switch (YamlNMList.Lang)
            {
                case Lang.Japanese:
                    if (Ja == null)
                        break;
                    return Ja[0];
                case Lang.English:
                    if (En == null)
                        break;
                    return En[0];
                case Lang.Deutsch:
                    if (De == null)
                        break;
                    return De[0];
                case Lang.Français:
                    if (Fr == null)
                        break;
                    return Fr[0];
                case Lang.Chinese:
                    if (Cn == null)
                        break;
                    return Cn[0];
                case Lang.Korean:
                    if (Kr == null)
                        break;
                    return Kr[0];
            }
            if (En != null)
                return En[0];
            if (Ja != null)
                return Ja[0];
            if (De != null)
                return De[0];
            if (Cn != null)
                return Cn[0];
            if (Kr != null)
                return Kr[0];
            return "No Name";
        }
        private string _Name(int i)
        {
            switch (YamlNMList.Lang)
            {
                case Lang.Japanese:
                    if (Ja == null)
                        break;
                    return Ja.Count> i ? Ja[i] : null;
                case Lang.English:
                    if (En == null)
                        break;
                    return En.Count > i ? En[i] : null;
                case Lang.Deutsch:
                    if (De == null)
                        break;
                    return De.Count > i ? De[i] : null;
                case Lang.Français:
                    if (Fr == null)
                        break;
                    return Fr.Count > i ? Fr[i] : null;
                case Lang.Chinese:
                    if (Cn == null)
                        break;
                    return Cn.Count > i ? Cn[i] : null;
                case Lang.Korean:
                    if (Kr == null)
                        break;
                    return Kr.Count > i ? Kr[i] : null;
            }
            if (En != null)
                return En.Count > i ? En[i] : null;
            if (Ja != null)
                return Ja.Count > i ? Ja[i] : null;
            if (De != null)
                return De.Count > i ? De[i] : null;
            if (Fr != null)
                return Fr.Count > i ? Fr[i] : null;
            if (Cn != null)
                return Cn.Count > i ? Cn[i] : null;
            if (Kr != null)
                return Kr.Count > i ? Kr[i] : null;
            return null;
        }
        private string Name(int i)
        {
            while(i >= 0)
            {
                var r = _Name(i);
                if (!string.IsNullOrEmpty(r))
                    return r;
                --i;
            }
            return "No Name";
        }
        public void Reset()
        {
            PopTime = DateTime.MinValue;
            RepopTime = DateTime.MinValue;
            Self = false;
        }
        public void SetPopTime(DateTime pop)
        {
            PopTime = pop;
            RepopTime = pop.AddMinutes(Repop);
        }
        public string GetRepop(DateTime now)
        {
            if (PopTime == DateTime.MinValue)
                return "";
            var repop = Math.Floor((RepopTime - now).TotalMinutes);
            if (repop > 0)
            {
                return repop.ToString() + "min";
            }
            else
            {
                repop = Math.Floor((RepopTime - now).TotalSeconds);
                if (repop > 0)
                {
                    return repop.ToString() + "sec";
                }
                else
                {
                    Reset();
                    return "";
                }
            }
        }
        public string GetExport(YamlExport ex)
        {
            
            var r = ex.Text;
            var m = Regex.Match(r, @"<Name(\d*)>",RegexOptions.IgnoreCase);
            if (m.Success)
            {
                int i=0;
                string idx = m.Groups[1].Value;
                if (!string.IsNullOrEmpty(idx))
                {
                    i = Int32.Parse(idx);
                    --i;
                    if (i < 0)
                        i = 0;
                }
                r=r.Replace(m.Value, this.Name(i));
            }
            string min = "up";
            string poptime = "--:--";
            if (PopTime != DateTime.MinValue)
            {
                var repop = Math.Floor((RepopTime - DateTime.Now).TotalMinutes);
                if (repop >= 0)
                    min =  repop.ToString() + "m";
                poptime = PopTime.ToString("HH:mm");
            }
            r = r.Replace("<PopTime>", poptime).Replace("<RepopMin>", min).Replace("<Prefix>", Prefix);
            return r;
        }

    }
    public class YamlWeather
    {
        public List<int> Rate { get; set; }
        public List<string> Ja { get; set; }
        public List<string> En { get; set; }
        public List<string> De { get; set; }
        public List<string> Fr { get; set; }
        public List<string> Cn { get; set; }
        public List<string> Kr { get; set; }

        public string Name(int rate)
        {
            int weather = -1;
            foreach(var v in Rate)
            {
                ++weather;
                if (rate < v)
                    break;
                rate -= v;
            }
            if (weather == -1)
                return "Error";
            switch (YamlNMList.Lang)
            {
                case Lang.Japanese:
                    if (Ja == null || Ja.Count <= weather)
                        break;
                    return Ja[weather];
                case Lang.English:
                    if (En == null || En.Count <= weather)
                        break;
                    return En[weather];
                case Lang.Deutsch:
                    if (De == null || De.Count <= weather)
                        break;
                    return De[weather];
                case Lang.Français:
                    if (Fr == null || Fr.Count <= weather)
                        break;
                    return Fr[weather];
                case Lang.Chinese:
                    if (Cn == null || Cn.Count <= weather)
                        break;
                    return Cn[weather];
                case Lang.Korean:
                    if (Kr == null || Kr.Count <= weather)
                        break;
                    return Kr[weather];
            }
            if (En != null && En.Count > weather)
                return En[weather];
            if (Ja != null && Ja.Count > weather)
                return Ja[weather];
            if (De != null && De.Count > weather)
                return De[weather];
            if (Fr != null && Fr.Count > weather)
                return Fr[weather];
            if (Cn != null && Cn.Count > weather)
                return Cn[weather];
            if (Kr != null && Kr.Count > weather)
                return Kr[weather];
            return weather.ToString();
        }
    }
    public class YamlExport
    {
        public string Text { get; set; }
        public string Join { get; set; }
    }
    public class YamlNMList
    {
        static public Lang Lang;
        public List<YamlNM> List { get; set; }
        public YamlWeather Weather { get; set; }
        public List<string> Zone { get; set; }
        public List<YamlExport> Export { get; set; }
        public int Timestamplen { get; set; }
        public int Requiredlen { get; set; }
        public string Added { get; set; }
        public string Autoimport { get; set; }
        public string Import { get; set; }
        public List<string> Importnm { get; set; }
        public bool Refresh = false;
        private Dictionary<string, int> names;
        public void MakeDict()
        {
            if (List == null)
                return;
            names = new Dictionary<string, int>();
            for (int i=0;i<List.Count();++i)
            {
                var nm = List[i];
                var _list = new[] { nm.Ja, nm.En, nm.De, nm.Fr, nm.Cn, nm.Kr };
                for(int j=0;j<_list.Length; ++j)
                {
                    if (_list[j] == null)
                        continue;
                    var lang = _list[j];
                    for(int k=0;k< lang.Count; ++k)
                    {
                        if (string.IsNullOrEmpty(lang[k]))
                            continue;
                        names[lang[k].ToLower()] = i;
                    }
                }
            }
        }

        public int FindNM(string name)
        {
            if (names.ContainsKey(name))
                return names[name];
            return -1;
        }
        public void Reset()
        {
            if (List == null)
                return;
            foreach (var nm in List)
            {
                nm.Reset();
            }
            Refresh = true;
        }
    }
}
