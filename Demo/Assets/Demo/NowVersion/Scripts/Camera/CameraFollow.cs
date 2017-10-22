using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public enum MoveType {//移动方式，匀速，匀加速
		ConstantSpeed,
		Vector3Lerp,
	}

	public Transform m_player;//玩家位置
	public Transform m_FocusPosition;//事件焦点位置
	public bool switchvalue=false,scriptON=true;
	Vector3 m_tmpPosition=Vector3.zero;
	[SerializeField]public MoveType m_MoveType=0;
	[SerializeField][Range(0.01f,1f)]public float m__SwitchSpeedConstant=1f;//匀速切换速度
	[SerializeField][Range(0.1f,10f)]public float m__SwitchSpeedLerp=1f;//匀加速切换速度

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (scriptON)
			SetTargetInScreenMid (PlayerFocusSwitch ());
	}

	public void SetTargetInScreenMid(Transform obj){//将目标设置在屏幕中心
		m_tmpPosition = new Vector3 (obj.position.x - 11f, 10f, obj.position.z - 11f);
		if (m_MoveType == MoveType.ConstantSpeed)
			this.transform.position = Vector3.MoveTowards (this.transform.position, m_tmpPosition, m__SwitchSpeedConstant);
		if (m_MoveType == MoveType.Vector3Lerp)
			this.transform.position = Vector3.Lerp (this.transform.position, m_tmpPosition, Time.deltaTime * m__SwitchSpeedLerp);
	}

	Transform PlayerFocusSwitch(){//摄像机跟随的转换，switchvalue=false,摄像头跟随玩家，switchvalue=true,摄像头跟随事件焦点
		if (switchvalue) {
			return m_FocusPosition;
		} else {
			return m_player;
		}
	}
}
