using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMapLeft : MonoBehaviour {
	
	public GameObject leftBoundary;
	public float spawnOffset = 18.6f;
	public GameObject Clouds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		GameObject map =(GameObject)Instantiate(c.gameObject,leftBoundary.transform.position - new Vector3(spawnOffset,0,0), leftBoundary.transform.rotation);
		map.transform.parent = Clouds.transform;
	}

	void OnTriggerExit2D(Collider2D c){
		Destroy (c.gameObject);
	}
}
