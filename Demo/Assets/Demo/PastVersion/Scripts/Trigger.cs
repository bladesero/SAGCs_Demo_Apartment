using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
	public GameObject Tager,Massage,Tag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider hit){
        if (Tager != null && Massage != null)
        {
            Tag.active = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Tager != null && Massage != null)
        {
            Tager.active = true;
            Massage.active = true;
        }
	}
    void OnTriggerExit(Collider other)
    {
        Tag.active = false;
    }
}
