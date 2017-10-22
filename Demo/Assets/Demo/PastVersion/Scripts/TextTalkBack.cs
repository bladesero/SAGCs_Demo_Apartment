using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTalkBack : MonoBehaviour {
	public GameObject TextBack,FKC,chr,uncle;
	// Use this for initialization
	void Start () {
		TextBack.active = false;
		FKC.active = false;
        if (chr != null)
        {
            chr.GetComponent<ThirdCtrl>().enabled = true;
        }
        if (uncle != null)
        {
            uncle.GetComponent<Animator>().speed = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
