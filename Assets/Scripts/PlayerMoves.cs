using UnityEngine;
using System.Collections;

public class PlayerMoves : MonoBehaviour {
	public Rigidbody2D rb;
	public float speed;
	public float spring;
	public string foreground;
	private bool ground=true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 position = (Vector2)transform.position;
		//transform.position = position + Time.deltaTime*Vector2.right * speed;
		if(Input.GetKeyDown(KeyCode.Space)&&ground){
			rb.AddForce(new Vector2(0,spring));
			ground=false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name.Equals (foreground)&&other.relativeVelocity.y<0) {
			ground=true;
		}
	}
}
