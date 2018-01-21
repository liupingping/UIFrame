using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	public GameObject wallPrected;// 空气墙

	public GameObject Wall;//墙
	public GameObject River;//河流
	public GameObject Heart;//大本营
	public GameObject Grass;//草地
	public GameObject Barriar;//障碍

	public GameObject player;//角色

	private ArrayList MapList = new ArrayList();//生产的场景中 的坐标；

	// Use this for initialization
	void Start () {

		initPlayer();

		initMapOut();
		initMapIn();

		
		
	}
	
	private void initPlayer()
	{
		Vector3 pos = new Vector3(-2,-8,0);
		MapList.Add(pos);
		Instantiate(player,pos,transform.rotation);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void initMapOut()
	{
		int i = 0;
		
		for( i = -11; i <= 11; i++)// y = 9; 上面墙
		{
			 Instantiate(wallPrected,new Vector3(i,9,0),transform.rotation);			 
		}
		
		for(i = -9; i <= 9; i++) //x = -11; 左边墙
		{
			Instantiate(wallPrected,new Vector3(-11,i,0),transform.rotation);
		}

		for(i = -11; i <= 11; i++)//y = -9 下面墙
		{
			Instantiate(wallPrected,new Vector3(i,-9,0),transform.rotation);
		}

		for(i = -9; i <= 9; i++) //x = 11; 左边墙
		{
			Instantiate(wallPrected,new Vector3(11,i,0),transform.rotation);
		}

	}
	
	public void initMapIn()
	{	
		Vector3 pos;
		pos = new Vector3(0,-8,0);
		Instantiate(Heart, pos,transform.rotation);		
		MapList.Add(pos);

		int i = 0 ;
		for(i = -8; i< -7; i++)
		{
			pos = new Vector3(-1,i,0);
			MapList.Add(pos);
			Instantiate(Wall,pos,transform.rotation);
		}

		for(i = -1; i <= 1; i++)
		{
			pos = new Vector3(i,-7,0);
			MapList.Add(pos);
			Instantiate(Wall,pos,transform.rotation);
		}
		
		for(i = -8; i< -7; i++)
		{
			pos = new Vector3(1,i,0);
			MapList.Add(pos);
			Instantiate(Wall,pos,transform.rotation);
		}

		
		int count = 0;
		int xPos = 0;
		int yPos = 0;
		while(count <= 30)
		{
			xPos = Random.Range(-10,11);
			yPos = Random.Range(-8,8);
			pos = new Vector3(xPos,yPos,0);

			if(!MapList.Contains(pos))
			{
				Instantiate(Wall,pos,transform.rotation);
				MapList.Add(pos);
				count++;
			}
		}
		
		count = 0;
		while(count <= 20)
		{
			xPos = Random.Range(-10,11);
			yPos = Random.Range(-8,8);
			pos = new Vector3(xPos,yPos,0);

			if(!MapList.Contains(pos))
			{
				Instantiate(Barriar,pos,transform.rotation);
				MapList.Add(pos);
				count++;
			}
		}

		count = 0;
		while(count <= 10)
		{
			xPos = Random.Range(-10,11);
			yPos = Random.Range(-8,8);
			pos = new Vector3(xPos,yPos,0);

			if(!MapList.Contains(pos))
			{
				Instantiate(Grass,pos,transform.rotation);
				MapList.Add(pos);
				count++;
			}
		}

		count = 0;
		while(count <= 15)
		{
			xPos = Random.Range(-10,11);
			yPos = Random.Range(-8,8);
			pos = new Vector3(xPos,yPos,0);

			if(!MapList.Contains(pos))
			{
				Instantiate(River,pos,transform.rotation);
				MapList.Add(pos);
				count++;
			}
		}


	}

}
