using UnityEngine;
using System.Collections;

public class InputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	private DialogueBehavior talkingTo;
	private GameObject player;
	private OutputPrompt output;
	private string buffer = "";
	public GUIStyle gui_style;

	private bool justSwitched;

	void Start() {
		GUI.SetNextControlName("main");
		output = GameObject.Find ("OutputPrompt").GetComponent<OutputPrompt> ();
		player = GameObject.Find ("player");
	}

	void OnGUI() {
		GUI.SetNextControlName("input");
		buffer = GUI.TextField (new Rect (screenPositionX, screenPositionY, Screen.width, 20), buffer, gui_style);
		if (GUI.GetNameOfFocusedControl() == "input") {
			Event e = Event.current;
			if (e.isKey && e.keyCode == KeyCode.I && justSwitched) {
				justSwitched = false;
				buffer = "";
				output.SendEvent("EnterCommandLine");
			}
			if (e.isKey && e.keyCode == KeyCode.Return) {
				eval(buffer);
				buffer = "";
			}
			if (e.isKey && e.keyCode == KeyCode.Escape) {
				GUI.FocusControl("main");
				output.SendEvent("BackToNormal");
				buffer = "";
			}
		} else {
			if (Input.GetKey(KeyCode.I)) {
				justSwitched = true;
				GUI.FocusControl("input");
			}
		}
	}
	
	void eval(string cmd) {
		if (cmd == "") {
			return;
		}
		output.SendEvent (cmd);
		if (talkingTo != null) {
			talkingTo.Talk (cmd);
		}
	}

	public void SetTalkTo(string name) {
		if (talkingTo != null) {
			talkingTo.Deactivate();
		}

		try {
			var tar = GameObject.Find (name);
			talkingTo = tar.GetComponent<DialogueBehavior> ();
			Debug.Log ((player.transform.position - tar.transform.position).magnitude);
			if ((player.transform.position - tar.transform.position).magnitude <= talkingTo.talkRange) {
				talkingTo.Activate ();
				output.SendEvent("");
			} else {
				output.SendEvent("Oops: " + name + " is too far away");
			}
		} catch {
			output.SendEvent("Oops: " + name + " not found");
		}
	}
}
