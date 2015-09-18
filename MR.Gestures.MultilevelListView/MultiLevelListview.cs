using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace MR.Gestures
{
    public class MultiLevelListview : TableView
    {
        /// <summary>
        ///     Flattened source
        /// </summary>
        private List<MultiLevelListViewCellBase> _flattened = new List<MultiLevelListViewCellBase>();

        /// <summary>
        ///     Tree source
        /// </summary>
        private List<MultiLevelListViewCellBase> _source = new List<MultiLevelListViewCellBase>();

        public MultiLevelListview()
        {
            PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        ///     Tree source
        /// </summary>
        public IEnumerable<MultiLevelListViewCellBase> Source
        {
            get { return _source; }
            set
            {
                _source = value as List<MultiLevelListViewCellBase>;
                OnPropertyChanged();
            }
        }

        public List<MultiLevelListViewCellBase> SelectedCells
        {
            get
            {
                var selected = new List<MultiLevelListViewCellBase>();
                foreach (var cellBase in _flattened)
                {
                    if (cellBase.IsSelected)
                    {
                        selected.Add(cellBase);
                    }
                }
                return selected;
            }
        }

        public bool IsFiltering { get; set; }

        /// <summary>
        ///     Clear filter result
        /// </summary>
        public void ClearFilter()
        {
            IsFiltering = false;
            var visibleCells = GetVisibleCell();
            LoadSource(visibleCells);
        }

        /// <summary>
        ///     Collapse all cells
        /// </summary>
        public void CollapseAll()
        {
            foreach (var cell in _source)
            {
                cell.Collapse();
            }
        }

        /// <summary>
        ///     Expand all cells
        /// </summary>
        public void ExpandAll()
        {
            foreach (var cell in _source)
            {
                cell.ExpandAll();
            }
        }

        /// <summary>
        ///     Filter list, result will show as normal list
        /// </summary>
        /// <param name="compareFunc"></param>
        public void Filter(Func<MultiLevelListViewCellBase, bool> compareFunc)
        {
            IsFiltering = true;
            var visileCells = new List<MultiLevelListViewCellBase>();
            foreach (var @base in _flattened)
            {
                if (compareFunc(@base))
                {
                    visileCells.Add(@base);
                }
            }

            LoadSource(visileCells);
        }

        /// <summary>
        ///     Cell visible toggle handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void CellBaseOnVisibleToggled(object sender, EventArgs eventArgs)
        {
            if (IsFiltering) return;

            var visibleCells = GetVisibleCell();
            LoadSource(visibleCells);
        }

        /// <summary>
        ///     Clear visible toggle event
        /// </summary>
        private void ClearSourceEvents()
        {
            foreach (var cell in _flattened)
            {
                cell.ClearVisibleToggledEvent();
                cell.VisibleToggled += CellBaseOnVisibleToggled;
            }
        }

        /// <summary>
        ///     Flatten tree
        /// </summary>
        /// <param name="roots"></param>
        /// <returns></returns>
        private List<MultiLevelListViewCellBase> Flatten(List<MultiLevelListViewCellBase> roots)
        {
            var root = new MultiLevelListViewCellBase();

            root.Children.AddRange(roots);
            var flattened = Flatten(root);
            flattened.Remove(root);
            return flattened;
        }

        /// <summary>
        ///     Flatten tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static List<MultiLevelListViewCellBase> Flatten(MultiLevelListViewCellBase root)
        {
            var flattened = new List<MultiLevelListViewCellBase> {root};

            var children = root.Children;

            if (children != null)
            {
                foreach (var child in children)
                {
                    flattened.AddRange(Flatten(child));
                }
            }

            return flattened.ToList();
        }

        /// <summary>
        ///     Get cells to display
        /// </summary>
        /// <returns></returns>
        private List<MultiLevelListViewCellBase> GetVisibleCell()
        {
            var list = new List<MultiLevelListViewCellBase>();
            // Mark root
            foreach (var source in _source)
            {
                source.IsRoot = true;
            }

            // Get visible cells
            foreach (var cellBase in _flattened)
            {
                if (cellBase.IsRoot || cellBase.IsVisible)
                {
                    list.Add(cellBase);
                }
            }
            return list;
        }

        /// <summary>
        ///     Display source
        /// </summary>
        /// <param name="source"></param>
        private void LoadSource(List<MultiLevelListViewCellBase> source)
        {
            var section = new TableSection();

            foreach (var cell in source)
            {
                section.Add(cell);
            }

            Root = new TableRoot
            {
                section
            };
        }

        /// <summary>
        ///     Check if source is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Source")
            {
                // Collapse new source
                CollapseAll();
                // flatten new source
                _flattened = Flatten(_source);
                // clear source events
                ClearSourceEvents();
                // display new source
                var visibleCells = GetVisibleCell();
                LoadSource(visibleCells);
            }
        }
    }
}