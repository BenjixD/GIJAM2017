using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour {

	public string direction; 
	public GameObject Clouds;
	public GameObject leftBoundary;
	public GameObject rightBoundary;

	// Use this for initialization
	void Start () {
		direction = "left";
	}
	
	// Update is called once per frame
	void Update () {

		if (direction == "left") {
			foreach (Transform child in Clouds.transform) {
				child.GetComponentsInChildren<moveClouds> ()[0].direction = -1f;
			}
			leftBoundary.GetComponent<BoxCollider2D>().enabled  = true;
			rightBoundary.GetComponent<BoxCollider2D>().enabled  = false;
		
		} else if (direction == "right") {
			foreach (Transform child in Clouds.transform) {
				child.GetComponentsInChildren<moveClouds> ()[0].direction = 1f;
			}

			leftBoundary.GetComponent<BoxCollider2D>().enabled = false;
			rightBoundary.GetComponent<BoxCollider2D>().enabled = true;
		}
		
	}
}
