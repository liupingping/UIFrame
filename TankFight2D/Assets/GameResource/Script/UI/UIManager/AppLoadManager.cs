using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public  class AppLoadManager
{
        public static AppLoadManager appLoadManager;

        private Dictionary<string, string> _cacheDic = new Dictionary<string, string>();
        protected Dictionary<string, AppCacheLoaderInfo[]> waitMap = new Dictionary<string, AppCacheLoaderInfo[]>();

        private AppCacheLoaderInfo[] _appCacheLoaderInfoPool = new AppCacheLoaderInfo[]{};
       

        public static AppLoadManager instance()
        {
            if (appLoadManager == null)
            {
                appLoadManager = new AppLoadManager();

            }

            return appLoadManager;
        }

        public void loadByUrl(string url, String loadingTitle, Action<GameObject> func)
        {

            if (isUrlReady(url))
            {
                func(null);
            }
            else
            {
                AppCacheLoaderInfo cacheInfo = getCacheLoaderInfo();
			    cacheInfo.url = url;
			    cacheInfo.func = func;
			    cacheInfo.loaderTitle = loadingTitle;
			    addLoad(cacheInfo);
            }
        }

        protected List<IEnumerator> loadCoroutines = new List<IEnumerator>();
        protected AssetLoadAgent prefabAssetLoadAgent; // 界面预设的资源

        private void addLoad(AppCacheLoaderInfo cacheInfo)
	    {
		    //if(!addWait(cacheInfo))
            if(false)
		    {
			    return;
		    }
            else
		    {
//				var _loader:Loader = getLoader();
//				_loader.contentLoaderInfo.addEventListener(Event.COMPLETE, onLoaderComplete);
//				_loader.contentLoaderInfo.addEventListener(Event.CLOSE, onLoadClose);
//				_loader.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onError);
//				_loader.contentLoaderInfo.addEventListener(ProgressEvent.PROGRESS,onLoadProgress);
//				_loaderToUrlDic[_loader] = cacheInfo.url;
//				var loaderContext:LoaderContext = new LoaderContext(false,ApplicationDomain.currentDomain);
//				if(loaderContext.hasOwnProperty("allowCodeImport"))
//				{
//					loaderContext["allowCodeImport"] = true; 
//				}
//				_loader.load(new URLRequest(cacheInfo.url),loaderContext);

                IEnumerator enumerator = _AssembleUIPrefab(cacheInfo);
                loadCoroutines.Add(enumerator);
                CoroutineHelper.ins.StartTrackedCoroutine(enumerator);
		    }
	    }

        private IEnumerator _AssembleUIPrefab(AppCacheLoaderInfo cacheInfo)
        {
            IEnumerator enumerator = _PopulateUIRoot(cacheInfo);
            loadCoroutines.Add(enumerator);
            yield return CoroutineHelper.ins.StartTrackedCoroutine(enumerator);
        }

        private IEnumerator _PopulateUIRoot(AppCacheLoaderInfo cacheInfo)
        {
            var resname = cacheInfo.url;
            prefabAssetLoadAgent = ResourceMgr.ins.LoadAssetFromeAssetsFolderFirst(ResourcesPath.UIPrefabPath, resname,
                                                                                     "prefab", typeof(UnityEngine.Object), null);

            GameObject obj = (GameObject)prefabAssetLoadAgent.AssetObject;

            if (obj != null)
            {
                Action<GameObject> func = cacheInfo.func;
                func(obj);
            }

            /**
            //> 获得界面Root
            m_uiTrans = Object.Instantiate(obj).transform;
            if (null == m_uiTrans)
            {
                Debug.LogError("Invalid UI prefab: " + szSceneName);
            }

            //> 新界面放置到主界面下面
            m_uiTrans.gameObject.name = szSceneName;
            m_uiTrans.parent = UIManager.ins.UIRootTransform;
            m_uiTrans.localPosition = new Vector3(0, 0, 0);
            m_uiTrans.localRotation = Quaternion.identity;
            m_uiTrans.localScale = Vector3.one;

            //> 获取UIRoot上绑定的Ref组件
            m_uiRoot = m_uiTrans.GetComponent<UIRef>().Ref;
            */
            yield break;
        }


        private Boolean addWait(AppCacheLoaderInfo cacheInfo)
        {
            AppCacheLoaderInfo[] arr = null;
            if (waitMap.ContainsKey(cacheInfo.url))
            {
                arr = waitMap[cacheInfo.url];
            }
			if(arr != null)
			{
				foreach(AppCacheLoaderInfo cacheLoaderInfo in arr)
				{
                    if (cacheLoaderInfo.func == cacheInfo.func)
					{
						relealeCacheInfo(cacheInfo);
						return false;
					}
				}
				toAddWait(arr,cacheInfo);
				return false;
			}else
			{
				arr = new AppCacheLoaderInfo[]{};
				toAddWait(arr,cacheInfo);
				waitMap[cacheInfo.url] = arr;
				return true;
			}
	    }


        private void toAddWait(AppCacheLoaderInfo[] arr,AppCacheLoaderInfo cacheInfo)
	    {
            if (arr != null)
            {
                arr[arr.Length] = cacheInfo;
            }
	    }


        private void relealeCacheInfo(AppCacheLoaderInfo cacheInfo)
	    {
			cacheInfo.func = null;
			cacheInfo.url = "";
	    }

        public bool isUrlReady(string url)
        {
            return _cacheDic.ContainsKey(url);

        }

        private AppCacheLoaderInfo getCacheLoaderInfo()
        {
            int count = _appCacheLoaderInfoPool.Length;
            if (count > 0)
		    {
                return _appCacheLoaderInfoPool[count - 1];
		    }
	        return new AppCacheLoaderInfo();;
	    }
		


}