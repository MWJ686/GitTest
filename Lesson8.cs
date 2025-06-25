using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    public UIPanel panel;
    // Start is called before the first frame update
    void Start()
    {
        //首先加载对应的UI包
        UIPackage.AddPackage("UI/Package1");
        GameObject obj = new GameObject("UIPanel2");
        obj.layer = LayerMask.NameToLayer("UI");
        UIPanel panel = obj.AddComponent<UIPanel>();
        //设置关键属性
        panel.packageName = "Package1";
        panel.componentName = "Component1";

        //创建ui
        panel.CreateUI();

        //想要改变别的参数属性
        panel.container.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
