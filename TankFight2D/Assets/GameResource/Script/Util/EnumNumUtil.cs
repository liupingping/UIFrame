using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumNumUtil
{
	public static readonly string H = "Horizontal";
	public static readonly string V = "Vertical"; 
	public static readonly int playerMoveSpeed = 3;//角色移动的速度；

	public static int bullectMoveSpeed = 10;

	//坦克朝向
	public enum ENUM_TANK_DIR
	{
		UP = 0,
		RIGHT,
		DOWN,
		LEFT,		
	}

	

	
}
