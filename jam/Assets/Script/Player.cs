﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		m_controller = (CharacterController)this.GetComponent("CharacterController");
	}

	bool IsGameOver()
	{
		return m_currentBudget <= 0;
	}

	// Update is called once per frame
	void Update () 
	{

		if(!IsGameOver())
		{
			if( m_controller.isGrounded )
			{
				m_moveDirection = new Vector3 ( Input.GetAxis("Horizontal"), 0.0f, 0.0f);
				m_moveDirection = transform.TransformDirection( m_moveDirection);
				m_moveDirection *= m_speed;

				//Check to see if the player wants to dig
			}
			else
			{
				m_moveDirection.x = Input.GetAxis( "Horizontal" );
				m_moveDirection.x *= m_speed;
			}

			RaycastHit hit = new RaycastHit();

			if(Input.GetKeyDown(KeyCode.E))
			{
				Vector3 direction = new Vector3(1.0f,0.0f, 0.0f);

				if( GetAdjacentBlock(direction, out hit) )
				{
					ProcessHit(hit);
				}
			}

			if(Input.GetKeyDown(KeyCode.Q))
			{
				Vector3 direction = new Vector3(-1.0f,0.0f, 0.0f);
				
				if( GetAdjacentBlock(direction, out hit) )
				{
					ProcessHit(hit);
				}
			}

			if(Input.GetKeyDown(KeyCode.S))
			{
				Vector3 direction = new Vector3(0.0f,-1.0f, 0.0f);
				
				if( GetAdjacentBlock(direction, out hit) )
				{
					ProcessHit(hit);
				}
			}
		}
		else
		{
			renderer.enabled = false;
		}

		m_moveDirection.y -= m_gravity * Time.deltaTime;
		m_controller.Move( m_moveDirection * Time.deltaTime );
	}

	void ProcessHit(RaycastHit hit)
	{
		if(hit.collider.gameObject.tag == "dirtTile")
		{
			m_currentBudget -= DIG_COST;
			Tile h = (Tile)hit.collider.gameObject.GetComponent("Tile");
			m_currentBudget += h.TileValue;

			if(h.TileValue > 0)
			{
				//Display that you recieved a fossil
				hit.collider.gameObject.renderer.material.color = Color.green;
			}
			else if(h.TileValue < 0)
			{
				//Display that you recieved a trap
				hit.collider.gameObject.renderer.material.color = Color.red;
			}

			hit.collider.gameObject.transform.position = hit.collider.gameObject.transform.position + new Vector3(0,0,2.2f);
			//Destroy(hit.collider.gameObject);
		}
	}

	bool GetAdjacentBlock(Vector3 rayDirection, out RaycastHit hit)
	{
//		hit = new RaycastHit();

		if(Physics.Raycast(transform.position, rayDirection, out hit, 1.0f))
		{
			Debug.Log(hit.collider.gameObject);
			return true;
		}

		return false;
	}

	void OnGUI()
	{
		if(IsGameOver())
		{

		}
		else
		{
			GUI.Label(new Rect(10,10,140,40), string.Format("Budget: ${0}",m_currentBudget));
		}

		if(GUI.Button(new Rect(100,10,100,40), "Reset Game"))
		{
			Application.LoadLevel("GameScene");
		}
	}

	private CharacterController m_controller;
	private Vector3 m_moveDirection = Vector3.zero;
 
	public int DIG_COST = 150;

	public float m_speed = 4.0f;
	public float m_gravity = 20.0f;
	public int m_currentBudget;
}
