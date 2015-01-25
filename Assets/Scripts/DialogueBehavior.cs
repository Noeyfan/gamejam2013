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
	private OutputPrompt output;

	static DialogueBehavior() {
		trees.Add("adam1", InitAdam1Dialogue ());
		trees.Add("adam2", InitAdam2Dialogue ());
	}

	static DialogueTree InitAdam1Dialogue() {
		var dialogue = new DialogueTree ("hello", "I'm", "how", "hmmm", "where", "curse", "what", "you");

		dialogue.SetNodeContent ("hello", "Hello, world.");
		dialogue.AddOption ("hello", "Who...who are you?", "I'm");
		dialogue.AddOption ("hello", "Where...where am I?", "where");

		dialogue.SetNodeContent ("I'm", "I'm Adam.");
		dialogue.AddOption ("I'm", "Adam is not your real name. I know it.", "how");
		dialogue.AddOption ("I'm", "Well then, nice to meet you. Am I supposed to know you?", "what");

		dialogue.SetNodeContent ("how", "You are right, it's not my real name. How do you know that?");
		dialogue.AddOption ("how", "I don't know... I can feel it. I just know it.", "hmmm");
		dialogue.AddOption ("how", "I'm just guessing. It doesn't really matter, however.", "what"); 

		dialogue.SetNodeContent ("hmmm", "Hmmm...but you don't know *which* one I am. Whatever.");
		dialogue.AddOption ("hmmm", "What do we do now?", "you");

		dialogue.SetNodeContent ("where", "You don't know? Well... I shouldn't be the one who tells you.");
		dialogue.AddOption ("where", "Very well. Oh, I can surely smell *regret*, though.", "what");
		dialogue.AddOption ("where", "Damn it. I curse you.", "curse");

		dialogue.SetNodeContent ("curse", "Curse? Hahahahahaha...cursed, of course. Obviously I *am* the mostly cursed one.\nI *am* the one who lost the motality. They call me... never mind.");
		dialogue.AddOption ("curse", "Waaaait, The Cursed one! You belong to Leaky Memory!", "what");

		dialogue.SetNodeContent ("what", "Haha, the answer depends on what you *believe*. Whatever.");
		dialogue.AddOption ("what", "What do we do now?", "you");

		dialogue.SetNodeContent ("you", "What do *we* do now? No, there's not *we*. There's only you.\nNow explore this place until you find something and come back.");

		dialogue.Check ();

		return dialogue;
	}

	static DialogueTree InitAdam2Dialogue() {
		var dialogue = new DialogueTree ("back", "me", "game", "game fail", "game succ");

		dialogue.SetNodeContent ("back", "Something on your mind?");
		dialogue.AddOption ("back", "You know about me more than I expected.", "me");
		
		dialogue.SetNodeContent ("me", "Of course I know you. You are Null. You are the one that never dies and\nthus can never be freed. As I did.");
		dialogue.AddOption ("me", "As you did? You never dies? You are...", "game");
		
		dialogue.SetNodeContent ("game", "[He interrupted you] Let's play a game. A princess is as old as\nthe prince will be when the princess is twice as old as the prince was whe\nthe princess's age was half the sum\nof their present age. Which of the following, then, could be true?");
		dialogue.AddOption ("game", "The prince is 20 and the princess is 30.", "game fail");
		dialogue.AddOption ("game", "The prince is 40 and the princess is 30.", "game fail");
		dialogue.AddOption ("game", "The prince is 30 and the princess is 40.", "game succ");
		dialogue.AddOption ("game", "The prince is 30 and the princess is 20.", "game fail");
		dialogue.AddOption ("game", "They are both the same age.", "game fail");
		dialogue.AddOption ("game", "I surely don't know.", "game fail");
		
		dialogue.SetNodeContent ("game fail", "Sigh. Very well, you can't be freed. Time is not your enemy, forever is.");
		
		dialogue.SetNodeContent ("game succ", "Oh finally, you are freed. That is to say, it's a free(NULL). Congratulations!");

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
		output = GameObject.Find ("OutputPrompt").GetComponent<OutputPrompt> ();
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
			output.OnTalkState (this);
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

	public bool InState(string s) {
		return state.name == s;
	}
}
