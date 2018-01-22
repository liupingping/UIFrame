using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelper : MonoSingleton<CoroutineHelper>
{

    private DateTime start;

    private static readonly  Queue<Action> ExecuteQnMainThread = new Queue<Action>();

    // 可追踪Coroutine的列表，用于判断某Coroutine是否正在运行
    private List<IEnumerator> runningCoroutinesByEnumerator = new List<IEnumerator>();


    /// <summary>
    /// 开始一个可追踪的Coroutine
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public Coroutine StartTrackedCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(GenericRoutine(coroutine));
    }

    /// <summary>
    /// 停止一个可追踪的Coroutine
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public void StopTrackedCoroutine(IEnumerator coroutine)
    {
        if (!runningCoroutinesByEnumerator.Contains(coroutine))
        {
            return;
        }
        StopCoroutine(coroutine);
        runningCoroutinesByEnumerator.Remove(coroutine);
    }


    private IEnumerator GenericRoutine(IEnumerator coroutine)
    {
        runningCoroutinesByEnumerator.Add(coroutine);
        yield return StartCoroutine(coroutine);
        runningCoroutinesByEnumerator.Remove(coroutine);
    }


    /// <summary>
    /// 启动一个计时器，用于携程内的计时
    /// </summary>
    public void StartTimer()
    {
        start = DateTime.Now;
    }

    /// <summary>
    /// 检查时间
    /// </summary>
    /// <param name="miliseconds"></param>
    /// <returns></returns>
    public bool CheckIfPassed(int miliseconds)
    {
        DateTime now = DateTime.Now;
        double ms = (now - start).TotalMilliseconds;

        return ms >= miliseconds;
    }
}
