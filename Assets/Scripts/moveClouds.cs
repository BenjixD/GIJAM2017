using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveClouds : MonoBehaviour {

	public float xSpeed;
	public float direction= -1f;

    public GameObject Manager;

    private SpriteRenderer sr;
    private WindManager wm;

    public float oldOpacity;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(direction * xSpeed, 0, 0);
        sr = GetComponent<SpriteRenderer>();
        wm = Manager.GetComponent<WindManager>();
        oldOpacity = GetComponent<SpriteRenderer>().color.a;

        sr.color = new Color(wm.r, wm.g, wm.b);

        StartCoroutine(Darken());
    }
	
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector3 (direction * xSpeed, 0, 0);
	}

    IEnumerator Darken()
    {
        while(true)
        {
            Color lerped = Color.Lerp(sr.color, new Color(wm.r, wm.g, wm.b), Mathf.PingPong(Time.time, 1));
            sr.color = lerped;

            yield return new WaitForFixedUpdate();
        }
    }
}
