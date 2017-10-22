using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMoveTager : MonoBehaviour {
	public GameObject[] Sr;
	public GameObject gosh;
	public float missless;//偏差值
	bool On;
	public GameObject chr;
	// Use chr for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)&&gosh!=null) {
			if (Input.GetKeyDown (KeyCode.W)) {
				float cosf = Mathf.Cos ((chr.transform.eulerAngles.y-270) * Mathf.Deg2Rad);
                float sinf = Mathf.Sin((chr.transform.eulerAngles.y-270) * Mathf.Deg2Rad);
 //               //Debug.Log ("cosf:"+Mathf.Cos (chr.transform.eulerAngles.y * Mathf.Deg2Rad));
 //               //Debug.Log("sinf:" + Mathf.Sin(chr.transform.eulerAngles.y * Mathf.Deg2Rad));
 //               //Debug.Log("AngleY:" + chr.transform.eulerAngles.y);
                //               //Debug.Log("angleY弧值:" + chr.transform.eulerAngles.y * Mathf.Deg2Rad);
                //               //Debug.Log("angleY:" + chr.transform.eulerAngles.y);
                if (cosf >= 0.707f && cosf <= 1)
                {
                    //Debug.Log("x+");
                    gosh.transform.Translate(-Vector3.right * 1);
                }
                if (cosf <= -0.707f && cosf >= -1)
                {
                    //Debug.Log("x-");
                    gosh.transform.Translate(Vector3.right * 1);
                }
                if (sinf < -0.707f && sinf >= -1)
                {
                    //Debug.Log("z-");
                    gosh.transform.Translate(-Vector3.forward * 1);
                }
                if (sinf > 0.707f && sinf <= 1)
                {
                    //Debug.Log("z+");
                    gosh.transform.Translate(Vector3.forward * 1);
                }
                Vector3 TagPos = gosh.transform.position;
                if (cosf >= 0.707f && cosf <= 1)
                {
                    //Debug.Log("x+");
                    gosh.transform.Translate(Vector3.right * 1);
                }
                if (cosf <= -0.707f && cosf >= -1)
                {
                    //Debug.Log("x-");
                    gosh.transform.Translate(-Vector3.right * 1);
                }
                if (sinf < -0.707f && sinf >= -1)
                {
                    //Debug.Log("z-");
                    gosh.transform.Translate(Vector3.forward * 1);
                }
                if (sinf > 0.707f && sinf <= 1)
                {
                    //Debug.Log("z+");
                    gosh.transform.Translate(-Vector3.forward * 1);
                }
                //				Vector3 Log = gosh.transform.Translate;
                //				//Debug.Log(Log);
                for (int i = 0; i <= Sr.Length - 1; i++)
                {
                    ////Debug.Log (Sr[i].name+"PosX:"+Sr[i].transform.position.x+"   "+Sr[i].name+"PosZ:"+Sr[i].transform.position.z+"   "+"LessX:"+Mathf.Abs(Sr [i].transform.position.x-TagPos.x)+"   "+"LessZ:"+Mathf.Abs(Sr [i].transform.position.z-TagPos.z));
                    if (Sr[i].name != "desk12" && Sr[i].name != "desk22" && Sr[i].name != "desk13" && Sr[i].name != "desk23"&& gosh.name != "desk12" && gosh.name != "desk22" && gosh.name != "desk13" && gosh.name != "desk23")
                    {
                        if (Mathf.Abs(Sr[i].transform.position.x - TagPos.x) <= 0.1 && Mathf.Abs(Sr[i].transform.position.z - TagPos.z) <= 0.1&&Sr[i].name!=gosh.name)
                        {
                            On = true;
                            //Debug.Log(Sr[i]+":"+Mathf.Abs(Sr[i].transform.position.x - TagPos.x));
                        }
                    }
                    if (Sr[i].name == "desk12" || Sr[i].name == "desk22"|| gosh.name == "desk12"||gosh.name=="desk22") 
                    {
                        if (Mathf.Abs(Sr[i].transform.position.x - TagPos.x) <= 0.1+1 && Mathf.Abs(Sr[i].transform.position.z - TagPos.z) <= 0.1 && Sr[i].name != gosh.name)
                        {
                            On = true;
                            //Debug.Log(Sr[i]+":"+Mathf.Abs(Sr[i].transform.position.x - TagPos.x));
                        }
                    }
                    if (Sr[i].name == "desk13" || Sr[i].name == "desk23"||gosh.name== "desk13"||gosh.name== "desk23")
                    {
                        if (Mathf.Abs(Sr[i].transform.position.x - TagPos.x) <= 0.1+1.5f && Mathf.Abs(Sr[i].transform.position.z - TagPos.z) <= 0.1 && Sr[i].name != gosh.name)
                        {
                            On = true;
                            //Debug.Log(Sr[i]+":"+Mathf.Abs(Sr[i].transform.position.x - TagPos.x));
                        }
                    }
                }
				if (On == false) {
					gosh.transform.position = TagPos;
				}
				On = false;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
                float cosf = Mathf.Cos((chr.transform.eulerAngles.y - 270) * Mathf.Deg2Rad);
                float sinf = Mathf.Sin((chr.transform.eulerAngles.y - 270) * Mathf.Deg2Rad);
                //               //Debug.Log ("cosf:"+Mathf.Cos (chr.transform.eulerAngles.y * Mathf.Deg2Rad));
                //               //Debug.Log("sinf:" + Mathf.Sin(chr.transform.eulerAngles.y * Mathf.Deg2Rad));
                //               //Debug.Log("AngleY:" + chr.transform.eulerAngles.y);
                //               //Debug.Log("angleY弧值:" + chr.transform.eulerAngles.y * Mathf.Deg2Rad);
                //               //Debug.Log("angleY:" + chr.transform.eulerAngles.y);
                if (cosf >= 0.707f && cosf <= 1)
                {
                    //Debug.Log("x+");
                    gosh.transform.Translate(Vector3.right * 1);
                }
                if (cosf <= -0.707f && cosf >= -1)
                {
                    //Debug.Log("x-");
                    gosh.transform.Translate(-Vector3.right * 1);
                }
                if (sinf < -0.707f && sinf >= -1)
                {
                    //Debug.Log("z-");
                    gosh.transform.Translate(Vector3.forward * 1);
                }
                if (sinf > 0.707f && sinf <= 1)
                {
                    //Debug.Log("z+");
                    gosh.transform.Translate(-Vector3.forward * 1);
                }
                Vector3 TagPos = gosh.transform.position;
                if (cosf >= 0.707f && cosf <= 1)
                {
                    //Debug.Log("x+");
                    gosh.transform.Translate(-Vector3.right * 1);
                }
                if (cosf <= -0.707f && cosf >= -1)
                {
                    //Debug.Log("x-");
                    gosh.transform.Translate(Vector3.right * 1);
                }
                if (sinf < -0.707f && sinf >= -1)
                {
                    //Debug.Log("z-");
                    gosh.transform.Translate(-Vector3.forward * 1);
                }
                if (sinf > 0.707f && sinf <= 1)
                {
                    //Debug.Log("z+");
                    gosh.transform.Translate(Vector3.forward * 1);
                }
                //				Vector3 Log = gosh.transform.Translate;
                //				//Debug.Log(Log);
                for (int i = 0; i <= Sr.Length - 1; i++)
                {
                    ////Debug.Log (Sr[i].name+"PosX:"+Sr[i].transform.position.x+"   "+Sr[i].name+"PosZ:"+Sr[i].transform.position.z+"   "+"LessX:"+Mathf.Abs(Sr [i].transform.position.x-TagPos.x)+"   "+"LessZ:"+Mathf.Abs(Sr [i].transform.position.z-TagPos.z));
                    if (Sr[i].name != "desk12" && Sr[i].name != "desk22" && Sr[i].name != "desk13" && Sr[i].name != "desk23" && gosh.name != "desk12" && gosh.name != "desk22" && gosh.name != "desk13" && gosh.name != "desk23")
                    {
                        if (Mathf.Abs(Sr[i].transform.position.x - TagPos.x) <= 0.1 && Mathf.Abs(Sr[i].transform.position.z - TagPos.z) <= 0.1 && Sr[i].name != gosh.name)
                        {
                            On = true;
                            //Debug.Log(Sr[i]+":"+Mathf.Abs(Sr[i].transform.position.x - TagPos.x));
                        }
                    }
                    if (Sr[i].name == "desk12" || Sr[i].name == "desk22"|| gosh.name == "desk12"||gosh.name=="desk22") 
                    {
                        if (Mathf.Abs(Sr[i].transform.position.x - TagPos.x) <= 0.1 + 1 && Mathf.Abs(Sr[i].transform.position.z - TagPos.z) <= 0.1 && Sr[i].name != gosh.name)
                        {
                            On = true;
                            //Debug.Log(Sr[i]+":"+Mathf.Abs(Sr[i].transform.position.x - TagPos.x));
                        }
                    }
                    if (Sr[i].name == "desk13" || Sr[i].name == "desk23" || gosh.name == "desk13" || gosh.name == "desk23")
                    {
                        if (Mathf.Abs(Sr[i].transform.position.x - TagPos.x) <= 0.1 + 1.5f && Mathf.Abs(Sr[i].transform.position.z - TagPos.z) <= 0.1 && Sr[i].name != gosh.name)
                        {
                            On = true;
                            //Debug.Log(Sr[i]+":"+Mathf.Abs(Sr[i].transform.position.x - TagPos.x));
                        }
                    }
                }
                if (On == false)
                {
                    gosh.transform.position = TagPos;
                }
                On = false;
            }
            //			if (Input.GetKeyDown (KeyCode.A)) {
            //				Vector3 TagPos = new Vector3 (gosh.transform.position.x-1,gosh.transform.position.y,gosh.transform.position.z);
            //				for (int i = 0; i <= Sr.Length - 1; i++) {
            //					////Debug.Log (i);
            //					if (Mathf.Abs(Sr [i].transform.position.x-TagPos.x)<=0.1+missless&&Mathf.Abs(Sr [i].transform.position.z-TagPos.z)<=0.1) {
            //						On = true;
            //						//Debug.Log (i);
            //					}
            //				}
            //				if (On == false) {
            //					gosh.transform.position = TagPos;
            //				}
            //				On = false;
            //			}
            //			if (Input.GetKeyDown (KeyCode.D)) {
            //				Vector3 TagPos = new Vector3 (gosh.transform.position.x+1,gosh.transform.position.y,gosh.transform.position.z);
            //				for (int i = 0; i <= Sr.Length - 1; i++) {
            //					//Debug.Log (i);
            //					if (Mathf.Abs(Sr [i].transform.position.x-TagPos.x)<=0.1+missless&&Mathf.Abs(Sr [i].transform.position.z-TagPos.z)<=0.1) {
            //						On = true;
            //						//Debug.Log (i);
            //					}
            //				}
            //				if (On == false) {
            //					gosh.transform.position = TagPos;
            //				}
            //				On = false;
            //			}
        }
	}
	void OnTriggerStay(Collider hit){
		if (hit.tag == "MoveObject") {
			gosh = hit.gameObject;
			if (gosh.name == "chair1"||gosh.name == "chair2"||gosh.name == "chair3"||gosh.name == "chair4"||gosh.name == "chair5"||gosh.name == "chair6") {
				missless = 0;
			}
			if (gosh.name == "desk12"||gosh.name == "desk22") {
				missless = 1.0f;
			}
			if (gosh.name == "desk13"||gosh.name == "desk23") {
				missless = 1.5f;
			}
		}
	}
	void OnTriggerExit(Collider hit){
		gosh = null;
	}
}
