using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnInTime : MonoBehaviour
{
    public float Life;

	// Use this for initialization
	void Start () {
        StartCoroutine(LifeTimer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(Life);
        Destroy(gameObject);
    }
}
