using UnityEngine;
using System.Collections;

public class lockController : MonoBehaviour {
	private int locknumb;
	// Use this for initialization
	void Start () {
		locknumb = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c) {
		if(c.gameObject.tag == "Player") {
			if(c.gameObject.GetComponent<GameController>().WichKey() == locknumb) {
				Destroy(gameObject);
			}
			//if(c.gameObject.GetComponent<GameController>()) {
			//}
		}
	}
}
