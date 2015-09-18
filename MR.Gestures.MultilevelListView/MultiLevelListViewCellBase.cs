using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MR.Gestures
{
    public class MultiLevelListViewCellBase : ViewCell
    {
        /// <summary>
        ///     Children cell
        /// </summary>
        private List<MultiLevelListViewCellBase> _children = new List<MultiLevelListViewCellBase>();

        /// <summary>
        ///     True - Collapse
        ///     False - Expand
        /// </summary>
        private bool _isCollapse;

        /// <summary>
        ///     Check if cell is selected (use for Checkbox, Selection cells)
        /// </summary>
        private bool _isSelected;

        /// <summary>
        ///     Check if cell is visible
        /// </summary>
        private bool _isVisible = true;

        public MultiLevelListViewCellBase()
        {
            PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        ///     Check if cell is selected (use for Checkbox, Selection cells)
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Check if cell is root
        /// </summary>
        internal bool IsRoot { get; set; }

        /// <summary>
        ///     Check if cell is visible
        /// </summary>
        internal bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        /// <summary>
        ///     Children cells
        /// </summary>
        public IEnumerable<MultiLevelListViewCellBase> Children
        {
            get { return _children; }
            set { _children = value.ToList(); }
        }

        /// <summary>
        ///     True - Collapse
        ///     False - Expand
        /// </summary>
        protected bool IsCollapse
        {
            get { return _isCollapse; }
            set
            {
                _isCollapse = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Add child
        /// </summary>
        /// <param name="cell"></param>
        public void AddChild(MultiLevelListViewCellBase cell)
        {
            _children.Add(cell);
        }

        /// <summary>
        ///     Remove toggle event
        /// </summary>
        public void ClearVisibleToggledEvent()
        {
            VisibleToggled = null;
        }

        /// <summary>
        ///     Collapse cell
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
        ///     Expand cell
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
        ///     Expand all sub cell
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
        ///     Toggle cell visiblility
        /// </summary>
        public void VisibleToggle()
        {
            if (IsCollapse) Expand();
            else Collapse();

            OnVisibleToggled();
        }

        /// <summary>
        ///     OnTapping handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tapEventArgs"></param>
        protected void OnTapping(object sender, TapEventArgs tapEventArgs)
        {
            VisibleToggle();
        }

        /// <summary>
        ///     Trigger visible toggle event
        /// </summary>
        protected virtual void OnVisibleToggled()
        {
            var handler = VisibleToggled;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "View" && View != null)
            {
                var layout = View as IGestureAwareControl;
                if (layout != null) layout.Tapping += OnTapping;
            }
        }

        /// <summary>
        ///     Trigger on visibe toggled
        /// </summary>
        public event EventHandler VisibleToggled;
    }
}