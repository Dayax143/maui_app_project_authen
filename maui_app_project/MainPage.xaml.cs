using maui_app_project.Services;
using BCrypt;

namespace maui_app_project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var authService = App.Services.GetService<AuthService>();
                var success = await authService.LoginAsync(UsernameEntry.Text, PasswordEntry.Text);

                if (success)
                {
                    await DisplayAlert("Success", "You're logged in", "OK");
                    // Optionally navigate to the main shell
                    // Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await DisplayAlert("Error", "Invalid credentials", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Failed", ex.Message, "OK");
            }
        }
    }
}
