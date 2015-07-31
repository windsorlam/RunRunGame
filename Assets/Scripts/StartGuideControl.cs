using UnityEngine;
using System.Collections;

public class StartGuideControl : MonoBehaviour {
	public GameObject startGame;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			this.gameObject.SetActive(false);
			startGame.SetActive(true);
		}
	}
}
