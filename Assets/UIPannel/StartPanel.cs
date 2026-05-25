using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartPanel : BasePannel
{
    private static string name="StartPanel";
    private static string path = "StartUI";
    public static readonly UItype uItype=new UItype(path,name);
    public StartPanel() : base(uItype)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }
}
