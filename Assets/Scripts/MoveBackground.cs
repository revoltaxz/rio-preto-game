using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	private MeshFilter currentMaterial;
	public float speed;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 offset = new Vector3 (0, Time.time * speed, 0);

		GetComponent<Renderer>().material.mainTextureOffset = offset;

	}
}
