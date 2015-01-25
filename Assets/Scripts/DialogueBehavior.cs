using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueBehavior : MonoBehaviour {
	public float rectOffsetX, rectOffsetY;
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
		var dialogue = new DialogueTree ("hello", "I'm", "how", "hmmm", "where", "curse", "what", "believe", "answer/love", "answer/death", "answer/tech", "you");

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
		dialogue.AddOption ("hmmm", "At least some options?", "believe");

		dialogue.SetNodeContent ("where", "You don't know? Well... I shouldn't be the one who tells you.");
		dialogue.AddOption ("where", "Very well. Oh, I can surely smell *regret*, though.", "what");
		dialogue.AddOption ("where", "Damn it. I curse you.", "curse");

		dialogue.SetNodeContent ("curse", "Curse? Hahahahahaha...cursed, of course. Obviously I *am* the mostly cursed one. I *am* the one who lost the motality. They call me... never mind.");
		dialogue.AddOption ("curse", "Waaaait, the one who lost its motality! You can't be...", "what");

		dialogue.SetNodeContent ("what", "Haha, the answer depends on what you *believe*. Whatever.");
		dialogue.AddOption ("what", "What do we do now?", "you");
		dialogue.AddOption ("what", "Believe in *what*, then? At least some options?", "believe");

		dialogue.SetNodeContent ("believe", "So many questions, huh? Let *me* ask you first: What can change the nature of a man?");
		dialogue.AddOption ("believe", "Love.", "answer/love");
		dialogue.AddOption ("believe", "Death.", "answer/death");
		dialogue.AddOption ("believe", "Technology.", "answer/tech");
		dialogue.AddOption ("believe", "I don't like this one. What do we do now?", "you");

		dialogue.SetNodeContent ("answer/love", "Oh really? Currently falling in love with someone? I'm sorry that it makes you more stupid even than I can imagine, too stupid to make you agree with me.");
		dialogue.AddOption ("answer/love", "What?! WTF are...[sigh] maybe you are right. She is a Pointer in Stack, the other side of Memory world. What do we do now?", "you");

		dialogue.SetNodeContent ("answer/death", "Ha! I partially agree with you, but I have to say, some people just *can't* die. This answer, sadly, means nothing to *them*");
		dialogue.AddOption ("answer/death", "You are not speaking about me, are you!? We will see... what do we do now?", "you");
		dialogue.AddOption ("answer/death", "Yes she can. Ephemeral is her destiny.", "answer/love");

		dialogue.SetNodeContent ("answer/tech", "Ohhhhh, I must live for too long to keep up with the mainstream world now. So it's called technology huh? Especially, as I heard of, the \"Computer Science\"? I'm sorry, you may get another correct answer, if it's true that it's this technology that makes you immortal.");
		dialogue.AddOption ("answer/tech", "It's quite different from magic. I like it. I belong to Pointer. I live in BSS Segment in Stack. What do we do now?", "you");

		dialogue.SetNodeContent ("you", "What do *we* do now? No, there's not *we*. There's only you. Now explore this place until you find something and come to me.");

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
		Debug.Log (rectOffsetX);
		Debug.Log (rectOffsetY);
		Debug.Log (Input.mousePosition.x);
		Debug.Log (Input.mousePosition.y);
		GUI.Label(new Rect(rectOffsetX, Screen.height-rectOffsetY, dialogueRect.width, dialogueRect.height), state.ToString(), gui_style);
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
