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
	public GameObject longBridge;
	public float minHeight;
	public float maxHeight;

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
		float lastY = 0f;
		foreach (GameObject building in buildings) {
			if(!building.activeSelf)
				continue;
			building.transform.position = (Vector2)(building.transform.position) - Time.deltaTime * Vector2.right * scrollingSpeed;
			BoxCollider2D bc = building.gameObject.GetComponent<BoxCollider2D> ();
			float newX = building.transform.position.x + bc.size.x * building.transform.localScale.x / 2;
			if (newX > maxX){
				maxX = newX;
				lastY=transform.position.y;
			}
			if (building.tag.Equals ("LongBridge") && newX < -screenWidth / 2) {
				building.SetActive (false);
			}
		}//Get the rightest building's x position
		if (maxX < screenWidth / 2) {
			bool moved = false;
			while (!moved) {
				int i = Random.Range (0, buildings.Length);
				GameObject building = buildings [i];
				BoxCollider2D bc = building.gameObject.GetComponent<BoxCollider2D> ();
				if (building.transform.position.x + bc.size.x * building.transform.localScale.x/ 2 < -screenWidth) {
					building.transform.position = new Vector3 (
						maxX + Random.Range (minDistance, maxDistance) + bc.size.x* building.transform.localScale.x / 2,
						Mathf.Clamp(lastY+Random.Range(-minDistance,minDistance)-bc.size.y*building.transform.localScale.y/2,minHeight,maxHeight), 0f);
					moved = true;
				}
			}
		}
		if (score.IsActive ()) {
			if(int.Parse(score.text)>5000){
				scrollingSpeed=18f;
			}else if (int.Parse (score.text) > 2000) {
				scrollingSpeed=15f;
			}else if(int.Parse(score.text)>1000){
				scrollingSpeed=12f;
			}else if (int.Parse (score.text) > 500) {
				scrollingSpeed=9f;
			}else if (int.Parse (score.text) > 100) {
				scrollingSpeed=7.5f;
			}else
				scrollingSpeed = 6f;
		}




	}
}
