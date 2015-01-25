using UnityEngine;
using System.Collections;

public class level1Controller : MonoBehaviour {
	private GameObject[] keys;
	public GameObject bullets;
	public float bulletinterve;
	public bool shoot;
	private float timerecord;
	// Use this for initialization
	void Start () {
		keys = new GameObject[4];
		for(int i = 1; i <= keys.Length; i++) {
			string keyname = "Keys/key" + i;
			keys[i-1] = Resources.Load(keyname) as GameObject;
		}
		//dropKey ();
	}

	public void dropKey() {
		for(int i = 0; i < keys.Length; i++) {
			Instantiate(keys[i]);
		}
	}

	public void shootBullet() {
		shoot = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(shoot) {
			if(Time.time > timerecord + bulletinterve) {
				Instantiate (bullets);
				timerecord = Time.time;
			}
		}
	}
}
