using Hico.AdvSetup.UI.Views;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Diagnostics;
using System.Windows.Threading;
using System;

namespace Hico.AdvSetup.UI
{
    public class AdvBootstrapperApplication : BootstrapperApplication
    {
        public static Dispatcher Dispatcher { get; set; }

        protected override void Run()
        {
            Dispatcher = Dispatcher.CurrentDispatcher;

            var shellView = new ShellView();
            shellView.Closed += OnShellClosed;
            Engine.Detect();

            shellView.Show();

            Dispatcher.Run();

            this.Engine.Quit(0);
        }

        private void OnShellClosed(object sender, EventArgs e)
        {
            Dispatcher.InvokeShutdown();
        }
    }
}
