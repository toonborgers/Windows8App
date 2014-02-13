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

        protected bool Equals(Leider other)
        {
            return string.Equals(Naam, other.Naam) && string.Equals(FotoUri, other.FotoUri) && Equals(Groep, other.Groep) && string.Equals(GroepNaam, other.GroepNaam);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Leider) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Naam != null ? Naam.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FotoUri != null ? FotoUri.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Groep != null ? Groep.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (GroepNaam != null ? GroepNaam.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}