using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppInfo {

	public string AppName;

	public string loadingTitle;

	public string resName;

	public string btnName;

	public bool isSpecialInCloseAll;

	public int appLoadType;

	public AppInfo(string moduleName,string resName,string loadingTitle,string btnName,bool isSpecialInCloseAll,
			int appLoadType)
	{
		this.AppName = moduleName;
		this.resName = resName;
		this.loadingTitle = loadingTitle;
		this.btnName = btnName;
		this.isSpecialInCloseAll = isSpecialInCloseAll;
		this.appLoadType = appLoadType;

	}


}
