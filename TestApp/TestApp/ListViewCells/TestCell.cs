using Xamarin.Forms;

namespace TestApp.ListViewCells
{
    public class TestCell : ViewCell
    {
        public TestCell()
        {
            var nameLabel = new Label();
            nameLabel.SetBinding(Label.TextProperty, "Name");

            View = nameLabel;
        }
    }
}
