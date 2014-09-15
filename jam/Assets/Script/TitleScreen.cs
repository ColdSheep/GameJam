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
				int boxWidth = 580;
				int boxHeight = 340;

				string t = "Instructions:\n You are an archaeologist looking for ancient dinosaur fossils- on a budget! Dig your way looking for the jurassic money makers by avoiding traps, which makes your budget smaller by medical bills to heal, and gaining the big dollars finding them bones! You do this by uncovering the blocks that contain fossils (Green Blocks) while avoiding the blocks that contain traps (Red Blocks).\n\n" +
					       "The Blocks:\n On each dirt block there are two numbers. The top number in black is the number of fossils that are adjacent to the current block, The bottom number in white is the number of traps that are adjacent to the block.\n\n" +
						   "End Game:\n The game is over when you either run out of money or choose to end the game by pressing the 'End Game' button in the upper left of the screen. The final score is the number of fossils you revealed multiplied by 200 plus your ending fund balance.\n\n" +
						   "Controls:\n" +
						   "'A' = Move Left\n" +
						   "'D' = Move Right\n" +
						   "Left Arrow = Dig Left\n" +
						   "Right Arrow = Dig Right\n" +
						   "Down Arrow = Dig Down";
				GUI.TextArea(new Rect(Screen.width/2-boxWidth/2,Screen.height/12, boxWidth, boxHeight), t);

				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/12 + boxHeight + 10,100,40),"Back"))
				{
					showInstructions = false;
				}
			}
			else if(showCredits)
			{
				int boxWidth = 400;
				int boxHeight = 200;

				string t = "Credits:\n\n" +
						   "Programming: Dominic Galasso\n\n" +
						   "Art & Design: Shawna Davis";
				GUI.TextArea(new Rect(Screen.width/2-boxWidth/2,Screen.height/10, boxWidth, boxHeight), t);

				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/10 + boxHeight + 10,100,40),"Back"))
				{
					showCredits = false;
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

				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+90,100,40),"Credits"))
				{
					showCredits = true;
				}
			}
		}

		bool showInstructions = false;
		bool showCredits = false;
	}

}