using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineerController : MonoBehaviour {

	// Use this for initialization
	Actions actions;
	public float speed = 4f;
	int score;
	public Text textScore;
	Rigidbody body;
	Animator anim;

	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;


	void Start () {
		score = 0;
		actions = GetComponent<Actions> ();
		body = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	//	actions.Run ();
	
		// Character controller

		controller = GetComponent<CharacterController> ();
		gameObject.transform.position = new Vector3 (0, 5, 0);

		//body.velocity = transform.forward*100f;
	}
	
	// Update is called once per frame
	void Update () {
		//moveEngineer ();
		if(controller.isGrounded){
			//actions.Run ();
			//anim.ResetTrigger("Jump");
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, 1f);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection = moveDirection * speed;
			if (Input.GetButton ("Jump")) {
				//actions.Jump ();
				anim.SetTrigger ("Jump");
				moveDirection.y = jumpSpeed;
			}
			//jumpE();		
		}

		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
		controller.Move (moveDirection * Time.deltaTime);
	}

	void FixedUpdate(){
		//translateEngineer ();
	}

	void translateEngineer(){
		float moveAmount = Time.smoothDeltaTime * speed;
		transform.Translate ( 0f, 0f, moveAmount );	
		//transform.Translate(-transform.forward*Time.deltaTime);
	}

	void moveEngineer(){
		float i = Input.GetAxis ("Horizontal");
		if (i != 0f) {
			this.transform.position = new Vector3 (-i, 0, transform.position.z);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Diamondo5side") {
			score++;
			textScore.text = score.ToString();
			Destroy (col.gameObject);
		}
	}

	void OnCollisionEnter(Collision coli){
		Debug.Log (coli.collider.name);
		if (coli.collider.tag == "Diamondo5side") {
			score++;
			textScore.text = score.ToString();
			Destroy (coli.gameObject);
		}
	}

/*	void jumpE(){
		if (Input.GetButton ("Jump")) {
			//actions.Jump ();
			anim.SetTrigger ("Jump");
			moveDirection.y = jumpSpeed;
		};

		if (Input.GetButtonUp ("Jump")) {
			anim.SetBool ("Run", true);
		}
	}
*/
}
