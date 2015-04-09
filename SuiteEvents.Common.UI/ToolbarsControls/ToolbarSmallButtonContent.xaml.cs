using System.Windows.Media;

namespace SuiteEvents.Common.UI.ToolbarsControls
{
    /// <summary>
    /// Interaction logic for ToolbarSmallButtonContent.xaml
    /// </summary>
    public partial class ToolbarSmallButtonContent
    {
        public ToolbarSmallButtonContent()
        {
            InitializeComponent();
        }

        public Geometry PathData
        {
            set { this.IconPath.Data = value; }
        }
    }
}
