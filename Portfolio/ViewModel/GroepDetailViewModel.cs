using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Portfolio.Model;
using Portfolio.Navigation;
using Portfolio.Service;

namespace Portfolio.ViewModel
{
    public class GroepDetailViewModel : ViewModelBase
    {
        private readonly ILeiderService _leiderService;
        private readonly IProgrammaService _programmaService;

        public GroepDetailViewModel(IProgrammaService programmaService, ILeiderService leiderService)
        {
            _programmaService = programmaService;
            _leiderService = leiderService;
            Messenger.Default.Register<GroepMessage>(this, msg => GroepSelected(msg.Groep));
            SaveNewLeiderCommand = new RelayCommand(SaveNewLeider);
            RemoveLeiderCommand = new RelayCommand(RemoveSelectedLeider);
            LeiderToevoegenDisplayOpen = false;
            CommandBarDisplayed = false;
        }

        public Groep Groep { get; private set; }

        public Leider LeiderUnderCreation { get; set; }

        public ObservableCollection<Programma> Programmas { get; private set; }

        public ObservableCollection<Leider> Leiders { get; private set; }

        public ICommand SaveNewLeiderCommand { get; private set; }

        public ICommand RemoveLeiderCommand { get; private set; }

        public Leider SelectedLeider { get; set; }

        public Boolean LeiderToevoegenDisplayOpen { get; private set; }
        
        public Boolean CommandBarDisplayed { get; private set; }

        private async void GroepSelected(Groep groep)
        {
            Groep = groep;
            LeiderUnderCreation = new Leider { Groep = groep, FotoUri = groep.ImageLocation };
            Leiders = await _leiderService.GetLeidersForGroep(groep);
            RaisePropertyChanged(() => Leiders);
        }

        public void NewLeiderImageSelected(string path)
        {
            LeiderUnderCreation.FotoUri = path;
        }

        private async void SaveNewLeider()
        {
            await _leiderService.Add(LeiderUnderCreation);
            LeiderToevoegenDisplayOpen = false;
            RaisePropertyChanged(() => Leiders);
            RaisePropertyChanged(() => LeiderToevoegenDisplayOpen);
            CloseCommandBar();
        }

        private async void RemoveSelectedLeider()
        {
            if (SelectedLeider == null) return;
            await _leiderService.Remove(SelectedLeider);
            RaisePropertyChanged(() => Leiders);
            SelectedLeider = null;
            CloseCommandBar();
        }

        private void CloseCommandBar()
        {
            CommandBarDisplayed = false;
            RaisePropertyChanged(() => CommandBarDisplayed);
        }
    }
}