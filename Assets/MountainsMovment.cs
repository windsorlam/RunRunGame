using UnityEngine;
using System.Collections;

public class MountainsMovment : MonoBehaviour {
	public GameObject[] mountains;
	public float scrollingSpeed;
	public float minDistance;
	public float maxDistance;
	public float screenWidth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!enabled)
			return;
		float maxX = float.NegativeInfinity;
		foreach (GameObject mountain in mountains) {
			mountain.transform.localPosition=(Vector2)(mountain.transform.localPosition)-Time.deltaTime*Vector2.right * scrollingSpeed;
			//BoxCollider2D bc=mountain.gameObject.GetComponent<BoxCollider2D>();
			float newX=mountain.transform.localPosition.x;
			if(newX>maxX)
				maxX=newX;
		}//Get the rightest building's x position
		if (maxX < screenWidth / 2) {
			bool moved=false;
			while(!moved){
				int i=Random.Range(0,mountains.Length);
				Debug.Log (mountains.Length);
				GameObject mountain=mountains[i];
				//PolygonCollider2D pc=mountain.gameObject.GetComponent<PolygonCollider2D>();
				if(mountain.transform.localPosition.x<-screenWidth/2){
					float y=mountain.transform.localPosition.y;
					mountain.transform.localPosition=new Vector3(maxX+Random.Range(minDistance,maxDistance),y,0f);
					moved=true;
				}
			}
		}
	}
}
