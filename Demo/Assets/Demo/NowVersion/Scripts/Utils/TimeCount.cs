using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour {
	float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	public bool wait(float Settime){
		time += Time.fixedDeltaTime;
		if (time >= Settime) {
			time = 0f;
			return true;
		}
		return false;
	}
}
