using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AppPanel : MonoBehaviour 
{

	private AppInfo appInfo;

	private string appName;

	private object data;

	private string openTable;

	private bool isAppShowIng;


    protected List<IEnumerator> loadCoroutines = new List<IEnumerator>();
    protected AssetLoadAgent prefabAssetLoadAgent; // 界面预设的资源
    protected AssetLoadAgent colliderLoadAgent;     // 碰撞框的资源

    protected Transform m_uiTrans;          //> 界面根节点的transform
    protected IUIRef m_uiRoot;           //> 界面根节点绑定的脚本（GreatWall.UI.dll上的引用脚本）

	public AppPanel(AppInfo info)
	{
		this.appInfo = info;
		appName = info.AppName;
	}

        

	public void setup()
	{
        AppLoadManager.instance().loadByUrl("UIAchievement", "111", onComplete);
	}

	public void init(object data, string openTable)
	{
		this.data = data;
		this.openTable = openTable;


	}

       

    private void onComplete(GameObject obj)
    {
        if (obj != null)
        {
            //> 获得界面Root
            m_uiTrans = Instantiate(obj).transform;
            //> 新界面放置到主界面下面
            m_uiTrans.gameObject.name = "";
            m_uiTrans.parent = UIManager.ins.UIRootTransform;
            m_uiTrans.localPosition = new Vector3(0, 0, 0);
            m_uiTrans.localRotation = Quaternion.identity;
            m_uiTrans.localScale = Vector3.one;
            //> 获取UIRoot上绑定的Ref组件
            m_uiRoot = m_uiTrans.GetComponent<UIRef>().Ref;
        }
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
}
