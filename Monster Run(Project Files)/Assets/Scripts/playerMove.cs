using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	Rigidbody2D playerBody;
	Collider2D colliderBody;
	//bool grounded = false;
	float distToGround;
	float jumpForce=70f;

	Animator playerAnim;

	AudioSource jumpSound;



	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
		colliderBody = GetComponent<Collider2D> ();
		distToGround = colliderBody.bounds.extents.y;
		playerAnim = GetComponent<Animator> ();
		jumpSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!cameraMove.isGameOver && Input.GetMouseButton (0) && isGrounded ()) {
			playerBody.AddForce (Vector3.up * jumpForce, ForceMode2D.Impulse);
			jumpSound.Play();
		}
		if (cameraMove.isGameOver || !isGrounded ())
			playerAnim.enabled = false;
		else
			playerAnim.enabled = true;
	}
	

	bool isGrounded(){
		//Debug.DrawRay (transform.position, -Vector2.up, Color.green);
		return Physics2D.Raycast( transform.position, -Vector2.up	, distToGround+0.1f,1<<9);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "obstacle") {
			cameraMove.isGameOver=true;
		}
	}
}
