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
	public GameObject front;
	public GameObject left;
	public GameObject back;
	public GameObject right;

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
		if (Input.GetKey (KeyCode.W)) {
			left.SetActive(false);
			right.SetActive(false);
			back.SetActive(true);
			front.SetActive(false);
		} else if (Input.GetKey (KeyCode.A)) {
			right.SetActive(false);
			left.SetActive(true);
			back.SetActive(false);
			front.SetActive(false);
				} else if (Input.GetKey (KeyCode.S)) {
			right.SetActive(false);
			left.SetActive(false);
			back.SetActive(false);
			front.SetActive(true);
				} else if (Input.GetKey (KeyCode.D)) {
			right.SetActive(true);
			left.SetActive(false);
			back.SetActive(false);
			front.SetActive(false);
		} else {
			right.SetActive(false);
			left.SetActive(false);
			back.SetActive(false);
			front.SetActive(true);
				}
		}

	void EnableWalk() {
		walk = true;
	}

	void DisableWalk() {
		walk = false;
	}

	public void GetKey(string s) {
				switch (s) {
		case "key1(Clone)":
						key = 1;
						break;
		case "key2(Clone)":
						key = 2;
						break;
		case "key3(Clone)":
						key = 3;
						break;
		case "key4(Clone)":
						key = 4;
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
