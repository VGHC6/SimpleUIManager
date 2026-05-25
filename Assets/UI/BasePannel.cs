using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasePannel
{
    public UItype Uitype;
    public Object ActivityObj;//此panel在场景对应的物体

    /// <summary>
    /// 传入UItype
    /// </summary>
    /// <param name="uitype">UItype</param>
    public BasePannel(UItype uitype)
    {
        Uitype = uitype;
    }

    /// <summary>
    /// 四个生命周期函数，虚方法方便继承
    /// </summary>
    /// 
    public virtual void OnStart()
    {
        GameObject obj = ActivityObj as GameObject;
        if (obj != null)
        {
            UItools.GetInstance().GetOrAddComponent<CanvasGroup>(obj).interactable = true;
        }
    }
    public virtual void OnEnable()
    {
        GameObject obj = ActivityObj as GameObject;
        if (obj != null)
        {
            UItools.GetInstance().GetOrAddComponent<CanvasGroup>(obj).interactable = true;
        }
    }
    public virtual void OnDestroy()
    {
        GameObject obj = ActivityObj as GameObject;
        if (obj != null)
        {
            UItools.GetInstance().GetOrAddComponent<CanvasGroup>(obj).interactable = false;
        }
    }
    public virtual void OnDisable()
    {
        GameObject obj = ActivityObj as GameObject;
        if (obj != null)
        {
            UItools.GetInstance().GetOrAddComponent<CanvasGroup>(obj).interactable = false;
        }
    }
}
