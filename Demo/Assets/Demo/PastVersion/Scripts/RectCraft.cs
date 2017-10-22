using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectCraft : MonoBehaviour {
	public GameObject obj;
	public int height,wide=1;
	public Vector3 StartV3;
	int i,j;
	// Use this for initialization
	void Start () {
		StartV3 = transform.position;
		for (i=1; i <= height; i++) {
			for (j=1; j <= wide; j++) {
				GameObject rst=Instantiate (obj);
				rst.transform.position = new Vector3 (StartV3.x + j, StartV3.y+ i, StartV3.z);
				rst.name = "x" + i + "y" + j;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
