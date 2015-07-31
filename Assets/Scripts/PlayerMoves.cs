using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class PlayerMoves : MonoBehaviour {
	public Rigidbody2D rb;
	public float spring;
	private byte jumpState=0;
	public float bottomY;
	public GameObject over;
	public GameObject scoreLabel, ScoreUI;
	public GameObject highscore;
	public AudioSource backgroundMusic;

	//variables for flip
	int flip = 0;
	int score = 0;
	bool spaceKeyDown = false;
	bool collideBridge = false;
	private Vector3 flipPos;
	private Quaternion qua_upright, qua_reverse;
	Vector2 gra_upright, gra_reverse;
	
	//jump MA
	//public float moveSpeed;
	//public float jumpHight;

	public float jumpHeight;
	private float jumpY;

	// Use this for initialization
	void Start () {
		qua_upright = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		qua_reverse = new Quaternion (180.0f, 0.0f, 0.0f, 0.0f);
		gra_upright = new Vector2 (0.0f, -9.8f);
		gra_reverse = new Vector2 (0.0f, 9.8f);
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 position = (Vector2)transform.position;
		//transform.position = position + Time.deltaTime*Vector2.right * speed;
		if(Input.GetKeyDown(KeyCode.UpArrow)&&jumpState<2){
			rb.velocity=new Vector2(rb.velocity.x,0);
			rb.AddForce(new Vector2(0,spring+rb.mass*System.Math.Abs(Physics.gravity.y)));
			jumpState++;
			jumpY=transform.position.y;
			//Debug.Log("state"+jumpState.ToString()+" y"+jumpY.ToString());
		}
		score ++;
		//set UI Score??
		FlipAction ();
		if (transform.position.y <= bottomY) {
			Die();
		}
	}

	void FixedUpdate(){
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.position = new Vector2 (
			rigidBody.position.x,
			Mathf.Clamp(rigidBody.position.y, float.NegativeInfinity, jumpY+jumpHeight)
		);
	}

	void FlipAction(){
		flipPos = rb.gameObject.transform.position;
		//if (collideBridge) {
		if (Input.GetKeyDown (KeyCode.Space) && collideBridge) {
			//if player hold the space key, always reverse the gameobject
			rb.gameObject.transform.localRotation = qua_reverse;
			Physics2D.gravity = gra_reverse;
			spaceKeyDown = true;
			
			//Debug.LogWarning("Button down");
			if (flip == 0) {
				//this function is called in update
				flipPos -= new Vector3 (0.0f, 2.8f, 0.0f);
				rb.gameObject.transform.position = flipPos;
				flip++;
			}
		} 
 			
		if (Input.GetKeyUp (KeyCode.Space) && spaceKeyDown) {
			//Debug.LogWarning("Button up");
			rb.gameObject.transform.localRotation = qua_upright;
			Physics2D.gravity = gra_upright;

			flip = 0;
			flipPos += new Vector3 (0.0f, 2.8f, 0.0f);
			rb.gameObject.transform.position = flipPos;
			spaceKeyDown = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("Building") || 
		    other.gameObject.tag.EndsWith ("Bridge") && other.relativeVelocity.y<0||
		    other.gameObject.tag.Equals ("obstacle")) {
			jumpState=0;
			ContactPoint2D[] contacts=other.contacts;
			if(contacts[0].normal.y==0){
				Die ();
			}
		}
		if (other.gameObject.tag.EndsWith ("Bridge")) {
			collideBridge = true;
		} 
	}


	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag.EndsWith ("Bridge")) {
			collideBridge = false;
		}
	}

	void Die(){
		over.SetActive (true);
		this.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		ScoreUI.gameObject.SetActive (false);
		highscore.SetActive (false);
 		backgroundMusic.Stop();
	}
}
