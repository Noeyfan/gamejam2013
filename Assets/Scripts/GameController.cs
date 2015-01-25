using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject cursor;
	private GameObject player;
	private float movex = 0f;
	private float movey = 0f;
	private Texture2D cur;
	private int key;

	public float Speed = 0f;
	public bool walk;

	// Use this for initialization
	void Start () {
		//walk = false;
		key = -1;
		cursor = GameObject.Find ("Cursor");
		player = gameObject;
		cur = Resources.Load ("mf", typeof(Texture2D)) as Texture2D;
		Cursor.SetCursor (cur, new Vector2 (0, 0), CursorMode.Auto);
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

	public void GetKey(string s) {
		switch(s) {
		case "key1":
			key = 1;
			break;
		case "key2":
			key = 2;
			break;
		case "key3":
			key = 3;
			break;
		case "key4":
			key = 4;
			break;
		case "key5":
			key = 5;
			break;
		}
	}

	public int WichKey() {
		return key;
	}
	// Update is called once per frame
	void Update () {
		//cursor.transform.position = (Input.mousePosition - new Vector3(Screen.width/2f, Screen.height/2f, 0)) / 100;
	}
}
