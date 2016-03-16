using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MR.Gestures
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