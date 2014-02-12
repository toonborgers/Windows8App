using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Portfolio.Model;

namespace Portfolio.Service
{
    public interface ILeiderService
    {
        Task<ObservableCollection<Leider>> GetLeidersForGroep(Groep groep);

        Task Add(Leider newLeider);

        Task Remove(Leider leider);
    }
}