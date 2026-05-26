using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItools
{
    private static UItools instance;//单例结构
    public static UItools GetInstance()
    {
        if (instance == null)
        {
            instance = new UItools();
        }
        return instance;
    }


    /// <summary>
    /// 获得Canvas
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject == null)
        {
            Debug.LogError("Canvas is null");
        }
        return gameObject;
    }

    /// <summary>
    /// 找到一个组件
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject FindObjectChild(GameObject panel, string name)
    {
        Transform[] transform = panel.GetComponentsInChildren<Transform>();
        foreach (var item in transform)
        {
            if (item.name == name)
            {
                return item.gameObject;
            }
        }
        Debug.LogError("can not find " + name);
        return null;
    }


    /// <summary>
    /// 【新增】获取组件，没有则自动添加
    /// </summary>
    /// <param name="target">目标游戏物体</param>
    /// <typeparam name="T">组件类型（Button/Image/Text等）</typeparam>
    /// <returns>组件实例</returns>
    public T GetOrAddComponent<T>(GameObject target) where T : Component
    {
        // 空物体判断
        if (target == null)
        {
            Debug.LogError($"GetOrAddComponent 目标物体为空！组件类型：{typeof(T)}");
            return null;
        }

        // 尝试获取组件
        T component = target.GetComponent<T>();

        // 没有则添加组件
        if (component == null)
        {
            component = target.AddComponent<T>();
            Debug.Log($"自动添加组件：{typeof(T)} 到物体：{target.name}");
        }

        return component;
    }

    /// <summary>
    /// 先查找子物体，再获取或添加组件
    /// </summary>
    /// <param name="parent">父物体</param>
    /// <param name="childName">子物体名称</param>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns>组件</returns>
    public T GetOrAddComponent<T>(GameObject parent, string childName) where T : Component
    {
        // 1. 自动查找子物体（复用你原有的 FindObjectChild）
        GameObject childObj = FindObjectChild(parent, childName);

        // 2. 调用原有方法，获取/添加组件
        return GetOrAddComponent<T>(childObj);
    }
}


