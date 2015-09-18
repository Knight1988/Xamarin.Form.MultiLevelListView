using System;
using System.Collections.Generic;
using System.Linq;

namespace MR.Gestures
{
    public class MultiLevelListViewCellBase : ViewCell
    {
        /// <summary>
        /// Children cell
        /// </summary>
        private List<MultiLevelListViewCellBase> _children = new List<MultiLevelListViewCellBase>();
        /// <summary>
        /// Check if cell is visible
        /// </summary>
        private bool _isVisible = true;
        /// <summary>
        /// Check if cell is selected (use for Checkbox, Selection cells)
        /// </summary>
        public bool IsSelected { get; set; }

        public MultiLevelListViewCellBase()
        {
            Tapped += OnTapped;
        }

        /// <summary>
        /// Check if cell is root
        /// </summary>
        internal bool IsRoot { get; set; }

        /// <summary>
        /// Check if cell is visible
        /// </summary>
        internal bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        /// <summary>
        /// Children cells
        /// </summary>
        public IEnumerable<MultiLevelListViewCellBase> Children
        {
            get { return _children; }
            set { _children = value.ToList(); }
        }

        /// <summary>
        /// Add child
        /// </summary>
        /// <param name="cell"></param>
        public void AddChild(MultiLevelListViewCellBase cell)
        {
            _children.Add(cell);
        }

        /// <summary>
        /// True - Collapse
        /// False - Expand
        /// </summary>
        protected bool IsCollapse { get; set; }

        /// <summary>
        /// Remove toggle event
        /// </summary>
        public void ClearVisibleToggledEvent()
        {
            VisibleToggled = null;
        }

        /// <summary>
        /// Collapse cell
        /// </summary>
        public void Collapse()
        {
            foreach (var child in Children)
            {
                // Ẩn cell con
                child.IsVisible = false;
                // Cẩn các sub cell
                child.Collapse();
            }

            IsCollapse = true;
        }

        /// <summary>
        /// Expand cell
        /// </summary>
        public void Expand()
        {
            foreach (var child in Children)
            {
                child.IsVisible = true;
            }

            IsCollapse = false;
        }

        /// <summary>
        /// Expand all sub cell
        /// </summary>
        public void ExpandAll()
        {
            foreach (var child in Children)
            {
                child.Expand();
                child.ExpandAll();
            }
        }

        /// <summary>
        /// Toggle cell visiblility
        /// </summary>
        public void VisibleToggle()
        {
            if (IsCollapse) Expand();
            else Collapse();

            OnVisibleToggled();
        }

        /// <summary>
        /// Trigger visible toggle event
        /// </summary>
        protected virtual void OnVisibleToggled()
        {
            var handler = VisibleToggled;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// OnTapped handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnTapped(object sender, EventArgs eventArgs)
        {
            VisibleToggle();
        }

        /// <summary>
        /// Trigger on visibe toggled
        /// </summary>
        public event EventHandler VisibleToggled;
    }
}