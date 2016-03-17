using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MR.Gestures.MultilevelListView
{
    public class MultiLevelListView : ListView
    {
        public new ObservableCollection<MultiLevelItemBase> ItemsSource
        {
            get { return base.ItemsSource as ObservableCollection<MultiLevelItemBase>; }
            set { base.ItemsSource = value; }
        }

        public void OnItemTapped(MultiLevelItemBase item)
        {
            // Check if item is on expand state
            if (item.IsExpand)
            {
                // Set collapse
                item.Collapse();

                var allChildren = item.Children.Concat(item.Children.SelectMany(p => p.Children));

                // Remove children
                foreach (var child in allChildren)
                {
                    ItemsSource.Remove(child);
                }
            }
            else
            {
                // get item index
                var i = ItemsSource.IndexOf(item) + 1;

                // insert item under the parent
                foreach (var child in item.Children)
                {
                    ItemsSource.Insert(i++, child);
                }
                item.Expand();
            }
        }
    }
}