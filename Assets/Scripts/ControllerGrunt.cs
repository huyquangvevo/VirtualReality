using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrunt : MonoBehaviour {

	// Use this for initialization
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveGrunt ();
		getAttack01 ();
		getAttack02 ();	
	}

	void FixedUpdate(){
		if (!anim.GetBool ("isAttack01")) {
			float moveAmount = Time.smoothDeltaTime * 5;
			transform.Translate (0f, 0f, moveAmount);
		}
	}

	void moveGrunt(){
		float i = Input.GetAxis ("Horizontal");
		if (i > 0f) {
			this.transform.position = new Vector3 (-i, 0, transform.position.z);
		} else if (i < 0f) {
			this.transform.position =  new Vector3 (-i, 0, transform.position.z);
		}
	}


	void getAttack01(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("isAttack01", true);
			Debug.Log ("Press Space");
		};

		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetBool ("isAttack01", false);
		}
	}

	void getAttack02(){
		if (Input.GetKeyDown (KeyCode.Z)) {
			anim.SetBool ("isAttack02", true);
			Debug.Log ("Press Shift");

		};

		if (Input.GetKeyUp (KeyCode.Z)) {
			anim.SetBool ("isAttack02", false);
		}

	}

}
