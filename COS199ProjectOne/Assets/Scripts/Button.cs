using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	
	public List<Spinner> spinners;
	public float stopAngle;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			this.transform.localScale = new Vector3(
				this.transform.localScale.x, this.transform.localScale.y/2, this.transform.localScale.z
			);
			this.slowSpinners();
		}
	}
	private void slowSpinners() {
		foreach (Spinner spinner in this.spinners) {
			spinner.SlowDown();
		}
	}
}
