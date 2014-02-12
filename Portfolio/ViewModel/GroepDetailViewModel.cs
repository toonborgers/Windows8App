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
            SaveNewProgrammaCommand = new RelayCommand(SaveNewProgramma);

            LeiderToevoegenDisplayOpen = false;
            ProgrammaToevoegenDisplayOpen = false;
            CommandBarDisplayed = false;
        }

        public Groep Groep { get; private set; }
        public Leider LeiderUnderCreation { get; set; }
        public Programma ProgrammaUnderCreation { get; set; }
        public ObservableCollection<Programma> Programmas { get; private set; }
        public ObservableCollection<Leider> Leiders { get; private set; }
        public ICommand SaveNewLeiderCommand { get; private set; }
        public ICommand RemoveLeiderCommand { get; private set; }
        public ICommand SaveNewProgrammaCommand { get; private set; }
        public Leider SelectedLeider { get; set; }
        public Boolean LeiderToevoegenDisplayOpen { get; private set; }
        public Boolean ProgrammaToevoegenDisplayOpen { get; private set; }
        public Boolean CommandBarDisplayed { get; private set; }

        private async void GroepSelected(Groep groep)
        {
            Groep = groep;
            LeiderUnderCreation = new Leider { Groep = groep, FotoUri = groep.ImageLocation };
            ProgrammaUnderCreation = new Programma() { Groep = Groep, Datum = DateTime.Now, Tekst = String.Empty };

            Leiders = await _leiderService.GetLeidersForGroep(groep);
            Programmas = await _programmaService.GetProgrammasForGroep(groep);
            RaisePropertyChanged(() => Leiders);
            RaisePropertyChanged(() => Programmas);
        }

        public void NewLeiderImageSelected(string path)
        {
            LeiderUnderCreation.FotoUri = path;
        }

        private async void SaveNewLeider()
        {
            await _leiderService.Add(LeiderUnderCreation);
            LeiderUnderCreation.FotoUri = Groep.ImageLocation;
            LeiderUnderCreation.Naam = string.Empty;
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
            SelectedLeider = new Leider { Groep = Groep, FotoUri = Groep.ImageLocation };
            CloseCommandBar();
        }

        private async void SaveNewProgramma()
        {
            await _programmaService.Add(ProgrammaUnderCreation);
            ProgrammaUnderCreation.Datum = DateTime.Now;
            ProgrammaUnderCreation.Tekst = string.Empty;
            ProgrammaToevoegenDisplayOpen = false;
            RaisePropertyChanged(() => ProgrammaToevoegenDisplayOpen);
            CloseCommandBar();
        }

        private void CloseCommandBar()
        {
            CommandBarDisplayed = false;
            RaisePropertyChanged(() => CommandBarDisplayed);
        }
    }
}