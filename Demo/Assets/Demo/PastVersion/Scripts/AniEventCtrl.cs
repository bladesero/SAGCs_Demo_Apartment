using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEventCtrl : MonoBehaviour {
    public GameObject DesObj;
    public GameObject ArivObj;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

	}
    public void Des()
    {
        Destroy(DesObj);
    }
    public void Ariv()
    {
        ArivObj.active = true;
    }
}
