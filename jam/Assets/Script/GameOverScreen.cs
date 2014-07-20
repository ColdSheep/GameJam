using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject infoSphere = GameObject.FindGameObjectWithTag("Respawn");
		
		if(infoSphere)
		{
			InfoSphere info = (InfoSphere)infoSphere.GetComponent("InfoSphere");
			
			score = info.m_finalScore;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/2,Screen.height/2,100,100), string.Format("Score: {0}", score));
	}

	public int score = 0;
}
