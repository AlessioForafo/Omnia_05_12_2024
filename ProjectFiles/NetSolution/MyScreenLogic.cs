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

public class MyScreenLogic : BaseNetLogic
{
    public override void Start()
    {
        Log.Info("Hello! " + Owner.BrowseName);
        Log.Info("Screens in /Screen folder are:" + Owner.Owner.Children.Count);

        
    }

    public override void Stop()
    {
        Log.Info("Bye");
    }
}
