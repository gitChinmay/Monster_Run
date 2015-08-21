using UnityEngine;
using System.Collections;

public class looperScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag != "obstacle") {
			Vector3 Pos = col.transform.position;
			float width = col.bounds.size.x;
			Pos.x = Pos.x + (width * 3.0f) - 0.06f;
			col.transform.position = Pos;
		}
		if (col.tag == "obstacle") {
			Destroy(col.gameObject);
		}
	}
}
