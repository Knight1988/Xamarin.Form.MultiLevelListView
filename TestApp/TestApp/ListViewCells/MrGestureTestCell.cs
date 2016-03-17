using MR.Gestures;
using MR.Gestures.MultilevelListView;
using Xamarin.Forms;
using Label = MR.Gestures.Label;
using ViewCell = MR.Gestures.ViewCell;

namespace TestApp.ListViewCells
{
    public class MrGestureTestCell : ViewCell
    {
        public MrGestureTestCell()
        {
            var nameLabel = new Label();
            nameLabel.SetBinding(Xamarin.Forms.Label.TextProperty, "Name");

            View = nameLabel;
            nameLabel.Tapping += OnTapping;
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