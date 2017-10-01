using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMapRight : MonoBehaviour {

	public GameObject rightBoundary;
	public GameObject Clouds;
	public float spawnOffset = 18.6f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		//Debug.Log ("hit");
		GameObject map = (GameObject)Instantiate(c.gameObject,rightBoundary.transform.position + new Vector3(spawnOffset,0,c.transform.position.z), rightBoundary.transform.rotation);
		map.transform.parent = Clouds.transform;
        SpriteRenderer sr = map.GetComponent<SpriteRenderer>();
        if (sr)
        {
            sr.sortingOrder = c.GetComponent<SpriteRenderer>().sortingOrder;
        }
	}

	void OnTriggerExit2D(Collider2D c){
		//Debug.Log ("left");
		Destroy (c.gameObject);
	}
}
