using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject item;
	public Vector2 velocity;
	public float coolDownSeconds;
	private float lastTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (lastTime + coolDownSeconds < Time.time) {
			lastTime = Time.time;
			var newItem = Instantiate(item) as GameObject;
			newItem.rigidbody2D.velocity = velocity;
		}
	}
}
