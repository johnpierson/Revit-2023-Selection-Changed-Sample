#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using adWin = Autodesk.Windows;
#endregion

namespace SelectionChangedSample
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            //subscribe to the selection changed event
            a.SelectionChanged += OnSelectionChanged;

            return Result.Succeeded;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adWin.ComponentManager.Ribbon.RenderTransform = new System.Windows.Media.RotateTransform(e.GetSelectedElements().Count);
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
