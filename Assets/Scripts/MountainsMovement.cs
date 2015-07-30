using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MountainsMovement : MonoBehaviour {
	public GameObject[] mountains;
	float scrollingSpeed=1f;
	public float minOffset;
	public float maxOffset;
	public float screenWidth;
	public float mountainWidth;
	public Text score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!enabled)
			return;
		foreach (GameObject mountain in mountains) {
			mountain.transform.position=(Vector2)(mountain.transform.position)-Time.deltaTime*Vector2.right * scrollingSpeed;
			float newX=mountain.transform.position.x;
			if(newX<-mountainWidth-screenWidth/2){
				float y=mountain.transform.position.y;
				mountain.transform.position=new Vector2(screenWidth+Random.Range(minOffset,maxOffset),y);
			}
		}
		if (score.IsActive()) {
			scrollingSpeed=2f;
		}
		if (int.Parse (score.text) > 500) {
			scrollingSpeed=3f;
		}
		if(int.Parse(score.text)>1000){
			scrollingSpeed=4f;
		}
		if (int.Parse (score.text) > 2000) {
			scrollingSpeed=5f;
		}
	}
}
