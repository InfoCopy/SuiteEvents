using System.Windows.Media;

namespace SuiteEvents.Common.UI.ToolbarsControls
{
    /// <summary>
    /// Interaction logic for ToolbarButtonContent.xaml
    /// </summary>
    public partial class ToolbarButtonContent
    {
        public ToolbarButtonContent()
        {
            InitializeComponent();
        }

        public Geometry PathData
        {
            set { this.IconPath.Data = value; }
        }
    }
}
