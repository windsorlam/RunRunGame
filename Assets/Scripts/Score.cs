using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	private float score;
	public static float highestScore;
	private Text scoreUI;
	//public Text cong;
	bool highest = false;

	// Use this for initialization
	void Start () {
		score=0.0f;
		scoreUI = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime*10;
		scoreUI.text = ((int)score).ToString();

		if (score >= highestScore && !highest) {
			//cong.gameObject.SetActive(true);
			highestScore = score;
			highest = true;
			StartCoroutine(WaitAndPrint(3.0f));
		}
	}

	IEnumerator WaitAndPrint(float waitTime){
		print("----> waiting ... ");
		yield return new WaitForSeconds (waitTime);
		//cong.gameObject.SetActive (false);
	}
}
