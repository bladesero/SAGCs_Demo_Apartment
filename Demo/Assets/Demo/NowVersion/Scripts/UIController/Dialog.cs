using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Xml;
using System.IO;

public class Dialog : MonoBehaviour {
	public Text m_DialogBox;//对话框文本
	public List<XmlElement> scene = new List<XmlElement> ();
	public List<XmlElement> item = new List<XmlElement> ();

	public bool m_scriptON=true;

	private int m_scenePtr=0;//场景指针
	private int m_sectionPtr=0;//段落指针
	private int m_sentencePtr=0;//文本指针

	// Use this for initialization
	void Start () {
		LoadXml ();
	}
	
	// Update is called once per frame
	void Update () {
		DialogClick ();
	}

	public void LoadXml()//载入xml
	{
		string m_tmpstring = string.Empty;
		XmlDocument xml = new XmlDocument ();

		try{
		string dialog = Resources.Load ("StoryScript").ToString();
		xml.LoadXml (dialog);

			xmlParse (xml);
		}catch{

		}
	}

	void xmlParse (XmlDocument xmlDoc){//对xml文件进行解析，结果存入静态列表
		XmlNodeList xmlNodeList = xmlDoc.SelectSingleNode ("storyScript").ChildNodes;
		foreach (XmlElement xmlE1 in xmlNodeList) {
			if (xmlE1.Name == "scene")//场景
				scene.Add (xmlE1);
			if (xmlE1.Name == "item")
				item.Add (xmlE1);
		}
	}

	string DialogTextParse (int sceneIndex, int sectionIndex, int sentenceIndex){//调用此方法从列表中返回当前对话文本
		string tmpString = string.Empty;
		tmpString = scene [sceneIndex].ChildNodes [sectionIndex].ChildNodes [sentenceIndex].Attributes ["character"].Value.ToString () +':'+
			scene [sceneIndex].ChildNodes [sectionIndex].ChildNodes [sentenceIndex].InnerText;

		return tmpString;
	}



	void DialogClick(){
		if (Input.GetMouseButtonDown (0)) {
			m_DialogBox.text = DialogTextParse (m_scenePtr, m_sectionPtr, m_sentencePtr);

			if (m_sentencePtr < scene [m_scenePtr].ChildNodes [m_sectionPtr].ChildNodes.Count - 2)
				m_sentencePtr++;
			Debug.Log (m_sentencePtr);
		}
	}
}
