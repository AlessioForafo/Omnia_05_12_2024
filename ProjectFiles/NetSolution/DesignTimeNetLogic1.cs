#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Recipe;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.OPCUAServer;
using FTOptix.CODESYS;
using FTOptix.CoreBase;
using FTOptix.Retentivity;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.Alarm;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void GenerateMyAlarms()
    {
        var v1 = Project.Current.GetVariable("Model/Variable1");

        // Get Alarms folder
        var alarmsFolder = Project.Current.Get<Folder>("Alarms");
        alarmsFolder.Children.Clear();
        // Generate MyAlarms folder
        var myAlarmsFolder = InformationModel.Make<Folder>("MyAlarms");
        // Add MyAlarms folder to Alarms folder
        alarmsFolder.Add(myAlarmsFolder);

        //Generate 100 alarms

        for (int i = 0; i < 100; i++)
        {
            var myAl = InformationModel.Make<DigitalAlarm>("MyDAL_" + i);
            myAl.InputValueVariable.SetDynamicLink(v1, DynamicLinkMode.ReadWrite);
            // for each alarm add it to MyAlarms folder
            myAlarmsFolder.Add(myAl);
        }

    }
}
