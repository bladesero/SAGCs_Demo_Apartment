using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public partial class Proker : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    GameObject UI;
    Vector2 MousePos;
    Vector3 ProkerPos, Proker1Pos, Proker2Pos, Proker3Pos;
    Quaternion ProkerRot, Proker1Rot, Proker2Rot, Proker3Rot;
    public GameObject Proker0, Proker1, Proker2, Proker3;
    public int i = 0;
    bool On;
    public bool prokerrice;
    public GameObject Tag;
    public GameObject NowG;
    public GameObject Tri;
	// Use gameObject for initialization
	void Start () {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.mousePosition.y >= gameObject.GetComponent<RectTransform>().position.y - 100 
            && Input.mousePosition.y <= gameObject.GetComponent<RectTransform>().position.y + 100 
            && Input.mousePosition.x >= gameObject.GetComponent<RectTransform>().position.x - 75 
            && Input.mousePosition.x <= gameObject.GetComponent<RectTransform>().position.x + 75)
        {
            Tag.active = true;
            Tag.GetComponent<RectTransform>().position = Input.mousePosition;
        }
        if (UI != null)
        {
            if (Input.GetKey(KeyCode.R))
            {
                i--;
            }
            if (Input.GetKey(KeyCode.E))
            {
                i++;
            }
            UI.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, i); 
        }
        ProkerPos = Proker0.GetComponent<RectTransform>().position;
        Proker1Pos = Proker1.GetComponent<RectTransform>().position;
        Proker2Pos = Proker2.GetComponent<RectTransform>().position;
        Proker3Pos = Proker3.GetComponent<RectTransform>().position;
        ProkerRot = Proker0.GetComponent<RectTransform>().rotation;
        Proker1Rot = Proker1.GetComponent<RectTransform>().rotation;
        Proker2Rot = Proker2.GetComponent<RectTransform>().rotation;
        Proker3Rot = Proker3.GetComponent<RectTransform>().rotation;
        //Debug.Log("ProKer1-2RotZ" + (Proker1Rot.eulerAngles.z - Proker2Rot.eulerAngles.z));
        //Debug.Log("ProKer1-2PosY" + (Proker1Pos.y - Proker2Pos.y));
        //Debug.Log("ProKer0-2RotZ" + (ProkerRot.eulerAngles.z - Proker2Rot.eulerAngles.z));
        //Debug.Log("ProKer0-2PosY" + (ProkerPos.y - Proker2Pos.y));
        //Debug.Log("ProKer3-2RotZ" + (Proker3Rot.eulerAngles.z - Proker2Rot.eulerAngles.z));
        //Debug.Log("ProKer3-2PosY" + (Proker3Pos.y - Proker2Pos.y));
        //Debug.Log("MousePos: "+Input.mousePosition);
        if (Proker1Rot.eulerAngles.z - Proker2Rot.eulerAngles.z>=223&& Proker1Rot.eulerAngles.z - Proker2Rot.eulerAngles.z <=225
            &&Proker1Pos.y-Proker2Pos.y<=-136&& Proker1Pos.y - Proker2Pos.y >= -138
            && ProkerRot.eulerAngles.z - Proker2Rot.eulerAngles.z <= 316 && ProkerRot.eulerAngles.z - Proker2Rot.eulerAngles.z >= 314
            && ProkerPos.y - Proker2Pos.y >= 35 && ProkerPos.y - Proker2Pos.y <= 37
            && Proker3Rot.eulerAngles.z - Proker2Rot.eulerAngles.z >= 46 && Proker3Rot.eulerAngles.z - Proker2Rot.eulerAngles.z <= 48
            && Proker3Pos.y - Proker2Pos.y <= -104 && Proker3Pos.y - Proker2Pos.y >= -106)
        {
            Tri.GetComponent<MinCtrl>().enabled = true;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            MousePos = Input.mousePosition;
            UI.GetComponent<RectTransform>().position = MousePos;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        UI = gameObject;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UI = null;
    }
}
