
using Autodesk.Revit.UI;
using System;
using System.Reflection;

namespace RevitWpfDashboard
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            string tabName = "Aditya Tools";

            try { app.CreateRibbonTab(tabName); }
            catch { }
            //Ribbon Creation
            RibbonPanel panel = app.CreateRibbonPanel(tabName, "File Manager");

            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData btn = new PushButtonData(
                "DashboardBtn",
                "Import / Export",
                assemblyPath,
                "RevitWpfDashboard.Command"
            );

            panel.AddItem(btn);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }
    }
}
