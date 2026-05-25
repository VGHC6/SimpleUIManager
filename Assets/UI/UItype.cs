using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItype
{
    public string path;//ui路径
    public string Path { get => path; }//获取路径
    private string name;//ui名称
    public string Name { get => name; }//获取名称


    /// <summary>
    /// 获得ui路径和名称
    /// </summary>
    /// <param name="UiPath">Ui路径</param>
    /// <param name="UiName">Ui名称</param>
    public UItype(string UiPath, string UiName)
    {
        path = UiPath; // 确保赋值给path字段
        name = UiName; // 确保赋值给name字段
    }
}
