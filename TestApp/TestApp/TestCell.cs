using MultiLevelListview;
using Xamarin.Forms;

namespace TestApp
{
    internal class TestCell : MultiLevelListViewCellBase
    {
        public TestCell(string text)
        {
            View = Label = new Label
            {
                Text = text
            };
        }

        public TestCell()
        {
        }

        protected Label Label { get; set; }

        public string Text
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }
    }
}