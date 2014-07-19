using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile: MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Debug.Log(string.Format("Adjacent Fossils: {0}",m_numberAdjacentFossils));

		if(TileValue > 0)
		{
			renderer.material.color = Color.green;
		}
	 	else if(TileValue < 0)
		{
			renderer.material.color = Color.red;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddAdjacentTile(Tile newTile)
	{

		if(m_AdjacentTiles == null)
		{
			m_AdjacentTiles = new List<Tile>();
		}

		if(newTile.TileValue > 0)
		{
			m_numberAdjacentFossils++;
		}
		else if(newTile.TileValue < 0)
		{
			m_numberAdjacentTraps++;
		}

		m_AdjacentTiles.Add(newTile);
	}


	public int TileValue
	{
		get
		{
			return m_tileValue;
		}

		set
		{
			m_tileValue = value; 
		}
	}

	private List <Tile> m_AdjacentTiles;
	private int m_tileValue = 0;
	private int m_numberAdjacentTraps = 0;
	private int m_numberAdjacentFossils = 0;
}
