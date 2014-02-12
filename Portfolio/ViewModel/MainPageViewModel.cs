using System;
using System.Collections.Generic;
using App2.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Portfolio.Model;
using Portfolio.Navigation;
using Portfolio.Service;

namespace Portfolio.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IProgrammaService _programmaService;

        private Groep _selectedGroep;

        private DateTime _selectedProgrammaDate;

        public MainPageViewModel(NavigationService navigationService, IProgrammaService programmaService)
        {
            _navigationService = navigationService;
            _programmaService = programmaService;
            Initialize();
        }

        public IEnumerable<Groep> Groepen { get; private set; }

        public Groep SelectedGroep
        {
            get { return _selectedGroep; }
            set
            {
                if (_selectedGroep == value) return;
                Messenger.Default.Send(new GroepMessage(value));
                _navigationService.Navigate(typeof (GroepDetailPage));
                RaisePropertyChanged();
            }
        }

        public DateTime SelectedProgramaDate
        {
            get { return _selectedProgrammaDate; }
            set
            {
                _selectedProgrammaDate = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<DateTime> PossibleProgrammaDates { get; private set; }

        private async void Initialize()
        {
            Groepen = Groep.ALLE;
            _selectedProgrammaDate = await _programmaService.GetMostRecentDate();
            PossibleProgrammaDates = await _programmaService.GetPossibleDates();
        }
    }
}