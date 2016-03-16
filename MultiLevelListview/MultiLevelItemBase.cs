using System.Collections.Generic;

namespace MultiLevelListview
{
    public class MultiLevelItemBase
    {
        public List<MultiLevelItemBase> Children { get; set; } = new List<MultiLevelItemBase>();
        public bool IsExpand { get; internal set; }
        public string Name { get; set; }

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