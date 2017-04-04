using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {
	
	public float angle;
	
	private bool spin = true;
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.spin) {
			this.transform.RotateAroundLocal(Vector3.forward, angle);
		}
		else {
			this.transform.RotateAroundLocal(Vector3.forward, 0.005f);
		}
	}
	
	public void SlowDown() {
		this.spin = false;
	}
}
