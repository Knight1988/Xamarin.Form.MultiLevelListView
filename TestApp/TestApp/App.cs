using System.Collections.Generic;
using MultiLevelListview;
using Xamarin.Forms;

namespace TestApp
{
    public class App : Application
    {
        public App()
        {
            var lv = new MultiLevelListview<TestCell>();
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = lv
            };

            var cells = new List<TestCell>();
            for (var i = 0; i < 12; i++)
            {
                var root = new TestCell("Test " + i);
                cells.Add(root);

                for (var j = 0; j < 12; j++)
                {
                    var cell1 = new TestCell(string.Format("Test {0}-{1}", i, j));
                    root.Children.Add(cell1);

                    for (var k = 0; k < 12; k++)
                    {
                        var cell2 = new TestCell(string.Format("Test {0}-{1}-{2}", i, j, k));
                        cell1.Children.Add(cell2);
                    }
                }
            }

            lv.Source = cells;
            lv.Filter(@base =>
            {
                var test = (TestCell) @base;
                return test.Text.Contains("1");
            });
            //lv.ClearFilter();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}