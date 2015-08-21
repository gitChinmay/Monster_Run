using UnityEngine;
using System.Collections;

public class looperColliderFront : MonoBehaviour {

	GameObject[] obsArray;
	int obsLength;

	cameraMove refScript;

	// Use this for initialization
	void Start () {
		refScript = Camera.main.GetComponent<cameraMove> ();
		obsArray= new GameObject[5];
		obsArray = Resources.LoadAll<GameObject> ("Prefabs") as GameObject[];
		obsLength = obsArray.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "obstacle") {
			Vector3 obstaclePos = col.transform.position;
			float xOffset = Random.Range(1000,2500 + refScript.mileStoneTimeIncrementor*50) * 0.01f;
			float yOffset = Random.Range(-550,-450) * 0.01f;
			obstaclePos.x += xOffset;
			obstaclePos.y = yOffset;
			Instantiate(obsArray[Random.Range(0,obsLength)],obstaclePos,Quaternion.identity);
		}
	}
}
