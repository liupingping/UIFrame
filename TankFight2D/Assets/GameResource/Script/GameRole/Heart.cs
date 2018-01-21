using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

	private SpriteRenderer spRenderer;
	public Sprite isDie;

	public AudioClip dieAudio;

	// Use this for initialization
	void Start () {
		spRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void die()
	{
		spRenderer.sprite = isDie;
		AudioSource.PlayClipAtPoint(dieAudio,transform.position);
	}
}
