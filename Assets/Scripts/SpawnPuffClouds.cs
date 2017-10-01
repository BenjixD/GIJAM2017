using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPuffClouds : MonoBehaviour {

    public GameObject CloudPrefab;
    public GameObject SpawnPoint;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnClouds());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnClouds()
    {
        for(;;)
        {
            GameObject obj = (GameObject)Instantiate(CloudPrefab, SpawnPoint.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            yield return new WaitForSeconds(0.3f);
        }
    }
}
