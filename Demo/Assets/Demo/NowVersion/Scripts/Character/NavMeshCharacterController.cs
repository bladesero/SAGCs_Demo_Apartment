using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
public class NavMeshCharacterController : MonoBehaviour {
	//public GameObject m_Player;
	public Camera m_Cam;
	public Transform markerPlace;
	NavMeshAgent m_NavAgent;
	public bool m_scriptON = true;

	// Use this for initialization
	void Start () {
		m_NavAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_scriptON)
			MoveAfterJudge ();
	}

	void Move(){//射线检测点击位置并移动
		Ray ray = m_Cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		LayerMask mask = 1 << 9;
		if (Physics.Raycast (ray, out hit, Mathf.Infinity,mask,QueryTriggerInteraction.Ignore)) {
			markerPlace.position = hit.point;
			m_NavAgent.SetDestination (markerPlace.position);
		}
		RaycastHit[] hits;
		hits = Physics.RaycastAll (ray, Mathf.Infinity);
	}

	void MoveAfterJudge(){//判断点击在3d物体还是UI上
		if (Input.GetButtonDown ("Fire1")) {
			if (EventSystem.current.IsPointerOverGameObject ()) {
				//Debug.Log ("clickOnUI");
			} else {
				Move ();
			}
		}
	}
}
