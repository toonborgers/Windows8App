using Portfolio.Model;

namespace Portfolio.Navigation
{
    internal class GroepMessage
    {
        private readonly Groep _groep;

        public GroepMessage(Groep groep)
        {
            _groep = groep;
        }

        public Groep Groep
        {
            get { return _groep; }
        }
    }
}