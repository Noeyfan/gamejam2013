using UnityEngine;
using System.Collections;

public class portalController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate ((Vector3.forward) * Time.deltaTime * 10);
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag == "Player") {
			Application.LoadLevel(2);
		}
	}
}
