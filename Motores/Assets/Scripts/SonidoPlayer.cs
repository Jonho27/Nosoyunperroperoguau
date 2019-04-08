using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPlayer : MonoBehaviour {

	public AudioClip walk;

	AudioSource fuenteAudio;

	// Use this for initialization
	void Start () {
		fuenteAudio = GetComponent<AudioSource> ();
		fuenteAudio.clip = walk;
		fuenteAudio.loop = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
			fuenteAudio.Play();
			
		}

		else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
		{
			fuenteAudio.Stop();
			fuenteAudio.loop = false;

		}
		
	}
}
