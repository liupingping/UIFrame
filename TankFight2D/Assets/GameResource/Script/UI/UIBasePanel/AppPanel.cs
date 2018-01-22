using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AppPanel : MonoBehaviour {

	private AppInfo appInfo;

	private string appName;

	private object data;

	private string openTable;

	private bool isAppShowIng;

    protected IUIRef m_uiRoot;           //> 界面根节点绑定的脚本（GreatWall.UI.dll上的引用脚本）


    protected List<IEnumerator> loadCoroutines = new List<IEnumerator>();
    protected AssetLoadAgent prefabAssetLoadAgent; // 界面预设的资源
    protected AssetLoadAgent colliderLoadAgent;     // 碰撞框的资源

	public AppPanel(AppInfo info)
	{
		this.appInfo = info;
		appName = info.AppName;


	}

	public void setup()
	{


        //加载资源
        IEnumerator enumerator = _AssembleUIPrefab(onComplete);
        loadCoroutines.Add(enumerator);
        CoroutineHelper.ins.StartTrackedCoroutine(enumerator);
	}

	public void init(object data, string openTable)
	{
		this.data = data;
		this.openTable = openTable;


	}

    private void onComplete()
    {
        

    }


	public void show()
	{



       
	    

	}

	public void hide()
	{


	}

	public bool getIsAppShowIng()
	{
		return isAppShowIng;
	}


    /// <summary>
    /// >组装界面prefab
    /// </summary>
    /// <returns></returns>
    private IEnumerator _AssembleUIPrefab(Action onAsyncFinish)
    {

        IEnumerator enumerator = _PopulateUIRoot();
        loadCoroutines.Add(enumerator);
        yield return CoroutineHelper.ins.StartTrackedCoroutine(enumerator);

        if (onAsyncFinish != null)
        {
            onAsyncFinish();
        }

    }

    protected Transform m_uiTrans;          //> 界面根节点的transform

    private IEnumerator _PopulateUIRoot()
    {


        string resName = "";

        while (!prefabAssetLoadAgent.IsDone)
        {
            yield return null;
        }


        GameObject obj = (GameObject)prefabAssetLoadAgent.AssetObject;
        if (obj == null)
        {
            Debug.LogError("UI prefab not found: " + resName);
            yield break; 
        }


        //> 获得界面Root
        m_uiTrans = UnityEngine.Object.Instantiate(obj).transform;
        if (null == m_uiTrans)
        {
            Debug.LogError("Invalid UI prefab: " + resName);
        }

        //> 新界面放置到主界面下面
        m_uiTrans.gameObject.name = "";//szSceneName;
        m_uiTrans.parent = UIManager.ins.UIRootTransform;
        m_uiTrans.localPosition = new Vector3(0, 0, 0);
        m_uiTrans.localRotation = Quaternion.identity;
        m_uiTrans.localScale = Vector3.one;

        m_uiRoot = m_uiTrans.GetComponent<UIRef>().Ref;


    }

}
