using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject paredeBatida;
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Transform obstacule;


	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;

	private int score;

	void Start(){
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		if (restart) {
			if (Input.GetButtonDown ("Fire1")) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(true){
			for(int i = 0; i < hazardCount; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

				//TRAINING
				if (score > 50) {
					hazardCount = 6;
					spawnWait = 0.9f;
				}
				//LEVEL 1
				if (score >= 140) {
					hazardCount = 8;
					spawnWait = 0.8f;
				}
				//LEVEL 2
				if (score >= 220) {
					hazardCount = 10;
					spawnWait = 0.7f;
				}

				//LEVEL 3
				if (score >= 320) {
					hazardCount = 12;
					spawnWait = 0.5f;
				}
				//LEVEL 4
				if (score >= 500) {
					hazardCount = 15;
					spawnWait = 0.5f;
				}
				//LEVEL 5
				if (score >= 700) {
					hazardCount = 17;
					spawnWait = 0.4f;
				}

				//IMPOSSIBLE LEVEL
				if (score > 1000) {
					hazardCount = 25;
					spawnWait = 0.2f;
				}
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Clique para Recomecar";
				restart = true;
				hazardCount = 0;
			}
		}
	}

	public void AddScore (int newScoreValue){
		 
		score += newScoreValue;
		UpdateScore ();

	}

	void UpdateScore(){
		scoreText.text = "" + score;
		}

	public void GameOver(){
		Destroy (paredeBatida);
		gameOverText.text = " G A M E  O V E R ";
		gameOver = true;
	}

}
