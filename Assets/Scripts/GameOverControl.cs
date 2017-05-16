using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControl : MonoBehaviour {

	GameController gameController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameController.hazardCount = 0;
		if (Input.GetButtonDown ("Fire1")) {
			Application.LoadLevel ("Main");

		}
	}
}
