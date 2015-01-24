using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject cursor;
	private GameObject player;
	private float movex = 0f;
	private float movey = 0f;

	public float Speed = 0f;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		cursor = GameObject.Find ("Cursor");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate () {
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
		player.rigidbody2D.velocity = new Vector2 (movex * Speed, movey * Speed);
	}
	
	// Update is called once per frame
	void Update () {
		cursor.transform.position = (Input.mousePosition - new Vector3(Screen.width/2f, Screen.height/2f, 0)) / 100;
	}
}
