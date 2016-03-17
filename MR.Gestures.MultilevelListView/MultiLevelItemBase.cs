using System.Collections.Generic;

namespace MR.Gestures.MultilevelListView
{
    public class MultiLevelItemBase
    {
        public List<MultiLevelItemBase> Children { get; set; } = new List<MultiLevelItemBase>();
        public bool IsExpand { get; internal set; }
        public string Name { get; set; }
        public MultiLevelItemBase Item => this;

        public void Expand()
        {
            IsExpand = true;
        }

        public void Collapse()
        {
            IsExpand = false;
            foreach (var child in Children)
            {
                child.Collapse();
            }
        }
    }
}