using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSelected : MonoBehaviour {
	Rigidbody m_rigidbody;
	Camera m_camera;
	public bool m_isSelected = false;
	public bool m_dragable=true;//是否可拖动
	public bool m_scriptON = true;//脚本开关
	bool m_IsOnUI=false;

	// Use this for initialization
	void Start () {
		m_rigidbody = this.GetComponent<Rigidbody> ();
		m_camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_scriptON)
			SelectCancel ();
	}

	void OnMouseDown(){//选中物体
		if (m_scriptON)
			m_isSelected = true;
	}

	void OnMouseDrag(){//移动物体
		if (m_scriptON&&m_dragable) {
			DragAfterJudge ();
			if (!m_IsOnUI) {
				Ray ray = m_camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				LayerMask mask = 1 << 9;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, mask, QueryTriggerInteraction.Ignore)) {
					Vector3 movPos = new Vector3 (hit.point.x, 0.5f, hit.point.z);
					m_rigidbody.MovePosition (movPos);
				}
			}
		}
	}

	void SelectCancel(){//未选择物体
		if (Input.GetButtonDown ("Fire1")&&!m_IsOnUI) {
			Ray ray = m_camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			LayerMask mask = 1 << 10;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity, mask, QueryTriggerInteraction.Ignore)) {
				if (hit.collider.gameObject != this.gameObject)
					m_isSelected = false;
			} else
				m_isSelected = false;
		}
	}

	public GameObject SendObjectToSelectManager(){
		if (m_isSelected == true)
			return this.gameObject;
		else
			return null;
	}

	void DragAfterJudge(){//判断点击在3d物体还是UI上
		if (EventSystem.current.IsPointerOverGameObject ()) {
			m_IsOnUI = true;
		} else {
			m_IsOnUI = false;
			}
	}
}
