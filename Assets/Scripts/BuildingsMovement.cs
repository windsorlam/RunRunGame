using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingsMovement : MonoBehaviour {
	public GameObject[] buildings;
	float scrollingSpeed=3f;
	public float minDistance;
	public float maxDistance;
	public float screenWidth;
	public Text score;

	void Start () {
		/*float offset=-screenWidth/2;
		Random.seed = seed;
		foreach (GameObject building in buildings) {
			BoxCollider2D bc=building.GetComponent<BoxCollider2D>();
			building.transform.localPosition=new Vector2(offset,bc.size.y/2);
			offset+=bc.size.x+Random.Range(minDistance,maxDistance);
		}*/
		//Initialize position of the buildings
	}

	void Update () {
		if (!enabled)
			return;
		float maxX = float.NegativeInfinity;
		foreach (GameObject building in buildings) {
			building.transform.position=(Vector2)(building.transform.position)-Time.deltaTime*Vector2.right * scrollingSpeed;
			BoxCollider2D bc=building.gameObject.GetComponent<BoxCollider2D>();
			float newX=building.transform.position.x + bc.size.x/2;
			if(newX>maxX)
				maxX=newX;
		}//Get the rightest building's x position
		if (maxX < screenWidth / 2) {
			bool moved=false;
			while(!moved){
				int i=Random.Range(0,buildings.Length);
				GameObject building=buildings[i];
				BoxCollider2D bc=building.gameObject.GetComponent<BoxCollider2D>();
				if(building.transform.position.x<-screenWidth/2-bc.size.x/2){
					float y=building.transform.position.y;
					building.transform.position=new Vector3(maxX+Random.Range(minDistance,maxDistance)+bc.size.x/4,y,0f);
					moved=true;
				}
			}
		}
		if (score.IsActive()) {
			scrollingSpeed=6f;
		}
		if (int.Parse (score.text) > 500) {
			scrollingSpeed=9f;
		}
		if(int.Parse(score.text)>1000){
			scrollingSpeed=12f;
		}
		if (int.Parse (score.text) > 2000) {
			scrollingSpeed=15f;
		}
	}
}
