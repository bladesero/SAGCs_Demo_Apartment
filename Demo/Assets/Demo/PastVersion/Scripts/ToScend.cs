using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToScend : MonoBehaviour {
    public GameObject CtrlTager;
    public string name;
    public bool BeInCtrl;
    // Use this for initialization
    void Start () {
        if (BeInCtrl == false)
        {
            SceneManager.LoadScene(name);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (BeInCtrl == true)
        {
            if (CtrlTager.GetComponent<Chap>().Aplaht >= 0.9f)
            {
                SceneManager.LoadScene(name);
            }
        }
	}
}
