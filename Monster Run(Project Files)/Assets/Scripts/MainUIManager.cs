using UnityEngine;
using System.Collections;

public class MainUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame(){
		Application.LoadLevel("scene01");
	}

	public void quitGame(){
		Application.Quit();
	}
}
