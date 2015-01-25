using UnityEngine;
using System.Collections;

public class keyController : MonoBehaviour {
	// Use this for initialization
	void Start () {
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
		}
	}
}
