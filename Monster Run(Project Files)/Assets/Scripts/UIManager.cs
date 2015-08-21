using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	cameraMove refScript;

	public Text scoreText;
	// Use this for initialization
	void Start () {
		refScript = Camera.main.GetComponent<cameraMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!cameraMove.isGameOver)
			scoreText.text = refScript.updateScore ().ToString ("F0");
	}

	public void restart(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void homeNav(){
		Application.LoadLevel("scene00");
	}
}
