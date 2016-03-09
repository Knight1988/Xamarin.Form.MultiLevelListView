using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiLevelListview
{
    public class MultiLevelItemBase
    {
        //public List<MultiLevelItemBase> Children { get; set; } = new List<MultiLevelItemBase>();
        public bool IsExpand { get; internal set; }
        public string Name { get; set; }
    }

    public class MultiLevelListBase<T> : ObservableCollection<T>
    {
        
    }

    public class TestListView<T> : ListView where T : MultiLevelItemBase
    {
        public ObservableCollection<T> Source
        {
            get { return ItemsSource as ObservableCollection<T>; }
            set { ItemsSource = value; }
        }

        public TestListView()
        {
            //ItemTapped += OnItemTapped;
        }

/*
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = (T) args.Item;

            if (item.IsExpand)
            {
                foreach (var multiLevelItemBase in item.Children)
                {
                    var child = (T) multiLevelItemBase;
                    Source.Remove(child);
                }
                item.IsExpand = false;
            }
            else
            {
                var i = Source.IndexOf(item) + 1;
                foreach (var multiLevelItemBase in item.Children)
                {
                    var child = (T)multiLevelItemBase;
                    Source.Insert(i++, child);
                }
                item.IsExpand = true;
            }
        }
*/
    }
}
