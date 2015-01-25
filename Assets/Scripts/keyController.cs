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
			//gameObject.GetComponent<AudioSource>().Play();
			Destroy (gameObject);
			output.SendEvent("You hold " + gameObject.name + " now!");
		}
	}
}
