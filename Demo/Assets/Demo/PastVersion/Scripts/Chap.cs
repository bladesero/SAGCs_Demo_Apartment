using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chap : MonoBehaviour {
    public float Aplaht=0;
    public Texture2D black;
    public int hour,min;
    public GameObject OnFales;
    int sum,i;
    string Text;
    public GUISkin Skin;
    public bool On;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Aplaht == 0&&On==false)
        {
            OnFales.active = false;
        }
        if (Aplaht <= 0&&On==true)
        {
            OnFales.active = true;
            Destroy(gameObject);
        }
        if (Aplaht < 1 && On == false)
        {
            Aplaht = Aplaht + 0.02f;
        }
        if (Aplaht >= 1)
        {
            On = true;
            i++;
        }
        if (i >= 200)
        {
            if (On == true)
            {
                Aplaht = Aplaht - 0.005f;
            }
        }
	}
    private void Update()
    {
        if (i >= 200)
        {
            if (hour >= 10)
            {
                Text = hour + ":";
            }
            else
            {
                Text = "0" + hour + ":";
            }
            if (min >= 10)
            {
                Text = Text + min;
            }
            else
            {
                Text = Text + "0" + min;
            }
        }
        else
        {
            sum = Random.Range(0, 86400);
            if (sum / 60 / 60 % 60 >= 10)
            {
                Text = sum / 60 / 60 % 60+":";
            }
            else
            {
                Text = "0" + sum / 60 / 60 % 60 + ":";
            }
            if (sum / 60 % 60 >= 10)
            {
                Text = Text + sum / 60 % 60;
            }
            else
            {
                Text = Text + "0" + sum / 60 % 60;
            }
        }
    }
    private void OnGUI()
    {
        GUI.color = new Color(1, 1, 1, Aplaht);
        GUI.skin = Skin;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), black);
        GUI.Label(new Rect(0 , Screen.height / 2 , Screen.width, Screen.height), Text);
    }
}
