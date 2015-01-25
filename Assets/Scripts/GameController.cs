using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject cursor;
	private GameObject player;
	private float movex = 0f;
	private float movey = 0f;
	private Texture2D cur;
	private int key;
	private float calory;

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
		gameObject.transform.localScale = new Vector3(.5f,.5f,.5f);
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
		LoseWeight ();
		if(calory > 3000) {
			gameObject.transform.localScale = new Vector3(.3f,.3f,.3f);
		}
		print (GetCurrentCal());
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag == "Bullet") {
			print("push player");
			rigidbody2D.AddForce(-gameObject.transform.right * 2000);
		}
	}

	void LoseWeight() {
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
			calory += 1;
		}
	}

	float GetCurrentCal() {
		return calory;
	}
}
