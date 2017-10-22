using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawColor : MonoBehaviour {
	public Color mix;
	public GameObject DrawTager;
	public float r, g, b;
	// Use this for initialization
	void Start () {
		if (r != 0 || g != 0 || b != 0) {
			mix.r = r;
			mix.g = g;
			mix.b = b;
		} else {
			r = mix.r;
			g = mix.g;
			b = mix.b;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnEnable(){
		
	}
	void FixedUpdate(){
			DrawTager.GetComponent<Image> ().color = new Color (r, g, b, 1.0f);
			if (r > 0) {
				r = r - 0.02f;
			}
			if (g > 0) {
				g = g - 0.02f;
			}
			if (b > 0) {
				b = b - 0.02f;
			}
		//Debug.Log ("r:" + r + "g:" + g + "b:" + b);
	}
}
