using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floow : MonoBehaviour {
	public GameObject Tager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		Floowr (Tager,gameObject);
	}
	void Floowr(GameObject Tager,GameObject Caamera){
		float DeltaSpeed = (Mathf.Abs (Tager.transform.position.x - Caamera.transform.position.x) + Mathf.Abs (Tager.transform.position.y - Caamera.transform.position.y) + Mathf.Abs (Tager.transform.position.z - Caamera.transform.position.z)) / 3;
		Caamera.transform.position = Vector3.MoveTowards (Caamera.transform.position, new Vector3 (Tager.transform.position.x+(Random.Range(-1,3)/100), Tager.transform.position.y+(Random.Range(-1,3)/100), Tager.transform.position.z+(Random.Range(-1,3)/100)), DeltaSpeed);
	}
}
