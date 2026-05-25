using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public Dictionary<string, GameObject> Dic_uiObject;//UI对象字典
    public Stack<BasePannel> stack_ui;//UI栈
    public GameObject CanvasObj;//画布
    public Dictionary<string, CanvasGroup> canvasGroup;//画布组

    private static UIManager instance;//单例

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("UIManager is null");
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public UIManager() {
        Dic_uiObject = new Dictionary<string, GameObject>();
        stack_ui = new Stack<BasePannel>();
        CanvasObj = UItools.GetInstance().FindCanvas();
        // 初始化 CanvasGroup 画布分组
        InitCanvasGroup();
    }

    private void InitCanvasGroup()
    {
        canvasGroup = new Dictionary<string, CanvasGroup>();
        // 创建主UI分组
        GameObject mainGroup = new GameObject("MainUIGroup");
        mainGroup.transform.SetParent(CanvasObj.transform, false);
        CanvasGroup group = mainGroup.AddComponent<CanvasGroup>();
        canvasGroup.Add("Main", group);
    }


    public void push(BasePannel pannel)
    {
        if (stack_ui.Count > 0)
        {
            stack_ui.Peek().OnDisable();
        }

        GameObject BasePanle_pushObj = GetSingleObject(pannel.Uitype);
        Dic_uiObject.Add(pannel.Uitype.Name, BasePanle_pushObj);
        pannel.ActivityObj = BasePanle_pushObj;

        if (stack_ui.Count == 0)
        {
            stack_ui.Push(pannel);
        }
        else
        {
            if (stack_ui.Peek().Uitype.Name != pannel.Uitype.Name)
            {//如果栈顶的UI类型和要入栈的UI类型不一样，则入栈
                stack_ui.Push(pannel);
            }
        }

        pannel.OnStart();
    }


    /// <summary>
    /// 出栈
    /// </summary>
    /// <param name="is_isload"></param>
    public void pop(bool is_isload)
    {
        if (is_isload)
        {
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();//栈顶的UI对象禁用
                stack_ui.Peek().OnDestroy();//销毁栈顶的UI对象
                GameObject.Destroy(Dic_uiObject[stack_ui.Peek().Uitype.Name]);//销毁栈顶的UI对象
                Dic_uiObject.Remove(stack_ui.Peek().Uitype.Name);//移除栈顶的UI对象
                stack_ui.Pop();//出栈
                pop(true);//继续出栈,递归直到栈为空或者栈顶的UI类型和要入栈的UI类型一样
            }
        }
        else
        {
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();//栈顶的UI对象禁用
                stack_ui.Peek().OnDestroy();//销毁栈顶的UI对象
                GameObject.Destroy(Dic_uiObject[stack_ui.Peek().Uitype.Name]);//销毁栈顶的UI对象
                Dic_uiObject.Remove(stack_ui.Peek().Uitype.Name);//移除栈顶的UI对象
                stack_ui.Pop();//出栈
                if (stack_ui.Count > 0)
                {
                    stack_ui.Peek().OnEnable();//栈顶的UI对象启用
                }
            }
        }
    }

    public GameObject GetSingleObject(UItype uitype)
    {
        if (Dic_uiObject.ContainsKey(uitype.Name))
        {
            return Dic_uiObject[uitype.Name];
        }

        if (CanvasObj == null)
        {
            CanvasObj = UItools.GetInstance().FindCanvas();
        }

        // 增加空值检查 + 日志提示
        GameObject prefab = Resources.Load<GameObject>(uitype.Path);
        if (prefab == null)
        {
            Debug.LogError($"Resources加载失败！路径：{uitype.Path}，请检查：1.路径是否正确 2.预制体是否在Resources目录下 3.预制体名称是否匹配", CanvasObj);
            return null;
        }

        GameObject obj = GameObject.Instantiate(prefab, CanvasObj.transform);
        obj.name = uitype.Name; // 可选：统一实例化后的对象名称，避免带"(Clone)"后缀
        return obj;
    }
}
