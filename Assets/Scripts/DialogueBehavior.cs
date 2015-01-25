using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueBehavior : MonoBehaviour {
	public Rect dialogueRect;
	public GUIStyle gui_style;
	public string dialogueName;

	private static Dictionary<string, DialogueTree> trees = new Dictionary<string, DialogueTree>();
	private DialogueTree.Node state;

	private bool activated = false;

	static DialogueBehavior() {
		trees.Add("adam", InitAdamDialogue ());
	}

	static DialogueTree InitAdamDialogue() {
		var dialogue = new DialogueTree ("hello", "I'm", "how", "hmmm", "where", "curse", "what");

		dialogue.SetNodeContent ("hello", "Hello, world.");
		dialogue.AddOption ("hello", "Who...who are you?", "I'm");
		dialogue.AddOption ("hello", "Where...where am I?", "where");

		dialogue.SetNodeContent ("I'm", "I'm Adam.");
		dialogue.AddOption ("I'm", "Adam is not your real name. I know it.", "how");
		dialogue.AddOption ("I'm", "Well then, nice to meet you.", "what");

		dialogue.SetNodeContent ("how", "You are right, it's not my real name. How do you know that?");
		dialogue.AddOption ("how", "Oh...isn't it too obvious, that you are actually The Nameless One?", "hmmm");
		dialogue.AddOption ("how", "I'm just guessing. It doesn't really matter, however.", "what"); 

		dialogue.SetNodeContent ("hmmm", "Hmmm...but you don't know *which* one I am. Anyway.");
		dialogue.AddOption ("hmmm", "Anyway.", "what");

		dialogue.SetNodeContent ("where", "You don't know? Well... I shouldn't be the one who tells you.");
		dialogue.AddOption ("where", "Very well. Oh, I can surely smell *regret*, though.", "what");
		dialogue.AddOption ("where", "Damn it. I curse you.", "curse");

		dialogue.SetNodeContent ("curse", "Curse? Hahahahhaha...curse, of course. Obviously I *am* the mostly cursed one.\nI *am* the one who lost the motality. They call me The Nameless One.");
		dialogue.AddOption ("curse", "Oh, you are The Nameless One! The one who never dies!", "what");

		dialogue.SetNodeContent ("what", "Whatever. What do we do now?");

		dialogue.Check ();

		return dialogue;
	}

	void OnGUI() {
		if (!activated) {
			return;
		}
		GUI.Label(dialogueRect, state.ToString(), gui_style);
	}

	void Start () {
		Reset();
	}

	void Update() {
		HandleInput ();
	}

	void Reset() {
		state = trees [dialogueName].StartNode ();
	}

	void HandleInput() {
		if (Input.GetKeyUp(KeyCode.R)) {
			Reset();
		}
	}

	public void Talk(string content) {
		if (!activated) {
			return;
		}
		try {
			int choice = System.Convert.ToInt32(content);
			state = state.Next (choice-1);
		} catch {
		}
	}

	public void Activate() {
		activated = true;
		Reset ();
	}

	public void Deactivate() {
		activated = false;
	}
}
