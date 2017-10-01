using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject Target;

    private Vector3 m_offset;

	// Use this for initialization
	void Start () {
        m_offset = transform.position - Target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Target.transform.position + m_offset;
	}
}
