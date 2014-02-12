using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Model;

namespace Portfolio.Service
{
    public class ProgrammaFileService : AbstractFileService<Programma>, IProgrammaService
    {
        private const string Filename = "programmas.json";
        private ObservableCollection<Programma> _programmas;

        public async Task<ObservableCollection<Programma>> GetProgrammas(DateTime date)
        {
            return _programmas ?? (_programmas = await OpenOrCreateFileAndGetContents());
        }

        public async Task<ObservableCollection<Programma>> GetProgrammasForGroep(Groep groep)
        {
            return new ObservableCollection<Programma>(from programma in await OpenOrCreateFileAndGetContents()
                                                       where programma.Groep.Naam == groep.Naam
                                                       orderby programma.Datum
                                                       select programma);
        }

        public Task Add(Programma newProgramma)
        {
            _programmas.Add(newProgramma);
            return WriteToFile();
        }

        public async Task<DateTime> GetMostRecentDate()
        {
            if (_programmas == null)
            {
                _programmas = await OpenOrCreateFileAndGetContents();
            }
            return (from programma in _programmas
                    where programma.Datum > DateTime.Now
                    orderby programma.Datum ascending
                    select programma.Datum)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<DateTime>> GetPossibleDates()
        {
            if (_programmas == null)
            {
                _programmas = await OpenOrCreateFileAndGetContents();
            }
            return from programma in _programmas
                   select programma.Datum;
        }

        protected override string GetFileName()
        {
            return Filename;
        }

        protected override ObservableCollection<Programma> GetItems()
        {
            return _programmas;
        }
    }
}