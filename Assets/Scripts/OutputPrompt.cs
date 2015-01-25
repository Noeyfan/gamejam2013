using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	public Font font;
	private string content = "Hello there! I am The Narrator. Please press 'i' to enter *command line mode*.";
	
	private Dictionary<string, bool> worldState = new Dictionary<string, bool>() {
		{"NeverEnterCommandLine", true},
		{"NeverBackToNormal", true},
	};

	void OnGUI() {
		GUI.Label(new Rect(screenPositionX, screenPositionY, Screen.width, 40), content);
		GUI.skin.font = font;
	}

	public void OnTalkState(DialogueBehavior d) {
		if (d.InState ("I'm")) {
			content = "He lies.";
		}
	}

	public void SendEvent(string cmd) {
		if (cmd == "pwd") {
			content = "/dev/mem";
		} else if (cmd == "ls") {
			content = "Unimplemented: Where are we?";
		} else if (cmd == "gossip") {
			content = RandomGossip();
		} else if (cmd == "fuck you") {
			content = "Fuck me? Well... die fool!";
		} else if (cmd == "What can change the nature of a man?") {
			content = "The official answer is \"Regret\", right?";
		} else if (cmd == "EnterCommandLine") {
			if (worldState["NeverEnterCommandLine"]) {
				worldState["NeverEnterCommandLine"] = false;
				content = "Well done! To switch back to normal mode, press 'esc'.";
			}
		} else if (cmd == "BackToNormal") {
			if (worldState["NeverBackToNormal"]) {
				worldState["NeverBackToNormal"] = false;
				content = "Try typing `help` in command line mode";
			}
		} else if (cmd == "help") {
			content = "Commands: talk `name`";
		} else if (cmd.StartsWith("talk ")) {
			var target = cmd.Substring("talk ".Length);
			target = target.ToLower();
			GameObject.Find("InputPrompt").GetComponent<InputPrompt>().SetTalkTo(target);
		} else {
			content = cmd;
		}
	}

	string RandomGossip() {
		return "Unimplemented: random gossip";
	}
}
