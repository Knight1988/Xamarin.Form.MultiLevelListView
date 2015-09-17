## Xamarin.MultiLevelListView

### Useage:
Create cell by inherit from MultiLevelListViewCellBase
customize your cell by assit controls to View
ex:
``` C#
	View = Label =new Label {Text = "Test"};
```

Create a list of cell. Subs cell go to Children property
ex:
```C#
      var cells = new List<TestCell();
      for (int i = 0; i < 12; i++)
      {
        var root = new TestCell("Test " + i);
        cells.Add(root);
        
        for (int j = 0; j < 12; j++)
        {
          var cell1 = new TestCell(string.Format("Test {0}-{1}", i, j));
          root.Children.Add(cell1);
          
          for (int k = 0; k < 12; k++)
          {
            var cell2 = new TestCell(string.Format("Test {0}-{1}-{2}", i, j, k));
            cell1.Children.Add(cell2);
          }
        }
      }
```
  
then add to Source: 
``` C#
	lv.Source = cells;
```

using following code to create filter
``` C#
  lv.Filter(@base =>
  {
    var test = (TestCell) @base;
    return test.Text.Contains("1");
  });
```
use clearfilter when done.
``` C#
	lv.ClearFilter();
```
