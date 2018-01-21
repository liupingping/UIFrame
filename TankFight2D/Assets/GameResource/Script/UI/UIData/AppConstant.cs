using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppConstant {

	private static Dictionary<string,AppInfo> appNameInfoDic = new Dictionary<string,AppInfo>();

	private static string creatAppInfo(string moduleName,string resName,string loadingTitle,string btnName,bool isSpecialInCloseAll,
										int appLoadType = 0)
	{
		AppInfo info = appNameInfoDic[moduleName];
		if(info == null)
		{
			info = new AppInfo(moduleName,resName,loadingTitle,btnName,isSpecialInCloseAll,appLoadType);
			appNameInfoDic[moduleName] = info;
		}
		return moduleName;
	}

	public static AppInfo GetFormInfoByName(string formName)
	{
		AppInfo info = appNameInfoDic[formName];
		return info;
	}


	private static AppInfoSingle APP_INFO_SINGLE = new AppInfoSingle();

	public static string BAG_PANLE = creatAppInfo("bagPanel","bagPanel","背包面板","",false);


}
