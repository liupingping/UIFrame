using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AssetHandler
{
    public delegate void AssetLoadHandlerWithUserData(
        bool sucessed, string path, UnityEngine.Object assetObject, object userData = null);

    public delegate void AssetLoadHandler(string path, UnityEngine.Object assetObject);

    public delegate void LoadCallbackFunc(AssetLoadAgent resAgent);

    // 资源文件路径
    private readonly string assetPath = null;

    // 加载状态
    //private ResourceLoadStage loadStage = ResourceLoadStage.Unloaded;

    // 标记卸载的时间
    public float unloadTime = 0;

    // 资源对象
    public UnityEngine.Object assetObject = null;

    // 所属的bundle
    private AssetBundleLoadAgent bundleLoadAgent = null;

    // Load Agents
    private List<AssetLoadAgent> loadAgents = new List<AssetLoadAgent>();

    // 尚未通知的回调
    private List<AssetLoadAgent> uncalledAgents = new List<AssetLoadAgent>();

    private int referenceCount = 0;
}
