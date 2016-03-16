using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp.Pages
{
    partial class MenuPage
    {
        private Button multiLevelListViewPageButton;
        private Button mrGestureMultiLevelListViewPageButton;
        private StackLayout layout;

        private void InitializeComponent()
        {
            multiLevelListViewPageButton = new Button();
            mrGestureMultiLevelListViewPageButton = new Button();
			layout = new StackLayout();

            // multiLevelListViewPageButton
            multiLevelListViewPageButton.Text = "MultiLevelListView";
            multiLevelListViewPageButton.Clicked += MultiLevelListViewPageButtonOnClicked;
            // mrGestureMultiLevelListViewPageButton
            mrGestureMultiLevelListViewPageButton.Text = "MR.Gesture.MultiLevelListView";
            mrGestureMultiLevelListViewPageButton.Clicked += MrGestureMultiLevelListViewPageButtonOnClicked;
            // layout
            layout.Children.Add(multiLevelListViewPageButton);
            layout.Children.Add(mrGestureMultiLevelListViewPageButton);
            // MenuPage
            Content = layout;
        }
    }
}
