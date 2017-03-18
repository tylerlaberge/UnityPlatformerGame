using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		GameManager gameManager = FindObjectOfType<GameManager>();
		if (gameManager != null) {
			gameManager.LoadNextLevel();
		} 
	}
}
