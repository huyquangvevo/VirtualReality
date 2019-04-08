using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianController : MonoBehaviour {

	// Use this for initialization

	public float mSpeed = 5f;

	public Animator anim;
	public Rigidbody body;

	void Start () {
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody> ();
		anim.SetBool ("Run", true);
		anim.SetFloat ("Speed", 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		moveBar ();
		attack01 ();
		jump ();
	}

	void FixedUpdate (){
		//if(anim.GetBool("Run")||anim.GetBool("Jump"))
			translateBar (mSpeed);
		//if (anim.GetBool ("Jump"))
		//	translateBar (50f);
	}

	void translateBar(float speed){
		float moveAmount = Time.smoothDeltaTime * speed;
		transform.Translate ( 0f, 0f, moveAmount );	
	}

	void moveBar(){
		float i = Input.GetAxis ("Horizontal");
		if (i != 0f) {
			this.transform.position = new Vector3 (-i, 0, transform.position.z);
		}
	}

	void attack01(){
		if (Input.GetKeyDown (KeyCode.A)) {
			anim.SetBool ("Run", false);
			anim.SetTrigger ("Attack 01");
		};
		if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetBool ("Run", true);
			anim.ResetTrigger("Attack 01");
		}
	}

	void jump(){
		if (Input.GetKeyDown (KeyCode.F)) {
			anim.SetBool ("Run", false);
			//anim.SetTrigger ("Jump");
			anim.SetBool ("Jump", true);
		};
		if (Input.GetKeyUp (KeyCode.F)) {
			anim.SetBool("Jump",false);
			anim.SetBool ("Run", true);
			//anim.ResetTrigger("Jump");
		}
	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col.name);
	}

	void OnCollisionEnter(Collision colObj){
		Debug.Log ("Va cham");
		if (colObj.gameObject.tag == "Diamondo5side") {
			Debug.Log ("Kim Cuong");
			anim.SetBool ("Run", false);
			body.AddForce (-transform.forward*10000,ForceMode.Acceleration);
			//translateBar(-5f);
		}
	}

	void OnCollisionExit(Collision colObj){
	}
}
