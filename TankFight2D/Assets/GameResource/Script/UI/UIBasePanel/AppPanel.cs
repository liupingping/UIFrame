using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppPanel : MonoBehaviour {

	private AppInfo appInfo;

	private string appName;

	private object data;

	private string openTable;

	private bool isAppShowIng;

	protected AssetLoadAgent prefabAssetLoadAgent;

	public AppPanel(AppInfo info)
	{
		this.appInfo = info;
		appName = info.AppName;


	}

	public void setup()
	{


	}

	public void init(object data, string openTable)
	{
		this.data = data;
		this.openTable = openTable;


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
