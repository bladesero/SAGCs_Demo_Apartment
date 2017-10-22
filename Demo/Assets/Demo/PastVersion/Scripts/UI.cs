using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public GameObject AriObj;
    public GameObject FasObj;
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnUI()
    {
        AriObj.active = true;
        FasObj.active = false;
        Cursor.visible = false;
    }
}
