using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	
	private Player player;
	private bool activated = false;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!activated) {
			if (playerIsPassedCheckpoint()) {
				this.activated = true;
				player.setRespawnPoint(new Vector3(
					this.transform.position.x, this.transform.position.y + 1, this.transform.position.z)
				);
			}
		}
		
	}
	
	bool playerIsPassedCheckpoint() {
		return player.transform.position.x > this.transform.position.x;
	}
}
