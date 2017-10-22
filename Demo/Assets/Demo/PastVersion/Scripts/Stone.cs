using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour {
    int _num=0;//这个是key的值
    public GameObject AniTager;
    bool IsLeft;
    public GameObject Tag;
    public GameObject TagText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TagText.GetComponent<Text>().text = "| " + _num + " |";
        if (Input.mousePosition.y >= gameObject.GetComponent<RectTransform>().position.y - 70 && Input.mousePosition.y <= gameObject.GetComponent<RectTransform>().position.y + 70 && Input.mousePosition.x >= gameObject.GetComponent<RectTransform>().position.x - 70 && Input.mousePosition.x <= gameObject.GetComponent<RectTransform>().position.x + 70)
        {
            Tag.active = true;
            Tag.GetComponent<RectTransform>().position = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(1))
        {
            //if (_currTime > Time.time)
            //{
            //    return;
            //}
            //else
            //{
            //    _currTime = Cd + Time.time;
            //}
            _num++;
            if (_num == 4)
            {
                _num = 1;
            }
            IsLeft = true;
            //_playAnim();
        }
        if (Input.GetMouseButtonDown(0))
        {
            //if (_currTime > Time.time)
            //{
            //    return;
            //}
            //else
            //{
            //    _currTime = Cd + Time.time;
            //}
            //Debug.LogError("shezhi key"+_num);
            AniTager.GetComponent<KeyCtrl>().SetKey(_num); // 这里你需要自己看

            IsLeft = false;
            _playAnim();
            //AniTager.GetComponent<Animator>().Play("fan");
            Debug.Log("rrs");
        }
	}

    public float Cd = 0.5f;
    private float _currTime;
    void _playAnim()
    {
        //if (!IsLeft)
        //{
        //    AniTager.GetComponent<Animator>().SetFloat("speed", 1.0f);//回退
        //}
        //else
        //{
        //    AniTager.GetComponent<Animator>().SetFloat("speed", -1.0f);//回退
        //}
       
        //AniTager.GetComponent<Animator>().SetTrigger("Play");

    }
}
