using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveClouds : MonoBehaviour {

	public float xSpeed;
	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().velocity = new Vector3 (-xSpeed, 0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
