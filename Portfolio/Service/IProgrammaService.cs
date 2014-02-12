using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Portfolio.Model;

namespace Portfolio.Service
{
    public interface IProgrammaService
    {
        Task<ObservableCollection<Programma>> GetProgrammas(DateTime date);
        Task<DateTime> GetMostRecentDate();
        Task<IEnumerable<DateTime>> GetPossibleDates();
    }
}