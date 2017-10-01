using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRain : MonoBehaviour {

    public float Chance;
    public float spawnYOffset;

    public GameObject Rain;

    private Vector3 spawnOrigin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnOrigin = transform.position + new Vector3(0, spawnYOffset, 0);
        float ran = Random.Range(0f, 100f);

        if(ran <= Chance)
        {
            float xOffset = Random.Range(-19.2f, 19.2f);
            float yOffset = Random.Range(-0.5f, 0.5f);

            Vector3 spawnPoint = new Vector3(xOffset, yOffset, 0) + spawnOrigin;

            GameObject obj = (GameObject)Instantiate(Rain, spawnPoint, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector3(0, Random.Range(-8f, -4f), 0);
        }
	}
}
