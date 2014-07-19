using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile {

	// Use this for initialization
	void Start () 
	{
		m_AdjacentTiles = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddAdjacentTile(GameObject newTile)
	{
		m_AdjacentTiles.Add(newTile);
	}
	
	private List <GameObject> m_AdjacentTiles;
}
