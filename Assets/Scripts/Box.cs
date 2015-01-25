using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var x = GameObject.Find ("adam").GetComponent<DialogueBehavior> ();
		var t = Camera.main.WorldToScreenPoint(transform.position);
		x.rectOffsetX = t.x;
		x.rectOffsetY = t.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
