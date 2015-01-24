using UnityEngine;
using System.Collections;

public class OutputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	public Font font;
	private string content = "";

	void OnGUI() {
		GUI.Label(new Rect(screenPositionX, screenPositionY, Screen.width, 40), content);
		GUI.skin.font = font;
	}

	public void SendEvent(DialogueBehavior dia, string cmd) {
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
		} else {
			content = "Choose C) for any exam question. ;)";
		}
	}

	string RandomGossip() {
		return "Unimplemented: random gossip";
	}
}
