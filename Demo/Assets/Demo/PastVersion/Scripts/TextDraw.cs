using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDraw : MonoBehaviour {
	public GameObject[] Text;
	public int i;
	// Use this for initialization
	void Start () {
		Text [0].active = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)&&i<=Text.Length-2) {
			i++;
			Text [i].active = true;
			Text [i - 1].active = false;
		}
	}
}
