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

public class RuntimeNetLogic2 : BaseNetLogic
{
    public override void Start()
    {
        Log.Info("Rectangle rendered");
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void ChangeColor(){
        ((Rectangle)Owner).FillColor = Colors.Lime;
        var led = Owner.Owner.Get<Led>("LED1");
        led.Color = Colors.Lime;
    }

    [ExportMethod]
    public void ChangeColorGoodPractice(){
        ((Rectangle)Owner).FillColor = Colors.Lime;
        var ledNodeId = LogicObject.GetVariable("LedToUpdate").Value;
        var led = InformationModel.Get<Led>(ledNodeId);
        led.Color = Colors.Lime;
    }
}
