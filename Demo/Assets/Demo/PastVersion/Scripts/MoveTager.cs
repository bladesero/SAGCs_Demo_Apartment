using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTager : MonoBehaviour {
	Vector3 CR1;
	public GameObject Tager;
	GameObject cri;
	public bool On;
	// Use this for initialization
	void OnEnable () {
		On = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			CR1.x = Tager.transform.position.x - cri.transform.position.x;
			CR1.z = Tager.transform.position.z - cri.transform.position.z;
			CR1.y = cri.transform.position.y;
			//Debug.Log(CR1);
			cri.GetComponent<Rigidbody> ().AddForce (CR1 * 1000);
		} 
	}
	//void OnTriggerEnter(Collider tri){
	//	cri = tri.gameObject;
	//}
	void OnTriggerStay(Collider tri){
		if (On == true) {
			if (tri.transform.parent.gameObject.name == "chair" || tri.transform.parent.gameObject.name == "desk") {
				cri = tri.transform.parent.gameObject;
				On = false;
			}
		}
	}
}
