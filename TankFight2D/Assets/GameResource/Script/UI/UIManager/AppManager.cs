using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager {


	private Dictionary<string,AppPanel> moduleDic = new Dictionary<string,AppPanel >();

	public static void showApp(string  appName,object obj = null,string openTable = "")
	{
		AppInfo appInfo = AppConstant.GetFormInfoByName(appName);
		preTurnModule(appInfo,obj,openTable);

	}

	private static void preTurnModule(AppInfo appInfo,object data,string openTable)
	{
			if(moduleDic.ContainsKey(appInfo.AppName) == false)
			{
				turnModule(appInfo,data,openTable);
			}

	}

	private static void turnModule(AppInfo appInfo,object data,string openTable)
	{
		if(appInfo != null)
		{
			string moduleName = appInfo.AppName;
			AppPanel appPanel = moduleDic[moduleName] ;
			if(appPanel != null)
			{

			}
			else
			{
				appPanel = new AppPanel(appInfo);
				moduleMap[moduleName] = AppPanel;
				appPanel.init(data,openTable);
				appPanel.setup();
			}


		}

	}

	private static void toShowApp(AppPanel appPanel)
	{
			appPanel.show();
	}



}
