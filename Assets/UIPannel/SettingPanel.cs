using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePannel
{
    private static string name= "Setting";
    private static string path = "Setting";
    public static readonly UItype uItype=new UItype(path,name);
    public SettingPanel() : base(uItype)
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
        Debug.Log("StartPanel OnDisable");
        base.OnDisable();
    }
}
