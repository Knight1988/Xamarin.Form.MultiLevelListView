using System.Collections.ObjectModel;
using MultiLevelListview;
using Xamarin.Forms;

namespace TestApp
{
    public class MultiLevelListViewPage : ContentPage
    {
        private MultiLevelListView<MultiLevelItemBase> _listView;
        private ObservableCollection<MultiLevelItemBase> _source;

        public MultiLevelListViewPage()
        {
            InitAsync();
        }

        private void InitAsync()
        {
            _listView = new MultiLevelListView<MultiLevelItemBase>();
            _source = new ObservableCollection<MultiLevelItemBase>();

            _listView.ItemTemplate = new DataTemplate(typeof(TestCell));
            //_listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            // The root page of your application
            Content = new ContentView()
            {
                Content = _listView
            };

            for (int i = 0; i < 3; i++)
            {
                var root = new MultiLevelItemBase() { Name = "Root " + i };
                _source.Add(root);
                for (int j = 0; j < 3; j++)
                {
                    var child1 = new MultiLevelItemBase() { Name = $"Child {i}-{j}" };
                    root.Children.Add(child1);
                    for (int k = 0; k < 3; k++)
                    {
                        var child2 = new MultiLevelItemBase() { Name = $"Child {i}-{j}-{k}" };
                        child1.Children.Add(child2);
                    }
                }
            }
            _listView.ItemsSource = _source;
        }
    }
}
