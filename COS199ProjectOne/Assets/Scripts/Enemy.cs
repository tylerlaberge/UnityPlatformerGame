using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	[Range(0, 0.3f)]
	public float speed;
	private bool reverse = false;
	
	void Update () {
		if (this.reverse) {
			this.transform.Translate(new Vector3(-speed, 0, 0));
		}
		else {
			this.transform.Translate(new Vector3(speed, 0, 0));
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Boundary") {
			this.reverse = !this.reverse;
		}
	}
}
