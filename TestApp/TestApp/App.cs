using System.Collections.ObjectModel;
using TestApp.Pages;
using Xamarin.Forms;

namespace TestApp
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}