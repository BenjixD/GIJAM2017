using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {

    public GameObject[] planes, hpsliders;
    bool[] existingPlanes;

	// Use this for initialization
	void Start () {
        existingPlanes = new bool[planes.Length];
        for (int i = 0; i < existingPlanes.Length; i++){
            existingPlanes[i] = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i] != null)
            {
                hpsliders[i].GetComponent<Slider>().normalizedValue = planes[i].GetComponentInChildren<PlaneHealth>().getNormalizedHealth();
            }
            else
            {
                existingPlanes[i] = false;
            }
        }
	}


}
