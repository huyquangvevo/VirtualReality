using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxController : MonoBehaviour {

	// Use this for initialization

	Animation ani;

	void Start () {
		ani = GetComponent<Animation> ();
		ani.Play ("jump");
	}
	
	// Update is called once per frame
	void Update () {
		ani.Play ("run");
	}
}
