using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Portfolio.Model
{
    public class Leider
    {
        [JsonProperty]
        public String Naam { get; set; }

        [JsonProperty]
        public String FotoUri { get; set; }

        [JsonIgnore]
        public Groep Groep { get; set; }

        [JsonProperty]
        public string GroepNaam { get; set; }

        [OnDeserialized]
        internal void InitGroep(StreamingContext context)
        {
            Groep = Groep.ALLE.FirstOrDefault(groep => groep.Naam == GroepNaam);
        }

        [OnSerializing]
        internal void InitGroepNaam(StreamingContext context)
        {
            GroepNaam = Groep.Naam;
        }
    }
}