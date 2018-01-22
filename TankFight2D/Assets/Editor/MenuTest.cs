using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Linq;

public class MenuTest : MonoBehaviour
{
    /// <summary>
    /// 增加一个MyMenu菜单下的show选项
    /// </summary>
    [MenuItem("MyMenu/show")]
    static void Show()
    {
        print("haha");
    }
    /// <summary>
    /// 增加一个MyMenu菜单下的printName选项，并且只有选中物体时才可以
    /// </summary>
    [MenuItem("MyMenu/ShowSelectedName")]
    static void PrintName()
    {
        print("Selected Transform name is " + Selection.activeTransform.gameObject.name);
    }
    [MenuItem("MyMenu/ShowSelectedName", true)]
    static bool Validate()
    {
        return Selection.activeTransform != null;
    }
    /// <summary>
    /// 添加一个选项，并且指定快捷方式为ctrl + G,%代表Ctrl键（mac机上面是cmd键）  #代表Shirt键   &代表Alt键
    /// </summary>
    [MenuItem("MyMenu/shortCutKey % g")]
    static void DoSomethingWithAShortcutKey()
    {
        print("push down ctrl + g");
    }
    /// <summary>
    /// 给刚体组件的菜单增加一个double选项
    /// </summary>
    /// <param name="command"></param>
    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DoubleMass(MenuCommand command)
    {
        Rigidbody body = (Rigidbody)command.context;
        body.mass = body.mass * 2;
        print("double mass to " + body.mass);
    }
    /// <summary>
    /// 在GameObject的子菜单下新建目录选项，并设置撤销新建时的提示
    /// </summary>
    /// <param name="menuCommand"></param>
    [MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("Custom Game Object");
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeGameObject = go;
    }


    [MenuItem("MyMenu/UI/Pack Up UI Texture", false, 0)]
    public static void PackUpSelectUITexture()
    {
        var defaultPath = PlayerPrefs.GetString("UITextureFolder");
        string originalPath = EditorUtility.OpenFolderPanel("UITexture Folder", defaultPath, "");

        var exists = Directory.Exists(originalPath);
        if (exists && originalPath != defaultPath)
        {
            PlayerPrefs.SetString("UITextureFolder", originalPath);
        }

        if (!exists)
        {
            UnityEngine.Debug.LogError("Directory not exist");
            return;
        }

        var files = Directory.GetFiles(originalPath);
        if (files.Any(a => a.Contains(".png")))
        {
          
        }
        else
        {
            UnityEngine.Debug.LogError("Directory not found texture");
        }
        AssetDatabase.SaveAssets();
    }



}