using UnityEngine;
using System.Collections;

public class PlayerMoves : MonoBehaviour {
	public Rigidbody2D rb;
	public float speed;
	public float spring;
	//public string foreground;
	private byte jumpState=0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 position = (Vector2)transform.position;
		//transform.position = position + Time.deltaTime*Vector2.right * speed;
		if(Input.GetKeyDown(KeyCode.Space)&&jumpState<2){
			rb.AddForce(new Vector2(0,spring));
			jumpState++;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("Foreground")&&other.relativeVelocity.y<0) {
			jumpState=0;
		}
	}
}
