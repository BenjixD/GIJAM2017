﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveClouds : MonoBehaviour {

	public float xSpeed;
	public float direction= -1f;
	public float oldOpacity;
	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().velocity = new Vector3 (direction * xSpeed, 0, 0);
		oldOpacity = GetComponent<SpriteRenderer> ().color.a;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector3 (direction * xSpeed, 0, 0);
	}
}
