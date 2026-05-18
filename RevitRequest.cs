using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;

namespace RevitWpfDashboard
{
    public enum RevitAction
    {
        None,
        ImportFile,
        ExportFile
    }

    public class RevitRequestHandler : IExternalEventHandler
    {
        public static RevitAction CurrentAction = RevitAction.None;

        public void Execute(UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc?.Document;

            try
            {
                // ================= IMPORT =================
                if (CurrentAction == RevitAction.ImportFile)
                {
                    Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                    dialog.Filter = "Revit Files (*.rvt;*.rfa)|*.rvt;*.rfa";

                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        string filePath = dialog.FileName;

                        // THIS IS THE CORRECT REVIT CALL
                        uiapp.OpenAndActivateDocument(filePath);
                    }
                }

                // ================= EXPORT =================
                if (CurrentAction == RevitAction.ExportFile)
                {
                    if (doc == null)
                    {
                        Autodesk.Revit.UI.TaskDialog.Show("Error", "No document open.");
                        return;
                    }

                    Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                    dialog.Filter = "Revit Project (*.rvt)|*.rvt";
                    dialog.FileName = doc.Title + "_Export";

                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        string savePath = dialog.FileName;

                        SaveAsOptions options = new SaveAsOptions();
                        options.OverwriteExistingFile = true;

                        doc.SaveAs(savePath, options);

                        Autodesk.Revit.UI.TaskDialog.Show("Success", "File exported successfully!");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Error", ex.Message);
            }

            CurrentAction = RevitAction.None;
        }

        public string GetName()
        {
            return "Revit Request Handler";
        }
    }
}