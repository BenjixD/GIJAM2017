using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

	public GameObject background;
	public GameObject Clouds;
	public float delay;
	public float recoveryDelay;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		flashLightning ();	
	}

	void flashLightning(){
		foreach (Transform child in background.transform) {
			SpriteRenderer sprite = child.GetComponent<SpriteRenderer> ();
			float r = sprite.color.r;
			float g = sprite.color.g;
			float b = sprite.color.b;
			float a = 0.2f;
			sprite.color = new Color (r, g, b, a);
		}

		foreach (Transform child in Clouds.transform) {

			SpriteRenderer sprite = child.GetComponent<SpriteRenderer> ();
			float r = sprite.color.r;
			float g = sprite.color.g;
			float b = sprite.color.b;
			float a = 0.2f;
			sprite.color = new Color (r, g, b, a);
		}

		if (delay > 0) {
			delay -= 0.5f;
		}
			
		if (delay == 0) {
			foreach (Transform child in background.transform) {
				SpriteRenderer sprite = child.GetComponent<SpriteRenderer> ();
				float oldCapacity;
				Opacity o = child.GetComponent<Opacity> ();
				if (o != null){
					Debug.Log ("HI");
					oldCapacity = o.oldOpacity;
				}
				else {
					Debug.Log("bye");
					oldCapacity = child.GetComponent<moveClouds> ().oldOpacity;
				}
				float r = sprite.color.r;
				float g = sprite.color.g;
				float b = sprite.color.b;
				float a = oldCapacity;
				sprite.color = new Color (r, g, b, a);
			}

			foreach (Transform child in Clouds.transform) {

				SpriteRenderer sprite = child.GetComponent<SpriteRenderer> ();
				float oldCapacity;
				Opacity o = child.GetComponent<Opacity> ();
				if (o != null) {
					oldCapacity = o.oldOpacity;
				} else {
					oldCapacity = child.GetComponent<moveClouds>().oldOpacity;
				}
				float r = sprite.color.r;
				float g = sprite.color.g;
				float b = sprite.color.b;
				float a = oldCapacity;
				sprite.color = new Color (r, g, b, a);
			}
		}

	}
}
