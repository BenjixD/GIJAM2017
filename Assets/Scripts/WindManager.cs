using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour {

	private int totalBullets;
	public string direction; 
	public GameObject Clouds;
	public GameObject leftBoundary;
	public GameObject rightBoundary;
	public GameObject GlobalCounter;
	private float r = 0.5f;
	private float g = 0.5f;
	private float b = 0.5f;
	private float a = 1f;

	// Use this for initialization
	void Start () {
		direction = "left";
		totalBullets = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalCounter.GetComponent<GlobalCount> ().totalBullets == 49) {
			GlobalCounter.GetComponent<GlobalCount> ().totalBullets += 1;
		}
		if(GlobalCounter.GetComponent<GlobalCount>().totalBullets >= 50){
			//darken
			foreach (Transform child in Clouds.transform) {
				SpriteRenderer spriteColour = child.GetComponent<SpriteRenderer> ();
				if (r > 0 && g > 0 && b > 0) {
					r = r - 0.01f;
					g = g - 0.01f;
					b = b - 0.01f;
				}
				spriteColour.color = new Color (r, g, b , a);
			}
			//reset
			//GlobalCounter.GetComponent<GlobalCount>().totalBullets = 0;
		}

		if (direction == "left") {
			foreach (Transform child in Clouds.transform) {
				if (child.GetComponentsInChildren<moveClouds> ().Length > 0) {
					child.GetComponentsInChildren<moveClouds> ()[0].direction = -1f;
				}
			}
			leftBoundary.GetComponent<BoxCollider2D>().enabled  = true;
			rightBoundary.GetComponent<BoxCollider2D>().enabled  = false;
		
		} else if (direction == "right") {
			foreach (Transform child in Clouds.transform) {
				if (child.GetComponentsInChildren<moveClouds> ().Length > 0) {
					child.GetComponentsInChildren<moveClouds> () [0].direction = 1f;
				}
			}

			leftBoundary.GetComponent<BoxCollider2D>().enabled = false;
			rightBoundary.GetComponent<BoxCollider2D>().enabled = true;
		}
		
	}
}
