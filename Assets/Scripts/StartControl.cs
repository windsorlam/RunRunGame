﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartControl : MonoBehaviour {
	public GameObject player;
	public AudioSource bgm;
	public GameObject score;
	public GameObject label;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			this.gameObject.SetActive(false);
			player.SetActive(true);
			label.SetActive(true);
			score.SetActive(true);
			bgm.Play();
		}
	}
}