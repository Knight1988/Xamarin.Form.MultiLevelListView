using System;
using System.Collections.Generic;
using MR.Gestures;
using Xamarin.Forms;
using Grid = Xamarin.Forms.Grid;
using Image = MR.Gestures.Image;
using Label = Xamarin.Forms.Label;
using ViewCell = Xamarin.Forms.ViewCell;

namespace TestApp.ListViewCells
{
    public class TestCell : ViewCell
    {
        private Image imageLabel;

        public TestCell()
        {
            var nameLabel = new Label();
            nameLabel.SetBinding(Label.TextProperty, "Name");

            imageLabel = new Image();
            imageLabel.WidthRequest = 50;
            imageLabel.Source = PhoneCallImage;
            imageLabel.Up += ImageLabelOnUp;
            imageLabel.Down += ImageLabelOnDown;

            var grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition
                    {
                        
                    },
                    new ColumnDefinition
                    {
                        Width = GridLength.Auto
                    },
                }
            };
            grid.Children.Add(nameLabel, 0, 0);
            grid.Children.Add(imageLabel, 1, 0);
            View = grid;
        }

        private void ImageLabelOnDown(object sender, DownUpEventArgs downUpEventArgs)
        {
            imageLabel.Source = PhoneCallingImage;
        }

        private void ImageLabelOnUp(object sender, DownUpEventArgs downUpEventArgs)
        {
            imageLabel.Source = PhoneCallImage;
        }

        public static ImageSource PhoneCallImage => ImageSource.FromResource("TestApp.Images.PhoneCall.png");
        public static ImageSource PhoneCallingImage => ImageSource.FromResource("TestApp.Images.PhoneCalling.png");
    }
}
