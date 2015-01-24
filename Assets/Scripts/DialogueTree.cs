using UnityEngine;
using System.Collections.Generic;

public class DialogueTree {
	public class Option {
		public string content;
		public Node nextState;
		
		public Option(string _content, Node _nextState) {
			content = _content;
			nextState = _nextState;
		}

		public override string ToString() {
			return content;
		}
	}
	
	public class Node {
		public string name;
		public string content;
		public List<Option> options = new List<Option>();
		
		public Node(string _name, string _content) {
			name = _name;
			content = _content;
		}
		
		public Node Next(int choice) {
			return options[choice].nextState;
		}

		public override string ToString() {
			string ret = "";
			ret += content + "\n\n";
			for (int i = 0; i < options.Count; i++) {
				ret += (i+1).ToString() + ") " + options[i].ToString() + "\n";
			}
			return ret;
		}
	}
	
	public Node StartNode() {
		return states[startState];
	}
	
	public void SetNodeContent(string name, string content) {
		states[name].content = content;
	}
	
	public void AddOption(string nodeName, string optionContent, string nextState) {
		states [nodeName].options.Add (new Option (optionContent, states [nextState]));
	}

	public DialogueTree(params string[] stateNames) {
		startState = stateNames [0];
		foreach (var name in stateNames) {
			states.Add (name, new Node(name, "<NO_CONTENT>"));
		}
	}

	public void Check() {
		foreach (var entry in states) {
			Node node = entry.Value;
			if (node == null || node.content == "<NO_CONTENT>") {
				throw new UnityException("state not set: " + entry.Key);
			}
		}
	}
	
	private string startState;
	private Dictionary<string, Node> states = new Dictionary<string, Node> ();
}