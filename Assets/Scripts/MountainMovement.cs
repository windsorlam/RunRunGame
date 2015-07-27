using UnityEngine;
using System.Collections;

public class MountainMovement : MonoBehaviour {
	public float speed=2f;
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=(Vector2)transform.position-Time.deltaTime*speed*Vector2.right;
	}
}
