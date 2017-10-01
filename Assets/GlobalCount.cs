using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCount : MonoBehaviour {
	
	public int totalBullets;
    public int threshold1;
    public int threshold2;

    public GameObject Clouds;
    public Lightning Lt;


	// Use this for initialization
	void Start () {
		totalBullets = 0;
        StartCoroutine(CheckThreshold1());
        StartCoroutine(CheckThreshold2());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator CheckThreshold1()
    {
        for(;;)
        {
            if(totalBullets > threshold1)
            {
                //do something
                foreach(spawnRain rain in Clouds.GetComponentsInChildren<spawnRain>())
                {
                    rain.enabled = true;
                }
                yield return null;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator CheckThreshold2()
    {
        for (; ; )
        {
            if (totalBullets > threshold2)
            {
                //do something
                Lt.enabled = true;

                yield return null;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
