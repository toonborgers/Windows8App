using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Model;

namespace Portfolio.Service
{
    public class LeiderFileService : AbstractFileService<Leider>, ILeiderService
    {
        private const string Filename = "leiders.json";
        private ObservableCollection<Leider> _leiders;

        public async Task<ObservableCollection<Leider>> GetLeidersForGroep(Groep groep)
        {
            _leiders = new ObservableCollection<Leider>(from leider in await OpenOrCreateFileAndGetContents()
                                                        where leider.Groep.Naam == groep.Naam
                                                        select leider);

            return _leiders;
        }

        public Task Add(Leider newLeider)
        {
            _leiders.Add(newLeider);
            return WriteToFile();
        }
            
        public Task Remove(Leider leiderToRemove)
        {
            _leiders.Remove(leiderToRemove);
            return WriteToFile();
        }

        protected override string GetFileName()
        {
            return Filename;
        }

        protected override ObservableCollection<Leider> GetItems()
        {
            return _leiders;
        }
    }
}