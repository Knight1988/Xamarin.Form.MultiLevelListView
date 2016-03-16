using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestApp.Pages
{
    public partial class MenuPage : ContentPage
    {

        public MenuPage()
        {
            InitializeComponent();
        }

        private async void MultiLevelListViewPageButtonOnClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new MultiLevelListViewPage());
        }

        private async void MrGestureMultiLevelListViewPageButtonOnClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new MrGestureMultiLevelListViewPage());
        }
    }
}
