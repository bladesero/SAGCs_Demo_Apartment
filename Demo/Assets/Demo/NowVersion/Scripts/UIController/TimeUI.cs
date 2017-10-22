using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (TimeCount))]
public class TimeUI : MonoBehaviour {
	[Range(0,23)]public int m_hour = 0;
	[Range(0,59)]public int m_minute = 0;

	int m_tmpHour = 0;
	int m_tmpMinute = 0;

	bool m_timeflag=false;
	TimeCount m_counter;
	string timeText;
	public Text m_text;
	Animator m_animator;

	// Use this for initialization
	void Start () {
		m_counter = GetComponent<TimeCount> ();
		m_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!m_timeflag)
			m_timeflag = m_counter.wait (3f);

		ChangeTimeText ();

		if (m_timeflag)
			UIFadeOut ();
	}

	void ChangeTimeText(){//时间闪烁动画
		if (!m_timeflag) {
			m_tmpHour = Random.Range (0, 23);
			m_tmpMinute = Random.Range (0, 59);
		} else {
			m_tmpHour = m_hour;m_tmpMinute = m_minute;
		}
		if (m_tmpHour < 10 && m_tmpMinute < 10)
			timeText = '0' + m_tmpHour.ToString () + ':' + '0' + m_tmpMinute.ToString ();
		if (m_tmpHour > 10 && m_tmpMinute < 10)
			timeText = m_tmpHour.ToString () + ':' + '0' + m_tmpMinute.ToString ();
		if (m_tmpHour < 10 && m_tmpMinute > 10)
			timeText = '0' + m_tmpHour.ToString () + ':' + m_tmpMinute.ToString ();
		if (m_tmpHour > 10 && m_tmpMinute > 10)
			timeText = m_tmpHour.ToString () + ':' + m_tmpMinute.ToString ();

		m_text.text = timeText;
	}

	public void UIFadeOut(){//UI淡出，动画机控制时间
		m_animator.SetBool("FalloutFlag",m_timeflag);

		if (m_text.color.a < 0.03f)
			this.gameObject.SetActive (false);
	}

}
