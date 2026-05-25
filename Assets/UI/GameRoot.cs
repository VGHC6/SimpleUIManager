using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private UIManager UImanager;
    public UIManager UImanagerRoot { get => UImanager; }

    private static GameRoot instance;
    public static GameRoot GetInstance()
    {
        if(instance == null)
        {
            Debug.LogError("GameRoot is null");
            return instance;
        }
        return instance;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        UImanager = new UIManager();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        UImanagerRoot.CanvasObj=UItools.GetInstance().FindCanvas();
        //Õ∆»Î
        UImanagerRoot.push(new StartPanel());

    }
}
