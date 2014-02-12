using System;

namespace Portfolio.Model
{
    public class Programma
    {
        private DateTime _datum;
        private Groep _groep;
        private string _tekst;

        public DateTime Datum
        {
            get { return _datum; }
            set
            {
                if (value == _datum) return;
                _datum = value;
            }
        }

        public Groep Groep
        {
            get { return _groep; }
            set
            {
                if (value == _groep) return;
                _groep = value;
            }
        }

        public String Tekst
        {
            get { return _tekst; }
            set
            {
                if (value == _tekst) return;
                _tekst = value;
            }
        }
    }
}