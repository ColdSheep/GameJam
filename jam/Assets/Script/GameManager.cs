using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		BuildGrid(10, 10, 1.0f);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	void BuildGrid(int width, int height, float tileSize)
	{
		Debug.Log ("Creating Grid");

		m_gameTiles = new List<GameObject>();

		float x = 0.0f;
		float y = 0.0f;
		float z = 0.0f;

		for(int i = 0; i < height; ++i)
		{
			for(int j = 0; j < width; ++j)
			{
				GameObject aTile = (GameObject)Instantiate(Resources.Load("Tile"));

				aTile.transform.position = new Vector3(x,y,z);
				x += tileSize / 2.0f;
			}

			x = 0.0f;
			y += tileSize / 2.0f;
		}

	}

	const float PERCENT_TREASURE = 0.4f;
	const float PERCENT_TRAP = 0.2f;
	const float PERCENT_EMPTY = 0.4f;

	public List<GameObject> m_gameTiles;
}
