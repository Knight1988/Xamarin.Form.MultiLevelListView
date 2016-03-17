using MR.Gestures;
using BindableObjectExtensions = Xamarin.Forms.BindableObjectExtensions;

namespace TestApp.ListViewCells
{
    public class MrGestureTestCell : MultiLevelListViewCell
    {
        public MrGestureTestCell()
        {
            var nameLabel = new Label();
            BindableObjectExtensions.SetBinding(nameLabel, Xamarin.Forms.Label.TextProperty, "Name");

            View = nameLabel;
        }
    }
}