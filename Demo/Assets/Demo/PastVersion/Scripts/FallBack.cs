using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBack : MonoBehaviour {
	//Vector3 LastP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider tri){
		//Debug.Log (tri.name);
	}
	void OnTriggerEnter(Collider tri){
		if (tri.name != "chr") {
			transform.Translate (Vector3.fwd);
		}
	}
	void OnTriggerExit(Collider tri){
		if (tri.name != "chr") {
			transform.localPosition = new Vector3 (-0.64f, 0.703f, 1.738f);
		}
	}
}
