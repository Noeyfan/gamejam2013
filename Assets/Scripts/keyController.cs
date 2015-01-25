using UnityEngine;
using System.Collections;

public class keyController : MonoBehaviour {
	private OutputPrompt output;
	// Use this for initialization
	void Start () {
		output = GameObject.Find ("OutputPrompt").GetComponent<OutputPrompt> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		//print ("enter");
		if(c.tag == "Player") {
			c.GetComponent<GameController> ().GetKey (gameObject.name);
			c.GetComponent<GameController> ().PlayGetKey();
			string color = "";
			if (name == "key3(Clone)") {
				color = "blue";
			} else if (name == "key1(Clone)") {
				color = "green";
			} else if (name == "key2(Clone)") {
				color = "red";
			} else if (name == "key4(Clone)") {
				color = "yellow";
			}
			output.SendEvent("you got " + color + " key.");
			//gameObject.GetComponent<AudioSource>().Play();
			Destroy (gameObject);
		}
	}
}
