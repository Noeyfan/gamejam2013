using UnityEngine;
using System.Collections;

public class lockController : MonoBehaviour {
	private int locknumb;
	AudioSource As;
	public GameObject mesh;
	// Use this for initialization
	void Start () {
		locknumb = 1;
		As = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c) {
		if(c.gameObject.tag == "Player") {
			print(c.gameObject.GetComponent<GameController>().WichKey());
			if(c.gameObject.GetComponent<GameController>().WichKey() == locknumb) {
				As.clip = Resources.Load ("SoundFx/key_enter.aif")as AudioClip;
				As.Play();
				mesh.SetActive(false);
				//gameObject.SetActive(false);
				//this.gameObject.GetComponent<MeshRenderer>().isVisible = false;
				gameObject.collider2D.enabled = false;
				//Destroy(gameObject);
			}else {
				As.clip = Resources.Load ("SoundFx/key_locked.aif") as AudioClip;
				As.Play();
			}
			//if(c.gameObject.GetComponent<GameController>()) {
			//}
		}
	}
}
