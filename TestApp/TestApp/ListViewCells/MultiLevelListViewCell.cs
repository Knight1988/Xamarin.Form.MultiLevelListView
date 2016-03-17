using System;
using MR.Gestures;
using MR.Gestures.MultilevelListView;
using Xamarin.Forms;
using BindableProperty = Xamarin.Forms.BindableProperty;
using ViewCell = MR.Gestures.ViewCell;

namespace TestApp.ListViewCells
{
    public class MultiLevelListViewCell : ViewCell
    {
        public new View View
        {
            get { return base.View; }
            set
            {
                var view = value as IGestureAwareControl;
                if (view != null)
                {
                    view.Tapping -= OnTapping;
                    view.Tapping += OnTapping;
                }
                base.View = value;
            }
        }

        private void OnTapping(object sender, TapEventArgs tapEventArgs)
        {
            var listView = (MultiLevelListView)Parent;
            listView.OnItemTapped(Item);
        }

        public MultiLevelItemBase Item
        {
            get { return (MultiLevelItemBase)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public static BindableProperty ItemProperty =
            BindableProperty.Create("Item", typeof(MultiLevelItemBase), typeof(MrGestureTestCell), null);
    }
}