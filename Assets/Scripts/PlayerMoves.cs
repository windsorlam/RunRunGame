using UnityEngine;
using System.Collections;

public class PlayerMoves : MonoBehaviour {
	public Rigidbody2D rb;
	public float speed;
	public float spring;
	//public string foreground;
	private byte jumpState=0;

	public GameObject player;
	public GameObject Score;
	int flip = 0;
	int score = 0;
	bool collideBridge = false;
	private Vector3 flipPos;
	private Quaternion qua_upright, qua_reverse;
	Vector2 gra_upright, gra_reverse;
	// Use this for initialization


	void Start () {
		qua_upright = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		qua_reverse = new Quaternion (180.0f, 0.0f, 0.0f, 0.0f);
		gra_upright = new Vector2 (0.0f, -2.8f);
		gra_reverse = new Vector2 (0.0f, 1.0f);

		//rb.gameObject.transform.position = flipPos;
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 position = (Vector2)transform.position;
		//transform.position = position + Time.deltaTime*Vector2.right * speed;
		if(Input.GetKeyDown(KeyCode.UpArrow)&&jumpState<2){
			rb.AddForce(new Vector2(0,spring));
			jumpState++;
		}

		score ++;
		//set UI Score??

		FlipAction ();
		Debug.Log ("----> Gravity:" + Physics2D.gravity);

	}

	void FlipAction(){
		flipPos = rb.gameObject.transform.position;
		if (Input.GetKey (KeyCode.Space)) {
			//if player hold the space key, always reverse the gameobject
			rb.gameObject.transform.localRotation = qua_reverse;
			Physics2D.gravity = gra_reverse;

			if( !collideBridge ){
				//!!!!!!!!!!!!!!!! fail
				//set failUI
				player.gameObject.SetActive(false);
			}

			if( flip==0 ){
				//this function is called in update
				flipPos -= new Vector3(0.0f, 2.8f, 0.0f);
				rb.gameObject.transform.position = flipPos;
				flip++;
			}

		} else if (Input.GetKeyUp (KeyCode.Space)) {
			rb.gameObject.transform.localRotation = qua_upright;
			Physics2D.gravity = gra_upright;

			flip = 0;
			flipPos += new Vector3(0.0f, 2.8f, 0.0f);
			rb.gameObject.transform.position = flipPos;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("Foreground")&&other.relativeVelocity.y<0) {
			jumpState=0;
		}
		if (other.gameObject.tag.Equals ("Bridge") && other.relativeVelocity.y < 0) {
			collideBridge = true;
			Debug.Log("detecting collision");
		} else {
			collideBridge = false;
		}
	}
}
