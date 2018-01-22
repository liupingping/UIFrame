using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IUIRef
{
    void SetRef(MonoBehaviour mono);

    void Awake();
    void Start();
    void OnDestroy();
    void OnEnable();
    void OnDisable();

    void OnClick();
    void OnPress(bool bPress);
    void OnDrag(Vector2 delta);

    void Update();
    void FixedUpdate();
    void LateUpdate();
}

public interface IUIRefImplFactory
{
    IUIRef Creat(string typeName);
}



public class UIRef : MonoBehaviour
{
    private IUIRef m_ref;

    private string refTypeName;

    public IUIRef Ref
    {
        get
        {
            if (m_ref == null)
            {
                CreatInstance();
            }
            return m_ref;
        }
    }

    public static IUIRefImplFactory Factory { set; private get; }

    private void CreatInstance()
    {
        if (null != m_ref) return;
        if (null == Factory)
        {
            Debug.LogError("GreatWall DLL Assembly Can't Equal NULL.");
            return;
        }

        refTypeName = this.GetType().Name;

        ProfilerSample.BeginSample("CreatInstance");

        if (!refTypeName.EndsWith("Ref"))
        {
            Debug.LogError("Ref Class Error! Current Name:" + refTypeName);
            return;
        }

        string sTypeName = refTypeName.Substring(0, refTypeName.Length - 3);

        m_ref = (IUIRef)Factory.Creat(sTypeName);
        if (m_ref != null)
        {
            m_ref.SetRef(this);
        }
        else
        {
            Debug.LogErrorFormat("Creat Instance Error Type Name:｛０｝", refTypeName);
        }
        ProfilerSample.EndSample();
    }

    private void Awake()
    {
        CreatInstance();
        if (null == m_ref) return;
        m_ref.Awake();
    }

    private void Start()
    {
        //> 原本隐藏的gameobject是没有awake调用的，所以再调用一次
        CreatInstance();
        //> 注释结束

        if (null == m_ref) return;
        m_ref.Start();
    }

    private void OnDestroy()
    {
        if (null == m_ref) return;
        m_ref.OnDestroy();
    }

    private void OnEnable()
    {
        if (null == m_ref) return;
        m_ref.OnEnable();
    }

    private void OnDisable()
    {
        if (null == m_ref) return;
        m_ref.OnDisable();
    }

    private void OnClick()
    {
        if (null == m_ref) return;
        m_ref.OnClick();
    }

    private void OnPress(bool bPress)
    {
        if (null == m_ref) return;
        m_ref.OnPress(bPress);
    }

    private void OnDrag(Vector2 delta)
    {
        if (null == m_ref) return;
        m_ref.OnDrag(delta);
    }

    private void Update()
    {
        if (null == m_ref) return;
        m_ref.Update();
    }

    private void FixedUpdate()
    {
        if (null == m_ref) return;
        m_ref.FixedUpdate();
    }

    private void LateUpdate()
    {
        if (null == m_ref) return;
        m_ref.LateUpdate();
    }
}
