using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App2.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private readonly IKalenderEventService _kalenderEventService;
        private Groep _selectedGroep;

        public MainPageViewModel(NavigationService navigationService, IProgrammaService programmaService, IKalenderEventService kalenderEventService)
        {
            _navigationService = navigationService;
            _programmaService = programmaService;
            _kalenderEventService = kalenderEventService;
            
            Initialize();

            SendMailCommand = new RelayCommand<string>(OpenMail);
            OpenMapCommand = new RelayCommand(OpenMap);
        }

        public IEnumerable<Groep> Groepen { get; private set; }

        public  ObservableCollection<KalenderListItem> KalenderEvents { get; private set; }

        public RelayCommand<string> SendMailCommand { get;private set; }
        public RelayCommand OpenMapCommand { get; private set; }

        public Groep SelectedGroep
        {
            get { return _selectedGroep; }
            set
            {
                if (_selectedGroep == value) return;
                Messenger.Default.Send(new GroepMessage(value));
                _navigationService.Navigate(typeof(GroepDetailPage));
                RaisePropertyChanged();
            }
        }

        private async void Initialize()
        {
            Groepen = Groep.ALLE;
            KalenderEvents = await _kalenderEventService.GetKalenderEvents();
        }

        private static async void OpenMail(string type)
        {
            var uri = new Uri("mailto:?to=contact@chirokasterlee.be&subject=Bericht vanuit app [" + type + "]");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private static async void OpenMap()
        {
            var uri = new Uri("bingmaps:?collection=point.51.244563_4.982103_Chiro%20Kasterlee");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

    }

    enum MailType
    {
        MailJongens,MailMeisjes,Contact
    }
}