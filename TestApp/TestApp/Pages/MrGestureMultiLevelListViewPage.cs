using System.Collections.ObjectModel;
using MR.Gestures;
using MR.Gestures.MultilevelListView;
using TestApp.ListViewCells;
using Xamarin.Forms;
using ContentPage = MR.Gestures.ContentPage;
using ContentView = MR.Gestures.ContentView;
using MultiLevelItemBase = MR.Gestures.MultilevelListView.MultiLevelItemBase;

namespace TestApp.Pages
{
    public class MrGestureMultiLevelListViewPage : ContentPage
    {
        private MultiLevelListView _listView;
        private ObservableCollection<MultiLevelItemBase> _source;

        public MrGestureMultiLevelListViewPage()
        {
            InitAsync();
        }

        private void InitAsync()
        {
            _listView = new MultiLevelListView();
            _source = new ObservableCollection<MultiLevelItemBase>();

            _listView.ItemTemplate = new DataTemplate(typeof(MrGestureTestCell));
            _listView.ItemTemplate.SetBinding(MrGestureTestCell.ItemProperty, "Item");
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
                    var child1 = new MultiLevelItemBase() { Name = $"\tChild {i}-{j}" };
                    root.Children.Add(child1);
                    for (int k = 0; k < 3; k++)
                    {
                        var child2 = new MultiLevelItemBase() { Name = $"\t\tChild {i}-{j}-{k}" };
                        child1.Children.Add(child2);
                    }
                }
            }
            _listView.ItemsSource = _source;
        }
    }
}
