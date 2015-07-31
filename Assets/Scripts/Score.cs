using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	private float score;
	public static float highestScore;
	private Text scoreUI;
	public Text cong;
	public Text highscore;
	public static bool highest;

	// Use this for initialization
	void Start () {
		score=0.0f;
		highest = false;
		scoreUI = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime*10;
		scoreUI.text = ((int)score).ToString();

		if (score >= highestScore) {
			if(highest && highestScore>0){
				cong.gameObject.SetActive(true);
				highest = true;
				//StartCoroutine(WaitAndPrint(3.0f));
			}
			highestScore = score;
		}
		highscore.text="High score: "+((int)highestScore).ToString();
	}

	/*IEnumerator WaitAndPrint(float waitTime){
		print("----> waiting ... ");
		yield return new WaitForSeconds (waitTime);
		cong.gameObject.SetActive (false);
	}*/
}
