using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Note : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject Tag;
    Vector2 MousePos;
    GameObject UI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.mousePosition.y >= gameObject.GetComponent<RectTransform>().position.y - 100 && Input.mousePosition.y <= gameObject.GetComponent<RectTransform>().position.y + 100 && Input.mousePosition.x >= gameObject.GetComponent<RectTransform>().position.x - 75 && Input.mousePosition.x <= gameObject.GetComponent<RectTransform>().position.x + 75)
        {
            Tag.active = true;
            Tag.GetComponent<RectTransform>().position = Input.mousePosition;
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
