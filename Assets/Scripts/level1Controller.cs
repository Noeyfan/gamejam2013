using UnityEngine;
using System.Collections;

public class level1Controller : MonoBehaviour {
	private GameObject[] keys;
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
	
	// Update is called once per frame
	void Update () {
	}
}
