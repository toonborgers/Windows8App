using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Model;

namespace Portfolio.Service
{
    public interface IKalenderEventService
    {
        Task<ObservableCollection<KalenderListItem>> GetKalenderEvents();
    }
}
