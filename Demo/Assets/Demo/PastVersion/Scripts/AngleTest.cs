using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTest : MonoBehaviour {

	float sinf,cosf;
	public float Angle_Y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Angle_Y = this.transform.eulerAngles.y;
		float ay=Angle_Y*Mathf.Deg2Rad;
		float cosf = Mathf.Cos (ay);
		float sinf = Mathf.Sin (ay); 
		//Debug.Log (Angle_Y + "cosf:" + cosf + "sinf:" + sinf);
		if (cosf >= 0.707f &&cosf<=1) {
			Debug.Log ("x+");
			this.transform.Translate(Vector3.right*Time.deltaTime);
		}
		if (cosf <= -0.707f &&cosf>=-1) {
			Debug.Log ("x-");
			this.transform.Translate(-Vector3.right*Time.deltaTime);
		}
		if(sinf< -0.707f && sinf>= -1)
		{
			Debug.Log ("z-");
			this.transform.Translate(-Vector3.forward*Time.deltaTime);
		}
		if (sinf > 0.707f && sinf <= 1)
		{
			Debug.Log ("z+");
			this.transform.Translate(Vector3.forward*Time.deltaTime);
		}
	}
}
