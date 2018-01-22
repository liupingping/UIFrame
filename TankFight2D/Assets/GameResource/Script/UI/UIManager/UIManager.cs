using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public Camera StageCamera { get; private set; }
    public Transform UIRootTransform { get; private set; }



}
	