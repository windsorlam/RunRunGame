using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartControl : MonoBehaviour {
	public GameObject player;
	public AudioSource bgm;
	public GameObject text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			player.SetActive(true);
			text.SetActive(true);
			bgm.Play();
			this.gameObject.SetActive(false);
		}
	}
}
