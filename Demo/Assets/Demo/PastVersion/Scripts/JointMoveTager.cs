using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMoveTager : MonoBehaviour {
	public GameObject gosh,air;
	// Use this for initialization
	void Start () {
		
		//GetComponent<FixedJoint> ().connectedBody = air.GetComponent<Rigidbody> ();
		//GetComponent<FixedJoint> ().breakForce = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (gosh != null) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				gameObject.AddComponent<FixedJoint> ();
				GetComponent<FixedJoint> ().connectedBody = gosh.GetComponent<Rigidbody> ();
				GetComponent<FixedJoint> ().breakForce = 100;
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				GetComponent<FixedJoint> ().breakForce = 0;
				gosh = null;
			}
		}
	}
	void OnTriggerEnter(Collider hit){
		if (hit.tag == "MoveObject") {
			gosh = hit.gameObject;
		}
	}
}