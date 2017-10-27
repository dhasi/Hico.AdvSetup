using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Hico.AdvSetup.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public List<StepViewModel> Steps { get; set; }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set { Set(ref _progress, value); }
        }
        
        private StepViewModel _currentStep;
        public StepViewModel CurrentStep
        {
            get { return _currentStep; }
            set { Set(ref _currentStep, value); }
        }

        private RelayCommand _navigateBackCommad;
        public RelayCommand NavigateBackCommand
        {
            get { return _navigateBackCommad ?? (_navigateBackCommad = new RelayCommand(NavigateBack, CanNavigateBack)); }
        }


        private RelayCommand _navigateForwardCommand;
        public RelayCommand NavigateForwardCommand
        {
            get { return _navigateForwardCommand ?? (_navigateForwardCommand = new RelayCommand(NavigateForward, CanNavigateForward)); }
        }

        public event EventHandler OnNavigateBack;
        public event EventHandler OnNavigateForward;

        public MainViewModel()
        {
            Title = "HICO-ICS Advanced Setup";
            Steps = new List<StepViewModel>
            {
                new Step1ViewModel(this),
                new Step2ViewModel(this),
            };
            CurrentStep = Steps.FirstOrDefault();
        }

        private bool CanNavigateForward()
        {
            return Steps.IndexOf(_currentStep) < Steps.Count - 1;
        }

        private void NavigateForward()
        {
            OnNavigateForward?.Invoke(this, EventArgs.Empty);
            CurrentStep = Steps[Steps.IndexOf(CurrentStep) + 1];
        }

        private bool CanNavigateBack()
        {
            return Steps.IndexOf(CurrentStep) > 0;
        }

        private void NavigateBack()
        {
            OnNavigateBack?.Invoke(this, EventArgs.Empty);
            CurrentStep = Steps[Steps.IndexOf(CurrentStep) - 1];
        }
    }
}
