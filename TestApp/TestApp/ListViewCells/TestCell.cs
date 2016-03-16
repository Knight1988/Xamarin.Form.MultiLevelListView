using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp
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
