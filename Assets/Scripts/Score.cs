using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	private float score=0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime*10;
		Text text = GetComponent<Text> ();
		text.text = ((int)score).ToString();
	}
}
