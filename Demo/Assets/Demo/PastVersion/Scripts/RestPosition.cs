using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestPosition : MonoBehaviour {
	public GameObject[] Sr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i <= Sr.Length-1; i++) {
			float x=transform.position.x - Sr [i].transform.position.x;
			float z=transform.position.z - Sr [i].transform.position.z;
			if (x <= 1 && z <= 1) {
				int xx = (int)transform.position.x;
				int zz = (int)transform.position.z;
				transform.position = new Vector3 ((float)xx, transform.position.y, (float)zz);
				Debug.Log (transform.position);
			}
		}
	}
}
