using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiLevelListview;
using Xamarin.Forms;

namespace TestApp
{
    class TestCell : MultiLevelListViewCellBase
    {
        public TestCell(string text)
        {
            View = Label =new Label()
            {
                Text = text
            };
        }

        protected Label Label { get; set; }

        public string Text
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        public TestCell()
        {
        }
    }
}
