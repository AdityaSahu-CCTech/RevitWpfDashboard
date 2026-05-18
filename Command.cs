
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitWpfDashboard
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static ExternalEvent ExEvent;
        public static RevitRequestHandler Handler;

        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            if (Handler == null)
            {
                Handler = new RevitRequestHandler();
                ExEvent = ExternalEvent.Create(Handler);
            }

            DashboardUI ui = new DashboardUI();
            ui.Show();

            return Result.Succeeded;
        }
    }
}