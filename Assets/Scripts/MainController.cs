using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	// Use this for initialization
	public GameObject[] listObj;
	public GameObject player;
	public Transform parent;

	void Start () {
		//createDiamond ();
		StartCoroutine(WaitForDiamond());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//createDiamond ();
		//createMap();
	}



	void createDiamond(){
		float disDia = 100f;
		if (Random.Range (-1, 1) >= 0) {
			Debug.Log (player.transform.position);
			Instantiate (listObj[0], new Vector3 (0, 1, player.transform.position.z - disDia), Quaternion.Euler (new Vector3 (-90, 0, 0)), parent);
			Instantiate (listObj[0], new Vector3 (0, 1, player.transform.position.z - disDia - 2), Quaternion.Euler (new Vector3 (-90, 0, 0)), parent);
			Instantiate (listObj[0], new Vector3 (0, 1, player.transform.position.z - disDia - 4), Quaternion.Euler (new Vector3 (-90, 0, 0)), parent);
		}
	}

	IEnumerator WaitForDiamond(){
		while(true){
			Debug.Log ("Waited");
			yield return new WaitForSeconds (1f);
			createDiamond ();
		}
	}
		
}
