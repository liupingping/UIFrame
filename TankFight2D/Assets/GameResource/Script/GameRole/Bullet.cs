using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {//子弹

	public bool isPlayerBull = false;


	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () 
	{
		move();
	}

	private void move()
	{
		transform.Translate( transform.up * EnumNumUtil.bullectMoveSpeed * Time.deltaTime, Space.World);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		switch(collision.tag)
		{
			case "Tank"://坦克
			{
				if(isPlayerBull == false)
				{
					collision.SendMessage("die");
					Destroy(gameObject);
				}
				break;
			}
			case "Enemy"://敌人
			{
				if(isPlayerBull == true)
				{
					collision.SendMessage("die");
				}
				Destroy(gameObject);
				break;
			}
			case "Heart"://大本营
			{
				collision.SendMessage("die");
				Destroy(gameObject);
				break;
			}
			case "Wall": //墙
			{
				Destroy(collision.gameObject);
				Destroy(gameObject);
				break;
			}
			case "Barriar"://栅栏
			{
				collision.SendMessage("playAudio");
				Destroy(gameObject);
				break;
			}
			case "AirBarriar":
			{
				Destroy(gameObject);
				break;
			}
			default:
			{
				break;
			}

		}


	}

}
