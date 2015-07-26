using UnityEngine;
using System.Collections;

public class BuildingsMovement : MonoBehaviour {
	public GameObject[] buildings;
	public float scrollingSpeed;
	public float minDistance;
	public float maxDistance;
	public float screenWidth;
	private int seed=1;


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
		Random.seed = seed;
		foreach (GameObject building in buildings) {
			building.transform.localPosition=(Vector2)(building.transform.localPosition)-Time.deltaTime*Vector2.right * scrollingSpeed;
			BoxCollider2D bc=building.gameObject.GetComponent<BoxCollider2D>();
			float newX=building.transform.localPosition.x+bc.size.x/2;
			if(newX>maxX)
				maxX=newX;
		}//Get the rightest building's x position
		if (maxX < screenWidth / 2) {
			bool moved=false;
			while(!moved){
				int i=Random.Range(0,buildings.Length);
				GameObject building=buildings[i];
				BoxCollider2D bc=building.gameObject.GetComponent<BoxCollider2D>();
				if(building.transform.localPosition.x<-screenWidth/2-bc.size.x/2){
					float y=building.transform.localPosition.y;
					building.transform.localPosition=new Vector3(maxX+Random.Range(minDistance,maxDistance),y,0f);
					moved=true;
				}
			}
		}
	}
}
