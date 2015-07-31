using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartControl : MonoBehaviour {
	public GameObject player;
	public AudioSource bgm;
	public GameObject score;
	public GameObject label;
	public GameObject RecordLabel;
	public Text HighestScore;
	// Use this for initialization
	void Start () {
		HighestScore.text = ((int)Score.highestScore).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			this.gameObject.SetActive(false);
			player.SetActive(true);
			label.SetActive(true);
			score.SetActive(true);
			RecordLabel.SetActive(true);
			HighestScore.gameObject.SetActive(true);
			bgm.Play();
		}
	}
}
