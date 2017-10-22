using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour {

	public bool trigger=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		B2T ();
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void LoadFirstScene()
	{
		SceneManager.LoadScene ("build/1");
	}

	public void B2T()
	{
		if(trigger)
			SceneManager.LoadScene ("build/title");
	}
}
