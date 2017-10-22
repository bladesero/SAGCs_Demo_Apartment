using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCude : MonoBehaviour {

	public GameObject UI;
	Animator UIAnim;

	// Use this for initialization
	void Start () {
		UIAnim = UI.GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Vector3.MoveTowards (
			gameObject.transform.position,
			new Vector3 (gameObject.transform.position.x, 2.4f, gameObject.transform.position.z), 
			0.01f);
		Back2Title ();
    }

	void Back2Title()
	{
		if (gameObject.transform.position.y <2.5f) {
			UIAnim.SetTrigger ("B2T");
		}
	}
}
