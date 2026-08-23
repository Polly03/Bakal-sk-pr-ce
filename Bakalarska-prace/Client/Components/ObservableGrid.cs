using System.Windows.Controls;
using System.Windows;

namespace Bakalarska_prace.Components
{
    public class ObservableGrid : Grid
    {
        public event EventHandler? ChildrenChanged;

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            ChildrenChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
