using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {
	
	private GameManager gameManager;
	private AudioManager audioManager;
	
	void Start() {
		this.gameManager = FindObjectOfType<GameManager>();
		this.audioManager = FindObjectOfType<AudioManager>();
	}
	void OnCollisionEnter(Collision collision)
	{
		if (gameManager != null) {
			this.audioManager.playLevelEnd();
			this.gameManager.LoadNextLevel();
		}
	}
}

