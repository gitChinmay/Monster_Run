using UnityEngine;
using System.Collections;

public class skyMove : MonoBehaviour {

	Camera cam;
	cameraMove scriptRef;
	
	float skySpeedDiff;
	void Awake(){
		cam = Camera.main;
		scriptRef = cam.GetComponent<cameraMove> ();
	}

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		if (!cameraMove.isGameOver) {
			skySpeedDiff = 0.1f * scriptRef.camSpeed;
			transform.Translate (Vector3.right * (scriptRef.camSpeed - skySpeedDiff) * Time.deltaTime);
		}
	}

}
