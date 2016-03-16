using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TestApp
{
    public class App : Application
    {
        private MR.Gestures.MultiLevelListView<MR.Gestures.MultiLevelItemBase> _listView;
        private ObservableCollection<MR.Gestures.MultiLevelItemBase> _source;

        public App()
        {
            AppAsync();
        }

        private void AppAsync()
        {
            _listView = new MR.Gestures.MultiLevelListView<MR.Gestures.MultiLevelItemBase>();
            _source = new ObservableCollection<MR.Gestures.MultiLevelItemBase>();

            _listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            _listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = _listView
            };

            for (int i = 0; i < 3; i++)
            {
                var root = new MR.Gestures.MultiLevelItemBase() { Name = "Root " + i };
                _source.Add(root);
                for (int j = 0; j < 3; j++)
                {
                    var child1 = new MR.Gestures.MultiLevelItemBase() { Name = $"Child {i}-{j}" };
                    root.Children.Add(child1);
                    for (int k = 0; k < 3; k++)
                    {
                        var child2 = new MR.Gestures.MultiLevelItemBase() { Name = $"Child {i}-{j}-{k}" };
                        child1.Children.Add(child2);
                    }
                }
            }
            _listView.ItemsSource = _source;
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