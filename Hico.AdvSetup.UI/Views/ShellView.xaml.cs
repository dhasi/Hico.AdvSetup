using Hico.AdvSetup.UI.ViewModels;
using MahApps.Metro.Controls;
using System;

namespace Hico.AdvSetup.UI.Views
{
    /// <summary>
    /// Interaction logic for InstallerView.xaml
    /// </summary>
    public partial class ShellView
    {
        public ShellView()
        {
            InitializeComponent();

            var ctx = new MainViewModel();
            ctx.OnNavigateForward += OnNavigateForward;
            ctx.OnNavigateBack += OnNavigateBack;
            DataContext = ctx;
        }

        private void OnNavigateForward(object sender, EventArgs e)
        {
            transiationControl.Transition = TransitionType.Left;
        }

        private void OnNavigateBack(object sender, EventArgs e)
        {
            transiationControl.Transition = TransitionType.Right;
        }
    }
}
