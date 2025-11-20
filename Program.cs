using MyHwInfo.StartProgram;

namespace MyHwInfo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tStartupView = new StartupForm_view();
            var tStartupPresenter = new Startup_presenter(tStartupView);

            Application.Run(tStartupView);
        }
    }
}