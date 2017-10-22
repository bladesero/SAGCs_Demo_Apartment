using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinCtrl : MonoBehaviour {
    public GameObject desk13, desk23, desk12, desk22, chair1, chair2, chair3, chair4, chair5, chair6;
    Vector3 desk13Pos, desk23Pos, desk12Pos, desk22Pos, chair1Pos, chair2Pos, chair3Pos, chair4Pos, chair5Pos, chair6Pos;
    public GameObject MoveCude;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        desk13Pos = desk13.transform.position;
        desk23Pos = desk23.transform.position;
        desk12Pos = desk12.transform.position;
        desk22Pos = desk22.transform.position;
        chair1Pos = chair1.transform.position;
        chair2Pos = chair2.transform.position;
        chair3Pos = chair3.transform.position;
        chair4Pos = chair4.transform.position;
        chair5Pos = chair5.transform.position;
        chair6Pos = chair6.transform.position;
        Debug.Log(Mathf.Abs(desk22Pos.x - 21));
        if (Mathf.Abs(desk22Pos.x-21)<=0.5f && Mathf.Abs(desk22Pos.z - 38) <= 0.5f
            && Mathf.Abs(chair1Pos.x - 20) <= 0.5f && Mathf.Abs(chair1Pos.z - 38)<=0.5f
            && Mathf.Abs(desk13Pos.x - 21) <= 0.5f && Mathf.Abs(desk13Pos.z - 39)<=0.5f
            && Mathf.Abs(chair4Pos.x - 20) <= 0.5f && Mathf.Abs(chair4Pos.z - 40) <= 0.5f
            && Mathf.Abs(chair5Pos.x - 22) <= 0.5f && Mathf.Abs(chair5Pos.z - 40) <= 0.5f
            && Mathf.Abs(chair3Pos.x - 22) <= 0.5f && Mathf.Abs(chair3Pos.z - 42) <= 0.5f
            && Mathf.Abs(chair2Pos.x - 20) <= 0.5f && Mathf.Abs(chair2Pos.z - 42) <= 0.5f
            && Mathf.Abs(desk23Pos.x - 21) <= 0.5f && Mathf.Abs(desk23Pos.z - 43) <= 0.5f
            && Mathf.Abs(chair6Pos.x - 22) <= 0.5f && Mathf.Abs(chair6Pos.z - 44) <= 0.5f
            &&Mathf.Abs(desk12Pos.x-20)<=0.5f&&Mathf.Abs(desk12Pos.z-44)<=0.5f)
        {
            MoveCude.GetComponent<MoveCude>().enabled = true;
        }
		
	}
}
