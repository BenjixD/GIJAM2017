using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour, IPlayer {

    Rigidbody2D rb;

    public Player.Control currentPlayer;
    public GameObject IndicateSwitch;
    public GameObject SwapNotice;

    bool switchRequested;

    // gravity is the speed additive before being modified by direction
    public float baseSpeed, pitchRate, gravity;
    public bool flip;

    float direction;
    bool isAileron;


    Animator m_anim;
    public AudioSource DeathSound;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.rotation.eulerAngles.z;
        switchRequested = false;
        isAileron = false;
        m_anim = GetComponent<Animator>();


        StartCoroutine(WatchForSwitchRequest());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Flip" + (int)currentPlayer) && !isAileron)
        {
            StartCoroutine(Aileron());
        }
        else if (Input.GetButton("Switch" + (int)currentPlayer) || Input.GetAxisRaw("Switch" + (int)currentPlayer) != 0)
        {
            Switch();
        }
        direction = (direction +pitchRate * (flip? -1:1) * Input.GetAxisRaw("Vertical" + (int)currentPlayer)) % 360;
        transform.eulerAngles = new Vector3(0,0,direction);
        float multiplier = Mathf.Sin(Mathf.Deg2Rad * direction);
        float actualSpeed = baseSpeed - gravity * (multiplier / (multiplier > 0? 2 : 1));
        rb.velocity = new Vector2(actualSpeed * Mathf.Cos(Mathf.Deg2Rad*direction), actualSpeed * Mathf.Sin(Mathf.Deg2Rad * direction));
        //TODO lerp speed instead?
    }

    public Player.Control GetPlayer()
    {
        return currentPlayer;
    }

    public void triggerDeath()
    {
        //Do dying things here
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }


        m_anim.SetTrigger("death");
        DeathSound.Play();
        Destroy(transform.root.gameObject, 1.0f);
    }

    public void setSwitchRequested(bool s)
    {
        switchRequested = s;
        IndicateSwitch.GetComponent<SpriteRenderer>().enabled = s;
    }

    void Switch()
    {
        IndicateSwitch.GetComponent<SpriteRenderer>().enabled = true;
        if (!switchRequested)
        {
            return;
        }
        IndicateSwitch.GetComponent<SpriteRenderer>().enabled = false;
        m_anim.SetTrigger("reloading");

        enabled = false;
        StartCoroutine(SwitchOp(1f));
        
    }

    IEnumerator SwitchOp(float delay)
    {
        StopCoroutine(WatchForSwitchRequest());
        foreach (SpriteRenderer render in transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>())
        {
            render.enabled = false;
        }

        GunBehaviour gun = GetComponentInChildren<GunBehaviour>();
        Player.Control gunplayer = gun.CurrentPlayer;
        gun.Switch(delay, currentPlayer);
        currentPlayer = gunplayer;
        GameObject.Find("Main Camera").GetComponent<MatchManager>().faceswap(gameObject);
        switchRequested = false;

        //Spawn Swap Indicator
        GameObject obj = (GameObject)Instantiate(SwapNotice, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        obj.GetComponent<Follow>().Target = this.gameObject;
        obj.SetActive(true);

        yield return new WaitForSeconds(delay);
        enabled = true;

        //StopCoroutine(WatchForSwitchRequest());
        foreach (SpriteRenderer render in transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>())
        {
            render.enabled = true;
        }
    }

    IEnumerator WatchForSwitchRequest()
    {
        SpriteRenderer indicator = IndicateSwitch.GetComponent<SpriteRenderer>();
        for (;;)
        {
            if(Input.GetButton("Switch" + (int)currentPlayer) || Input.GetAxisRaw("Switch" + (int)currentPlayer) == 1)
            {
                if(!switchRequested && !indicator.enabled)
                {
                    indicator.enabled = true;
                }
                else if(switchRequested && indicator.enabled)
                {
                    indicator.enabled = false;
                }
            }
            else if (switchRequested && !indicator.enabled)
            {
                indicator.enabled = true;
            }
            else if(!switchRequested && indicator.enabled)
            {
                indicator.enabled = false;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Aileron()
    {
        StopCoroutine(WatchForSwitchRequest());
        isAileron = true;
        foreach (SpriteRenderer render in transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>())
        {
            render.enabled = false;
        }

        GunBehaviour gun = GetComponentInChildren<GunBehaviour>();
        gun.StopAllCoroutines();

        m_anim.SetTrigger("aileron");

        yield return new WaitForSeconds(0.5f);
        //Flip
        flip = !flip;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);

        //Finish last half
        yield return new WaitForSeconds(0.5f);

        //StartCoroutine(WatchForSwitchRequest());
        foreach (SpriteRenderer render in transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>())
        {
            render.enabled = true;
        }
        gun.StartAllCoroutines();
        isAileron = false;
        yield return null;
    }
}
