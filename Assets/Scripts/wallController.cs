using UnityEngine;
using System.Collections;

public class wallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag == "Bullet") {
			Destroy(c.gameObject);
		}
	}
}
