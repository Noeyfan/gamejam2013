using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	//public Font font;
	public GUIStyle gui_style;
	private string content = "Hello there! I am The Narrator. Please press 'i' to enter *command line mode*.";
	
	private Dictionary<string, bool> worldState = new Dictionary<string, bool>() {
		{"NeverEnterCommandLine", true},
		{"NeverBackToNormal", true},
	};

	void OnGUI() {
		GUI.Label(new Rect(screenPositionX, screenPositionY, Screen.width, 40), content, gui_style);
		//GUI.skin.font = font;
	}

	public void OnTalkState(DialogueBehavior d) {
		if (d.InState ("I'm")) {
			content = "He lies.";
		} else if (d.InState ("where")) {
			content = "Well... You can call it \"Fortress of Regrets\". Don't ask me why this name.";
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
				content = "Try typing `help` to get available commands.";
			}
		} else if (cmd == "help") {
			content = "commands: `gen key`, `gen box`, `talk {target name}`";
		} else if (cmd.StartsWith("talk ")) {
			var target = cmd.Substring("talk ".Length);
			target = target.ToLower();
			GameObject.Find("InputPrompt").GetComponent<InputPrompt>().SetTalkTo(target);
		} else if (cmd.StartsWith("gen ")) {
			var l = GameObject.Find("Level1");
			if (l == null) {
				return;
			}
			if (cmd == "gen key") {
				l.GetComponent<level1Controller>().dropKey();
				content = "Only one key opens the lock. You may not have more than one key though!";
			} else if (cmd == "gen box") {
				l.GetComponent<level1Controller>().dropBox();
			}
		} else {
			content = cmd;
		}
	}

	string RandomGossip() {
		return "Unimplemented: random gossip";
	}
}
