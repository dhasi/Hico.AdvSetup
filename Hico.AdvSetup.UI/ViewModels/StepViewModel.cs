using GalaSoft.MvvmLight;

namespace Hico.AdvSetup.UI.ViewModels
{
    public abstract class StepViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        public MainViewModel MainViewModel { get { return _mainViewModel; } }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set { Set(ref _progress, value); }
        }

        public StepViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}
