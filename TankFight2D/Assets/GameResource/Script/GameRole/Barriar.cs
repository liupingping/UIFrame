using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriar : MonoBehaviour {

	public AudioClip audioClip;

	public void playAudio()
	{
		AudioSource.PlayClipAtPoint(audioClip,transform.position);

	}

}
