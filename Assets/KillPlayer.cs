using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<PlaneBehaviour>() != null)
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            col.gameObject.GetComponent<PlaneBehaviour>().triggerDeath();
        }
    }
}
