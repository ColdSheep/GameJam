using UnityEngine;
using System.Collections;

namespace jam
{

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
		GUI.Label(new Rect(Screen.width/2-50,Screen.height/4,100,100), string.Format("Score: {0}", score));

		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 + 50 + 40,100,40),"Restart"))
		{
			Application.LoadLevel("GameScene");
		}
		
		//if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 + 50 + 85,100,40),"Quit"))
		//{
		//	Application.Quit();
		//}
	}

	public int score = 0;
}

}