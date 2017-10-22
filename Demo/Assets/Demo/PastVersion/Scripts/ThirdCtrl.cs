using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCtrl : MonoBehaviour {
	public GameObject Tager, Caamera,FirstViewCamera,Tri;
	//public GameObject[] Light;
	float DeltaSpeed;
	float Speed=0.1f;
	CharacterController chr;
	Vector3 CR1;
    float sensitivityX = 10F;  
    float sensitivityY = 10F;  
    float minimumY = -60F; 
    float maximumY = 60F; 
	float far=60;
	float rotationY = 0F;
	bool quick,TF;
    public GameObject Bag;
	// Use this for initialization
	void Start () {
		chr = Tager.transform.parent.gameObject.GetComponent<CharacterController> ();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey ||Tager.transform.position!= Caamera.transform.position) {
			Floow (Tager, Caamera);
		}
		Move (Caamera,chr, Speed);
		FirstCameraRoat (Caamera,Tager.transform.parent.gameObject,Tager);
		//Looat (Caamera, Tager);
		if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
			far += Input.GetAxis ("Mouse ScrollWheel");
			SetCameraSize (Caamera, far);
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			//Quick (FirstViewCamera, Caamera);
		}
		if (Input.GetMouseButtonDown (0)) {
			CR1 = Tager.transform.parent.transform.position;
		}
		if (Input.GetKey (KeyCode.Space)) {
			MoveTager (Tri);
			//LightUp ();
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			Tri.active = false;
			//Light [0].GetComponent<BoxCollider> ().enabled = false;
			//Light [1].GetComponent<BoxCollider> ().enabled = false;
			//Light [2].GetComponent<BoxCollider> ().enabled = false;
			//Light [3].GetComponent<BoxCollider> ().enabled = false;
		}
        if (Input.GetKeyDown(KeyCode.B))
        {

            OpenBag();
        }
	}
	void Floow(GameObject Tager,GameObject Caamera){
		DeltaSpeed = (Mathf.Abs (Tager.transform.position.x - Caamera.transform.position.x) + Mathf.Abs (Tager.transform.position.y - Caamera.transform.position.y) + Mathf.Abs (Tager.transform.position.z - Caamera.transform.position.z)) / 3;
		Caamera.transform.position = Vector3.MoveTowards (Caamera.transform.position, new Vector3 (Tager.transform.position.x, Tager.transform.position.y, Tager.transform.position.z), DeltaSpeed);
	}
	void Move(GameObject Caamera,CharacterController chr,float Speed){
		chr.Move (Vector3.down * 9.8f);
		if (Input.GetKey (KeyCode.W)) {
			if (Input.GetKey (KeyCode.LeftControl)) {
				chr.Move (Caamera.transform.forward * 0.01f);
			}else{
				chr.Move (Caamera.transform.forward * Speed);
				}
		}
		if (Input.GetKey (KeyCode.S)) {
			if (Input.GetKey (KeyCode.LeftControl)) {
				chr.Move (Caamera.transform.forward * -0.01f);
			}else{
				chr.Move (Caamera.transform.forward * -Speed);
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			if (Input.GetKey (KeyCode.LeftControl)) {
				chr.Move (Caamera.transform.right * -0.01f);
			}else{
				chr.Move (Caamera.transform.right * -Speed);
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if (Input.GetKey (KeyCode.LeftControl)) {
				chr.Move (Caamera.transform.right * 0.01f);
			}else{
				chr.Move (Caamera.transform.right * Speed);
			}
		}
	}
	void Looat(GameObject Caamera,GameObject Tager){
		Caamera.transform.LookAt (Tager.transform);
	}
	void FirstCameraRoat(GameObject Cammera,GameObject Tager,GameObject TagerSon){
		float rotationX = Tager.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX; 

		//根据鼠标移动的快慢(增量), 获得相机上下旋转的角度(处理Y) 
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY; 
		//角度限制. rotationY小于min,返回min. 大于max,返回max. 否则返回value  
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY); 

		//总体设置一下相机角度 
		Caamera.transform.localEulerAngles = new Vector3(-rotationY,TagerSon.transform.eulerAngles.y , 0);
		Tager.transform.localEulerAngles = new Vector3(0, rotationX, 0);
		FirstViewCamera.transform.rotation = Caamera.transform.rotation;
	}
	void SetCameraSize(GameObject Caamera,float far){
		//if (Caamera.GetComponent<Camera> ().orthographicSize >= 1) {
			Caamera.GetComponent<Camera> ().orthographicSize = far;
			Debug.Log (Caamera.GetComponent<Camera> ().orthographicSize);
		//}
	}
	void Quick(GameObject FirstViewCamera,GameObject ThirdViewCamera){
		if (quick == false) {
			ThirdViewCamera.active = false;
			FirstViewCamera.active = true;
			quick = true;
			return;
		}
		if (quick == true) {
			ThirdViewCamera.active = true;
			FirstViewCamera.active = false;
			quick = false;
			return;
		}
	}
	void MoveTager(GameObject Tri){
		//RaycastHit hit ;
		//Vector2 v= new Vector2(Screen.width/2, Screen.height/2); 
		//if (Physics.Raycast (Caamera.GetComponent<Camera> ().ScreenPointToRay (v), out hit)) {
			//if (hit.collider.name == "chair" || hit.collider.name == "desk") {
				//hit.collider.gameObject.transform.position = new Vector3 (hit.collider.gameObject.transform.position.x + CR1.x - Tager.transform.position.x,
				//	hit.collider.gameObject.transform.position.y + CR1.y - Tager.transform.position.y,
				//	hit.collider.gameObject.transform.position.z + CR1.z - Tager.transform.position.z
				//);

		//	}
	//	}
		Tri.active=true;
	}
	void DesAni(){
		GetComponent<Animator> ().enabled = false;
	}
	void OpenBag(){
        if (TF == true)
        {
            TF = false;
            Bag.active = false;
            Cursor.visible = false;
            return;
        }
        if (TF == false)
        {
            TF = true;
            Bag.active = true;
            Cursor.visible = true;
            return;
        }
    }
}
