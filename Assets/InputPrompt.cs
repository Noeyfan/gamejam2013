using UnityEngine;
using System.Collections;

public class InputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	private string buffer = "";
	private OutputPrompt output;

	void Start() {
		output = GameObject.Find ("OutputPrompt").GetComponent<OutputPrompt> ();
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey && e.keyCode == KeyCode.Return) {
			eval(buffer);
			buffer = "";
		}
		buffer = GUI.TextField (new Rect (screenPositionX, screenPositionY, Screen.width, 20), buffer);
	}
	
	void eval(string cmd) {
		if (cmd == "") {
			return;
		}
		output.content = "Simple echo: " + cmd;
	}
}
