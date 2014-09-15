using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace jam
{

	public class GameManager : MonoBehaviour {

		// Use this for initialization
		void Start () 
		{
			float x = 0.0f;
			float y = 0.0f;
			float z = 0.0f;

			Debug.Log(string.Format("Create grid with percentages: Fossil - {0}, Trap - {1}, Empty - {2}", PERCENT_FOSSIL, PERCENT_TRAP, PERCENT_EMPTY));

			GameObject playerQuad = (GameObject)Instantiate(Resources.Load("PlayerQuad"));
			playerQuad.transform.position = new Vector3(x,y+3,z-1);

			BuildGrid(15, 11, 2.0f);
		}

		// Update is called once per frame
		void Update () 
		{
		
		}

		void DestroyBoard()
		{
			foreach(Tile t in m_gameTiles)
			{
				Destroy(t.gameObject);
			}
		}

		void BuildGrid(int width, int height, float tileSize)
		{
			Debug.Log ("Creating Grid");

			m_gameTiles = new List<Tile>();

			float x = 0.0f;
			float y = 0.0f;
			float z = 0.0f;

			for(int i = 0; i < height; ++i)
			{
				for(int j = 0; j < width; ++j)
				{
					GameObject aTile; 

					if(j == 0 || j == (width-1) || i == (height-1))
					{
						aTile = (GameObject)Instantiate(Resources.Load("BorderTile"));
					}
					else
					{
						aTile = (GameObject)Instantiate(Resources.Load("Tile"));
					}

					Tile tileScript = (Tile)aTile.GetComponent("Tile");

					m_gameTiles.Add(tileScript);

					if(tileScript.gameObject.tag == "dirtTile")
					{

						//Determine randomly what kind of tile it is
						float randValue = Random.Range(0.0f, 1.0f);

						if(randValue <= PERCENT_FOSSIL)
						{
							//Fossil
							tileScript.TileValue = FOSSIL_VALUE;
						}
						else if(randValue <= PERCENT_TRAP + PERCENT_FOSSIL)
						{
							//Trap 
							tileScript.TileValue = TRAP_VALUE;
						}
						else
						{
							//Empty
						}

						// Perform linking of tiles
						if(i > 0)
						{
							Tile aboveTile = (Tile)m_gameTiles[(i-1) * width + j];
							tileScript.AddAdjacentTile(aboveTile); //Link the tile above the current tile
							aboveTile.AddAdjacentTile(tileScript);

							if(j > 0)
							{
								Tile aboveLeftTile = (Tile)m_gameTiles[(i-1) * width + (j-1)];
								tileScript.AddAdjacentTile(aboveLeftTile); //Link the tile above the current tile
								aboveLeftTile.AddAdjacentTile(tileScript);
							}

							if(j < width-1)
							{
								Tile aboveRightTile = (Tile)m_gameTiles[(i-1) * width + (j+1)];
								tileScript.AddAdjacentTile(aboveRightTile); //Link the tile above the current tile
								aboveRightTile.AddAdjacentTile(tileScript);
							}
						}

						if(j > 0)
						{
							Tile leftTile = (Tile)m_gameTiles[i * width + (j-1)];
							tileScript.AddAdjacentTile(leftTile); //Link the tile left of the current tile
							leftTile.AddAdjacentTile(tileScript); 
						}


					}
					else
					{
						//Debug.LogError(string.Format("This tile has no associated script:{0},{1}", i, j));
					}
					
					aTile.transform.position = new Vector3(x,y,z);
					x += tileSize;
				}

				x = 0.0f;
				y -= tileSize;
			}

		}
		
		const float PERCENT_FOSSIL = 0.4f; //Percent chance of a Treasure tile being created
		const float PERCENT_TRAP = 0.2f; //Percent chance of a Trap tile being created
		const float PERCENT_EMPTY = 0.4f; //Percent chance of an Empty tile being created

		const int FOSSIL_VALUE = 200;
		const int TRAP_VALUE = -100;

		public List<Tile> m_gameTiles;
	}

}