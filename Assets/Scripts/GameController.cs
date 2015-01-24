using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject cursor;
	private GameObject player;
	private float movex = 0f;
	private float movey = 0f;

	public float Speed = 0f;
	public bool walk;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		walk = false;
		cursor = GameObject.Find ("Cursor");
		player = gameObject;
	}

	void FixedUpdate () {
		if(walk) {
			movex = Input.GetAxis ("Horizontal");
			movey = Input.GetAxis ("Vertical");
			player.rigidbody2D.velocity = new Vector2 (movex * Speed, movey * Speed);
		}
	}

	void EnableWalk() {
		walk = true;
	}

	void DisableWalk() {
		walk = false;
	}
	// Update is called once per frame
	void Update () {
		cursor.transform.position = (Input.mousePosition - new Vector3(Screen.width/2f, Screen.height/2f, 0)) / 100;
	}
}
