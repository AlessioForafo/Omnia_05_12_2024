#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.Recipe;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.OPCUAServer;
using FTOptix.CODESYS;
using FTOptix.CoreBase;
using FTOptix.Retentivity;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
#endregion

public class MotorLogic : BaseNetLogic
{
    private IUAVariable checkTemp;
    private IUAVariable actualTemp;
    private PeriodicTask periodicTask;
    private LongRunningTask longRunningTask;

    public override void Start()
    {
        checkTemp = LogicObject.GetVariable("CheckTemp");
        actualTemp = LogicObject.GetVariable("ActualTemp");
        periodicTask = new PeriodicTask(CheckTemperature, 5000, LogicObject);

        longRunningTask = new LongRunningTask(MyCoolOperations, LogicObject);
        longRunningTask.Start();
    }

    private void MyCoolOperations()
    {
        Log.Warning("Starting difficult operations on: " + Owner.BrowseName);
    }

    private void CheckTemperature()
    {
        Log.Info("Checking temp: " + Owner.BrowseName);
    } 

    public override void Stop()
    {
        longRunningTask?.Dispose();
    }

    [ExportMethod]
    public void StartCheckTemp()
    {
        periodicTask.Start();
    }
    
    [ExportMethod]
    public void StopCheckTemp()
    {
        periodicTask.Dispose();
    }

}
