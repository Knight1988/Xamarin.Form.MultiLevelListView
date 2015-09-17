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
            View = new Label()
            {
                Text = text
            };
        }

        public TestCell()
        {
        }
    }
}
