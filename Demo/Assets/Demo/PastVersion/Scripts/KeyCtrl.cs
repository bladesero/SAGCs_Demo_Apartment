using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour {
    public int Key;
    //public bool IsStop;
    //public int GoKey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//        Key3();
//        Key1();
	}
    public void Key1()
    {
        if (Key != 1) return;
        Debug.Log("1 Stop");
        //Key = 0;
        //GoKey = 0;
        //if (IsStop)
        //{
        //    GetComponent<Animator>().SetFloat("speed", -1);
        //}
        //else
        //{
        //    GetComponent<Animator>().SetFloat("speed", 0);
        //}


        _playAnim(1);
    }

    public void Key2()
    {
        if (Key != 2) return; //alt + 回车
        Debug.Log("2 Stop");
        //Key = 0;
        //GoKey = 0;
        //if (IsStop)
        //{
        //    GetComponent<Animator>().SetFloat("speed", -1);
        //}
        //else
        //{
        //    GetComponent<Animator>().SetFloat("speed", 0);
        //}


        _playAnim(1);
    }
    public void Key3()
    {
        if (Key != 3) return;
        Debug.Log("3 Stop");
        //Key = 0;
        //GoKey = 0;
        //if (IsStop)
        //{
        //    GetComponent<Animator>().SetFloat("speed", -1);
        //}
        //else
        //{
        //    GetComponent<Animator>().SetFloat("speed", 0);
        //}

        _playAnim(1);
    }

    private void _setKey()
    {
       
        _playAnim(0);

    }

    void _playAnim(float speed)
    {
        Debug.Log("播放");
        //        var speed = _isLeft();
        GetComponent<Animator>().SetFloat("speed", speed);//这里0是暂停,1就是播放对吧,嗯
                                                          //        GetComponent<Animator>().SetTrigger("Play");
    }



    //    float _isLeft()
    //    {
    //改这个函数
    //  if (Key > _oldKey)
    // {
    //            return 1;
    // }
    //        return -1;
    //    }

    public void SetKey(int value)
    {
        //这个函数你需要改
        Key = value;
        _playAnim(-1);
    }
}
