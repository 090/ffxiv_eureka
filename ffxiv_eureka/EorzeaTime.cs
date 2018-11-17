using System;

namespace ffxiv_eureka
{
    class EorzeaTime
    {
        private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private double unixtime;

        public EorzeaTime(DateTime date)
        {
            TimeSpan elapsedTime = date.ToUniversalTime() - UNIX_EPOCH;
            unixtime = elapsedTime.TotalMilliseconds;
        }

        public string ET(){

            ulong et = (ulong)unixtime % (70 * 60 * 1000);
            ulong min = et % 175000 / 2917;
            ulong hour = et / 175000;
            return string.Format("{0:00}:{1:00}",hour,min);
        }
        public string LT()
        {
            return UNIX_EPOCH.AddMilliseconds(unixtime).ToLocalTime().ToString("HH:mm:ss");
        }

        public void Add(int sec)
        {
            unixtime += sec*1000;
        }

        public void Chop()
        {
            unixtime = unixtime - (unixtime % 1400_000);
        }

        public int Calculate()
        {
            var days = (uint)(unixtime / 4200_000) * 100 + ((uint)(unixtime / 1400_000) + 1) % 3 * 8;
            var step1 = (days << 11) ^ days;
            return (int)(((step1 >> 8) ^ step1) % 100);
        }
    }
}
