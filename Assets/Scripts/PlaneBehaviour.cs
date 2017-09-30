using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour {

    Rigidbody2D rb;

    public Player.Control currentPlayer;

    // gravity is the speed additive before being modified by direction
    public float baseSpeed, pitchRate, gravity;
    float direction;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.rotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
        direction = (direction +pitchRate * Input.GetAxisRaw("Vertical" + (int)currentPlayer)) % 360;
        transform.eulerAngles = new Vector3(0,0,direction);
        float multiplier = Mathf.Sin(Mathf.Deg2Rad * direction);
        float actualSpeed = baseSpeed - gravity * (multiplier / (multiplier > 0? 2 : 1));
        rb.velocity = new Vector2(actualSpeed * Mathf.Cos(Mathf.Deg2Rad*direction), actualSpeed * Mathf.Sin(Mathf.Deg2Rad * direction));
        //TODO lerp speed instead?
	}

    public void triggerDeath()
    {
        //Do dying things here
        Destroy(transform.parent.gameObject, 10);
    }
}
