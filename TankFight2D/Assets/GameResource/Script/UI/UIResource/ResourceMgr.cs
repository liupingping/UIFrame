using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;


public class ResourceMgr : Singleton<ResourceMgr>
    {
        public AssetLoadAgent LoadAssetFromeAssetsFolderFirst(string parentFolderPath, string resourceName,
            string extension, Type type, AssetHandler.LoadCallbackFunc completedAction, object userdata = null)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(resourceName);
            builder.Append(".");
            builder.Append(extension);

            string assetPath = string.IsNullOrEmpty(parentFolderPath) ? builder.ToString() : IOUtil.CombinePath(parentFolderPath, builder.ToString());
            return LoadAssetFromAssetFolder(assetPath, type, completedAction, userdata);
        }


        /// <summary>
        /// Edior 环境下加载一个非 Resources 目录的资源
        /// </summary>
        /// <param name="fullAssetPath"></param>
        /// <param name="completedAction"></param>
        /// <param name="userdata"></param>
        /// <returns></returns>
        public AssetLoadAgent LoadAssetFromAssetFolder(string fullAssetPath, Type type, AssetHandler.LoadCallbackFunc completedAction = null, object userdata = null)
        {
            if (!fullAssetPath.StartsWith("Assets/"))
            {
                Debug.LogErrorFormat("Assets path error! {0}", fullAssetPath);
                return null;
            }

            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(fullAssetPath, type);
            if (asset == null)
            {
                Debug.LogErrorFormat("Can`t load asset from assets folder!! {0}", fullAssetPath);
            }

            EditorAssetLoadAgent loadAgent = new EditorAssetLoadAgent();
            loadAgent.Init(asset, completedAction, userdata);
            return loadAgent;
        }

    }

