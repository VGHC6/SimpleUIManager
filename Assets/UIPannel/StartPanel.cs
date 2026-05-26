using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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
        UItools.GetInstance().GetOrAddComponent<Button>(ActivityObj, "Back").onClick.AddListener(Back);
        UItools.GetInstance().GetOrAddComponent<Button>(ActivityObj, "Setting").onClick.AddListener(Setting);
    }

    private void Back()
    {
        GameRoot.GetInstance().UImanagerRoot.pop(false);
    }

    private void Setting()
    {
        GameRoot.GetInstance().UImanagerRoot.push(new SettingPanel());//º”»ÎSetting
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
