using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Portfolio.Model
{
    public class Programma
    {
        [JsonIgnore]
        public DateTime Datum { get; set; }
        [JsonIgnore]
        public Groep Groep { get; set; }
        [JsonProperty]
        public String Tekst { get; set; }
        [JsonProperty]
        public string GroepNaam { get; set; }
        [JsonProperty]
        public long Ticks { get; set; }

        [OnDeserialized]
        internal void InitGroep(StreamingContext context)
        {
            Groep = Groep.ALLE.FirstOrDefault(groep => groep.Naam == GroepNaam);
            Datum = new DateTime(Ticks);
        }

        [OnSerializing]
        internal void InitGroepNaam(StreamingContext context)
        {
            GroepNaam = Groep.Naam;
            Ticks = Datum.Ticks;
        }
    }
}