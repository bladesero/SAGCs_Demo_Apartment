using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTri : MonoBehaviour {
	public GameObject ThirdViewCamera,Chr,Uncle,GameObjectTextTalk,GroupText;
	public bool An;
	public bool TextTalk;
    public bool GroupGameObjectText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider hit){
		if (hit.gameObject == Uncle) {
			Uncle.SetActive (false);
		}
		if (TextTalk == false) {
			transform.GetChild (0).gameObject.active = true;
		}
		if (An == true) {
			if (ThirdViewCamera.active == true) {
				ThirdViewCamera.GetComponent<Animator> ().enabled = true;
			}
			Chr.GetComponent<Animator> ().enabled = true;
			//Uncle.GetComponent<Animator> ().enabled = true;
			Uncle.GetComponent<Animator> ().SetBool("walk",true);
		}
		if (TextTalk == true) {
			if (hit.name == "chr"|| hit.name == "tri") {
				GameObjectTextTalk.active = true;
                if (hit.name == "chr")
                {
                    hit.gameObject.GetComponent<ThirdCtrl>().enabled = false;
                }
                if (hit.transform.gameObject.name == "chr")
                {
                    hit.transform.gameObject.GetComponent<ThirdCtrl>().enabled = false;
                }
            }
		}
        if (GroupGameObjectText == true)
        {
            if (hit.name == "chr"|| hit.name == "tri")
            {
                GroupText.active = true;
            }
        }
//        Debug.Log(hit.name);
    }
	void OnTriggerExit(Collider hit){
		if (TextTalk == false) {
			transform.GetChild (0).gameObject.active = false;
		}
		if (TextTalk == true) {
			//hit.gameObject.GetComponent<ThirdCtrl> ().enabled = true;
		}
		Destroy (gameObject);
	}
}
