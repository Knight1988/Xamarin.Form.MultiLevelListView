using System;
using MR.Gestures;
using BindableObjectExtensions = Xamarin.Forms.BindableObjectExtensions;
using BindableProperty = Xamarin.Forms.BindableProperty;

namespace TestApp
{
    public class MrGestureTestCell : ViewCell
    {
        public MrGestureTestCell()
        {
            var nameLabel = new Label();
            BindableObjectExtensions.SetBinding(nameLabel, Xamarin.Forms.Label.TextProperty, "Name");

            View = nameLabel;
            Tapping += OnTapping;
        }

        private void OnTapping(object sender, TapEventArgs tapEventArgs)
        {
        }

        public IMultiLevelListViewItem Item
        {
            get { return (IMultiLevelListViewItem)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        //public static BindableProperty ItemProperty =
        //    BindableProperty.Create<MrGestureTestCell, IMultiLevelListViewItem>(ctrl => ctrl.Item, null);

        public static BindableProperty ItemProperty =
            BindableProperty.Create("Item", typeof (MrGestureTestCell), typeof (IMultiLevelListViewItem), null);
    }

    public interface IMultiLevelListViewItem
    {
    }
}