﻿using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2-80,Screen.height/2,100,60),"Start"))
		{
			Application.LoadLevel("GameScene");
		}
	}
}
