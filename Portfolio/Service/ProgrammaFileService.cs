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

        public async Task<ObservableCollection<Programma>> GetProgrammasForGroep(Groep groep)
        {
            _programmas = await OpenOrCreateFileAndGetContents();
            return new ObservableCollection<Programma>(from programma in _programmas
                                                       where programma.Groep.Naam == groep.Naam
                                                       orderby programma.Datum
                                                       select programma);
        }
        public Task Add(Programma newProgramma)
        {
            _programmas.Add(newProgramma);
            return WriteToFile();
        }
        public Task Remove(Programma programma)
        {
            _programmas.Remove(programma);
            return WriteToFile();
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