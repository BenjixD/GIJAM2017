using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opacity : MonoBehaviour {

	public float oldOpacity;
	// Use this for initialization
	void Start () {
		oldOpacity = GetComponent<SpriteRenderer> ().color.a;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
