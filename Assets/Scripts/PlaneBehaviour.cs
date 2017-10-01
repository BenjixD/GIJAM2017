using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour {

    Rigidbody2D rb;

    public Player.Control currentPlayer;

    bool switchRequested;

    // gravity is the speed additive before being modified by direction
    public float baseSpeed, pitchRate, gravity;
    float direction;

    Animator m_anim;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.rotation.eulerAngles.z;
        switchRequested = false;
        m_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Switch" + (int)currentPlayer) || Input.GetAxisRaw("Switch" + (int)currentPlayer) == 1)
        {
            Switch();
        }
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
        Destroy(transform.root.gameObject, 1);
    }

    public void setSwitchRequested(bool s)
    {
        switchRequested = s;
    }

    void Switch()
    {
        if (!switchRequested)
        {
            return;
        }

        m_anim.SetTrigger("reloading");

        enabled = false;
        switchRequested = false;
        StartCoroutine(SwitchOp(1f));
        
    }

    IEnumerator SwitchOp(float delay)
    {
        foreach (SpriteRenderer render in transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>())
        {
            render.enabled = false;
        }

        GunBehaviour gun = GetComponentInChildren<GunBehaviour>();
        Player.Control gunplayer = gun.CurrentPlayer;
        gun.Switch(delay, currentPlayer);
        currentPlayer = gunplayer;
        yield return new WaitForSeconds(delay);
        enabled = true;

        foreach (SpriteRenderer render in GetComponentsInChildren<SpriteRenderer>())
        {
            render.enabled = true;
        }
    }
}
