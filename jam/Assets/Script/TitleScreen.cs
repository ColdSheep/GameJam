using UnityEngine;
using System.Collections;

namespace jam
{

	public class TitleScreen : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnGUI()
		{
			if(showInstructions)
			{
				int boxWidth = 550;
				int boxHeight = 325;

				string t = "Instructions:\n You are a palentologist who's goal is to dig as many fossils as you can before you run out of funds. You do this by uncovering the blocks that contain fossils while avoiding the blocks that contain traps. Each block that you dig costs money. If the block uncovers a fossil (Green Block) then you gain a bonus and if the block uncovers a trap (Red Block) then you are penalized.\n\n" +
					       "The Blocks:\n On each dirt block there are two numbers. The top number in black is the number of fossils that are adjacent to the current block, The bottom number in white is the number of traps that are adjacent to the block.\n\n" +
						   "End Game:\n The game is over when you either run out of money or choose to end the game by pressing the 'End Game' button in the upper left of the screen. The funal score is the number of fossils you revealed multiplied by 200 plus your ending fund balance.\n\n" +
						   "Controls:\n" +
						   "Left Arrow = Move/Dig Left\n" +
						   "Right Arrow = Move/Dig Right\n" +
						   "Down Arrow = Move/Dig Down";
				GUI.TextArea(new Rect(Screen.width/2-boxWidth/2,Screen.height/10, boxWidth, boxHeight), t);

				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/10 + boxHeight + 10,100,40),"Back"))
				{
					showInstructions = false;
				}
			}
			else
			{
				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2,100,40),"Start"))
				{
					Application.LoadLevel("GameScene");
				}

				//if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+45,100,40),"Quit"))
				//{
				//	Application.Quit();
				//}

				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+45,100,40),"Instructions"))
				{
					showInstructions = true;
				}
			}
		}

		bool showInstructions = false;
	}

}