using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject[] PlayerRefs;

    private Vector3 m_averageLocation;

    // Use this for initialization
    void Start () {
        StartCoroutine(CalculateLocation());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator CalculateLocation()
    {
        for(;;)
        {
            Vector3 total = Vector3.zero;
            foreach(GameObject player in PlayerRefs)
            {
                total += player.transform.position;
            }

            m_averageLocation = total / PlayerRefs.Length;

            //Set the Position
            transform.position = new Vector3(m_averageLocation.x, m_averageLocation.y, -10);

            yield return new WaitForFixedUpdate();
        }
    }
}
