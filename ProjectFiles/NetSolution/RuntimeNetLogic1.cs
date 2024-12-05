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
using System.Linq;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        Log.Info("my category", "Hello, Omnia!");
        var totalsNodes = Project.Current.Owner.FindNodesByType<IUANode>().ToList().Count();
        var totaAlarms = Project.Current.FindNodesByType<DigitalAlarm>().ToList().Count();
        Log.Info("Total project nodes: " + totalsNodes + " and total alarms: " + totaAlarms);
    }

    public override void Stop()
    {
        Log.Warning("App is closing ...");
    }
}
