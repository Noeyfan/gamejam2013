﻿using UnityEngine;
using System.Collections;

public class OutputPrompt : MonoBehaviour {
	public int screenPositionX;
	public int screenPositionY;
	public Font font;
	private string content = "";

	void OnGUI() {
		GUI.Label(new Rect(screenPositionX, screenPositionY, Screen.width, 20), content);
		GUI.skin.font = font;
	}

	public void SetContent(string c) {
		content = c;
	}
}