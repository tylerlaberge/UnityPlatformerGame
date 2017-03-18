using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverX : MonoBehaviour {
	
	public float x;
	public float time;

	// Use this for initialization
	void Start () {
		LeanTween.moveX(this.gameObject, x, time).setEaseInOutSine().setLoopPingPong();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
