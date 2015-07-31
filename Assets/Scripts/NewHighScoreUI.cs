using UnityEngine;
using System.Collections;

public class NewHighScoreUI : MonoBehaviour {
	public float x;
	public float y;
	public float screenWidth;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (x, y);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= Vector3.right * Time.deltaTime*500;
		if (transform.position.x < -screenWidth) {
			this.gameObject.SetActive (false);
		}
	}
}
