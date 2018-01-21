using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {//爆炸特效

	// Use this for initialization
	void Start () {
		Destroy(gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
