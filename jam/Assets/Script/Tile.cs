using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile: MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		TextMesh[] textMeshes = gameObject.GetComponentsInChildren<TextMesh>();
				
		foreach(TextMesh t in textMeshes)
		{
			if(t.tag == "fText")
			{
				t.text = string.Format("{0}",m_numberAdjacentFossils);
			}
			else
			{
				t.text = string.Format("{0}",m_numberAdjacentTraps);
			}

		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void AddAdjacentTile(Tile newTile)
	{
		if(newTile.gameObject.tag != "dirtTile")
		{
			return;
		}

		if(m_AdjacentTiles == null)
		{
			m_AdjacentTiles = new List<Tile>();
		}

		if(newTile.IsFossil())
		{
			m_numberAdjacentFossils++;
		}
		else if(newTile.IsTrap())
		{
			m_numberAdjacentTraps++;
		}

		m_AdjacentTiles.Add(newTile);
	}

	public bool IsTrap()
	{
		return TileValue < 0;
	}

	public bool IsFossil()
	{
		return TileValue > 0;
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

	public void ClearText()
	{
		TextMesh[] textMeshes = gameObject.GetComponentsInChildren<TextMesh>();
		
		foreach(TextMesh t in textMeshes)
		{
			t.text = "";
		}
	}

	private List <Tile> m_AdjacentTiles;
	private int m_tileValue = 0;
	private int m_numberAdjacentTraps = 0;
	private int m_numberAdjacentFossils = 0;
}
