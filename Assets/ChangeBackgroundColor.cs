using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour {

    public GlobalCount Counter;

    SpriteRenderer anim;
    Color myColor;

    public Color TargetColor;

	// Use this for initialization
	void Start () {
        anim = GetComponent<SpriteRenderer>();
        myColor = anim.color;
	}
	
	// Update is called once per frame
	void Update () {
		anim.color = Color.Lerp(myColor, TargetColor, ((float)(Counter.totalBullets))/100);
    }
}
