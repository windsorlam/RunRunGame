using UnityEngine;
using System.Collections;

public class BuildingMovement : MonoBehaviour {
	private float speed=3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = (Vector2)transform.position;
		transform.position = position - Time.deltaTime*Vector2.right * speed;
	}
}
