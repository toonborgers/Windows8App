using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Portfolio.Model
{
    public class KalenderEvent : KalenderListItem
    {
        public DateTime Date { get; set; }
        public string EventName { get; set; }
        public bool IsHeader()
        {
            return false;
        }
    }
}
