using UnityEngine;
using System.Collections;

public class InputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	public DialogueBehavior talkingTo;
	private OutputPrompt output;
	private string buffer = "";
	public Font font;
	public GUIStyle gui_style;

	void Start() {
		output = GameObject.Find ("OutputPrompt").GetComponent<OutputPrompt> ();
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey && e.keyCode == KeyCode.Return) {
			eval(buffer);
			buffer = "";
		}
		//guiText.font = font;
		buffer = GUI.TextField (new Rect (screenPositionX, screenPositionY, Screen.width, 20), buffer, gui_style);
	}
	
	void eval(string cmd) {
		if (cmd == "") {
			return;
		}
		talkingTo.Talk (cmd);
	}
}
