using UnityEngine;
using System.Collections;

public class treeMove : MonoBehaviour {
	
	Camera cam;
	cameraMove scriptRef;
	
	float treeSpeedDiff;
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
			treeSpeedDiff = 0.4f * scriptRef.camSpeed;
			transform.Translate (Vector3.right * (scriptRef.camSpeed - treeSpeedDiff) * Time.deltaTime);
		}
	}
}
