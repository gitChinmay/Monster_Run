using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour {
	public float camSpeed= 25f;
	float score=0.1f;
	float scoreIncrementor = 0.02f;

	float holdTime=0.0f;
	float mileStoneTime = 20f;
	public int mileStoneTimeIncrementor = 1;

	public static bool isGameOver=false;
	bool gameOverIndicator = false;

	public Animator gameOverAnim;
	public Animator gameOverPopUp;
	public Animator gameOverButtonPop;

	AudioClip[] gameOverSound;

	AudioSource bgAudio;



	Vector3 pos;

	// Use this for initialization
	void Awake(){
		bgAudio = GetComponent<AudioSource> ();
		bgAudio.volume = 0.1f;
	}
	void Start () {
		isGameOver = false;

		gameOverSound = new AudioClip[3];
		gameOverSound = Resources.LoadAll <AudioClip>("gameOverMusic");

		;

	}
	
	// Update is called once per frame
	void Update () {
		holdTime += Time.deltaTime;
		if (holdTime > mileStoneTime) {
			camSpeed +=2f;
			mileStoneTime = mileStoneTime + 20f;
			mileStoneTimeIncrementor++;
			scoreIncrementor += 0.1f;
		}
		if (!isGameOver)
			transform.Translate (Vector3.right * camSpeed * Time.deltaTime);
		else {
			if(!gameOverIndicator){
				gameOver();
				gameOverIndicator=true;
			}
		}
	}

	public float updateScore()
	{
		score += scoreIncrementor;
		return score;
	}

	void gameOver(){
		gameOverAnim.SetBool ("gameOver", true);
		gameOverPopUp.SetBool ("popUp", true);
		gameOverButtonPop.SetBool ("buttonPop", true);

		bgAudio.loop = false;
		bgAudio.volume = 1f;
		bgAudio.clip = gameOverSound [Random.Range (0, 3)];
		bgAudio.Play ();

	}
}
