using UnityEngine;
using System.Collections;

public class OutputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	public string content;
	
	void OnGUI() {
		GUI.Label(new Rect(screenPositionX, screenPositionY, Screen.width, 20), content);
	}
}
