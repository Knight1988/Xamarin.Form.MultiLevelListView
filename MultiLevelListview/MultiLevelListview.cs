using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MultiLevelListview
{
    public class MultiLevelListView<T> : ListView where T : MultiLevelItemBase
    {
        public new ObservableCollection<T> ItemsSource
        {
            get { return base.ItemsSource as ObservableCollection<T>; }
            set { base.ItemsSource = value; }
        }

        public MultiLevelListView()
        {
            ItemTapped += OnItemTapped;
        }


        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            // Get tapped item
            var item = (T)args.Item;

            // Check if item is on expand state
            if (item.IsExpand)
            {
                // Set collapse
                item.Collapse();

                var allChildren = item.Children.Concat(item.Children.SelectMany(p => p.Children));

                // Remove children
                foreach (var multiLevelItemBase in allChildren)
                {
                    var child = (T)multiLevelItemBase;
                    ItemsSource.Remove(child);
                }
            }
            else
            {
                // get item index
                var i = ItemsSource.IndexOf(item) + 1;
                
                // insert item under the parent
                foreach (var multiLevelItemBase in item.Children)
                {
                    var child = (T)multiLevelItemBase;
                    ItemsSource.Insert(i++, child);
                }
                item.Expand();
            }
        }

    }
}