using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameState{//游戏状态变量
	string CurrentString;
	string CurrentTime;
	int CurrentScene;

	float SEVolume;//环境音量
	float BGMVolume;//背景音乐音量
};

public class GameManager : MonoBehaviour {
	public GameState m_gameState;
	[SerializeField]GameObject m_Player;
	[SerializeField]List<GameObject> m_NPC;
	[SerializeField]List<GameObject> m_Item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
