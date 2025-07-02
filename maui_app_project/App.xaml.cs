namespace maui_app_project
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Services = serviceProvider;

            // Simple login check:
            MainPage = Preferences.Get("logged_in", false)
                ? new AppShell()
                : new NavigationPage(new MainPage());
        }
    }
}
