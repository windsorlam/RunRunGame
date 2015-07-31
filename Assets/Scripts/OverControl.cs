using UnityEngine;
using System.Collections;

public class OverControl : MonoBehaviour {
	private float overTime;

	// Use this for initialization
	void Start () {
		overTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - overTime > 5||Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel("Main");
			Score.highest = false;
		}
	}
}
