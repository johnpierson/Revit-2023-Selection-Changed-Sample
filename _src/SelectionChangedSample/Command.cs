#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace SelectionChangedSample
{
    [Transaction(TransactionMode.Manual)]
    public class Protect : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            var selection = uidoc.Selection.PickObjects(ObjectType.Element);

            if (selection.Any())
            {
               Globals.ProtectedElementIds.AddRange(selection.Select(s => s.ElementId));
            }

          
            return Result.Succeeded;
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class NotProtect : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;


            var selection = uidoc.Selection.PickObjects(ObjectType.Element);

            if (selection.Any())
            {
                foreach (var s in selection)
                {
                    Globals.ProtectedElementIds.Remove(s.ElementId);
                }
                
            }


            return Result.Succeeded;
        }
    }
   
}
