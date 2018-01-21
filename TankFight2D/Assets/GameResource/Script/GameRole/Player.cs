using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public SpriteRenderer sprRenderer;//坦克自己的引用；
	public Sprite[] tankDics;//存放坦克方向的引用资源；

	public GameObject bullectPrected;//子弹
	public GameObject explosionPrected;//爆炸
	public GameObject defendPrected;//无敌特效；

	private float wuDiTime = 3f;


	private Vector3 bullectAngle;//子弹角度；

	private bool isInit = false;
	private bool isProtect = true;

	public AudioClip audioClip;//发射子弹的声音；

	public AudioSource audioSource;

	public AudioClip[] auioClips;

	// Use this for initialization
	public void Start ()
	{
		
	}

	public void Awake()
	{
		sprRenderer = GetComponent<SpriteRenderer>();
		isInit = true;
	}
	
	
	// Update is called once per frame
	public void Update () 
	{
		if(isProtect == false)return;
		wuDiTime -= Time.deltaTime;
		if(wuDiTime <= 0)isProtect = false;		
		if(isProtect == true)
		{
			defendPrected.SetActive(true);
		}
		else
		{
			defendPrected.SetActive(false);
		}

	}

	private void FixedUpdate()
	{
		move();
		attack();
	}

	private void attack()//攻击 发射子弹
	{
		//if(isInit == false)return;
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(bullectPrected, transform.position, Quaternion.Euler(transform.eulerAngles + bullectAngle));
			Bullet blet = bullet.GetComponent<Bullet>();
			blet.isPlayerBull = true;

			AudioSource.PlayClipAtPoint(audioClip,transform.position);
		}
	}

	private void move()//坦克的移动方法
	{
		if(isInit == false)return;
		//水平方向
		float h = Input.GetAxisRaw(EnumNumUtil.H);
		transform.Translate( Vector3.right * h * EnumNumUtil.playerMoveSpeed * Time.fixedDeltaTime, Space.World );
		
		//playTankAudio(h);
		if(h < 0)//左边
		{
			sprRenderer.sprite = tankDics[(int)EnumNumUtil.ENUM_TANK_DIR.LEFT];
			bullectAngle = new Vector3(0,0,90);
			return;
		}
		else if(h > 0)//右边
		{
			sprRenderer.sprite = tankDics[(int)EnumNumUtil.ENUM_TANK_DIR.RIGHT];
			bullectAngle = new Vector3(0,0,-90);
			return;
		}

		//垂直方向
		float v= Input.GetAxisRaw(EnumNumUtil.V);
		transform.Translate( Vector3.up * v * EnumNumUtil.playerMoveSpeed * Time.fixedDeltaTime, Space.World );
		if(v < 0)
		{
			sprRenderer.sprite = tankDics[(int)EnumNumUtil.ENUM_TANK_DIR.DOWN];
			bullectAngle = new Vector3(0,0,-180);
		}
		else if(v > 0)
		{
			sprRenderer.sprite = tankDics[(int)EnumNumUtil.ENUM_TANK_DIR.UP];
			bullectAngle = new Vector3(0,0,0);
		}

		//playTankAudio(v);
	}

	private void playTankAudio(float dis)
	{	
		if(Mathf.Abs(dis) > 0.05f)
		{
			audioSource.clip = auioClips[1];
			if(!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
		else
		{
			audioSource.clip = auioClips[0];
			if(!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
	}

	public void die()//死亡
	{
		if(isProtect)return;
		isInit = false;
		isProtect = false;
		//爆炸
		Instantiate(explosionPrected,transform.position,transform.rotation);
        //死亡
		Destroy(gameObject);		
	}


}
