using FairyGUI;
using UnityEngine;

public class Lesson7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //方法一
        //加载UI包  //AddPackage会先使用传入的路径作为Key进行检测，如果这个包已经添加了 不会重复添加
     UIPackage teachPackage= UIPackage.AddPackage("UI/Component1");
        //遍历依赖包相关信息
        foreach(var item in teachPackage.dependencies)
        {
            //这样可以获取到 依赖包的名字
            UIPackage.AddPackage(item["name"]);
        }

        //方法二：从两个AB包中加载
        //AddPackage没有排重检测机制，需要自己判断A
        AssetBundle resAB = null;
        AssetBundle byteAB = null;
        UIPackage.AddPackage(byteAB, resAB);




        //卸载UI包
        //包卸载后，所有包里的贴图等资源会被卸载，创建出来的组件也无法显示
        //一般不建议进行频繁卸载和加载，会消耗CPU和产生大量GC
        UIPackage.RemovePackage("Component1");
        UIPackage.RemoveAllPackages();




        //包内存管理
        //1.AddPackage 只有用到才会载入贴图、声音等资源
        //如果需要提前全部载入
        teachPackage.LoadAllAssets();

        //2.如果UIPakcage是从AB包中加载的，在RemovePackage时AB包才会被Unload(true)
        //如果你确认所有的资源都已经载入了，也可以自行卸载AB包
        //如果你的AB包是自行管理的，不希望FairyGUI处理，可以做以上设置
        UIPackage.unloadBundleByFGUI=false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
