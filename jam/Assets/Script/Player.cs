using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_controller = (CharacterController)this.GetComponent("CharacterController");
		Vector3 dir;

		if(Input.GetKey(KeyCode.A))
		{
			dir = new Vector3(-SPEED,0,0);
			m_controller.SimpleMove(dir);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			dir = new Vector3(SPEED,0,0);
			m_controller.SimpleMove(dir);
		}


		if(Input.GetKeyDown(KeyCode.DownArrow))
		{

		}
	}

	private CharacterController m_controller;

	public const float SPEED = 4.0f;
}
