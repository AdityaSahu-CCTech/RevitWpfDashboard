using System.Windows;
using Microsoft.Win32;                 // For OpenFileDialog
using System.Windows.Forms;   // For FolderBrowserDialog
using Autodesk.Revit.UI;

namespace RevitWpfDashboard
{
    public partial class DashboardUI : Window
    {
        public DashboardUI()
        {
            InitializeComponent();
        }

        // ================= IMPORT BUTTON =================
        
        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            RevitRequestHandler.CurrentAction = RevitAction.ImportFile;
            Command.ExEvent.Raise();
        }
        // ================= EXPORT BUTTON =================
 
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            RevitRequestHandler.CurrentAction = RevitAction.ExportFile;
            Command.ExEvent.Raise();
        }
    }
}