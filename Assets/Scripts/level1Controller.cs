using UnityEngine;
using System.Collections;

public class level1Controller : MonoBehaviour {
	private GameObject[] keys;
	// Use this for initialization
	void Start () {
		keys = new GameObject[5];
		//dropKey ();
	}

	void dropKey() {
		for(int i = 1; i <= keys.Length; i++) {
			string keyname = "Keys/key" + i;
			print(keyname);
			GameObject key_inst = Resources.Load(keyname) as GameObject;
			Instantiate(key_inst);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
