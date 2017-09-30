﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {

    public Player.Control CurrentPlayer;

    public float PitchRate;
    public float DeadThreshold;

    public GameObject BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float FireRate;
    public float BulletSpeed;

    private Rigidbody2D m_rigidbody2D;
    private Animator m_animator;
    private bool m_flip;
    private float m_direction;


    // Use this for initialization
    void Start () {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_flip = false;

        StartCoroutine(ChangeRotation());
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator ChangeRotation()
    {
        for(;;)
        {
            float horizontalAxis = Input.GetAxis("Horizontal" + (int)CurrentPlayer);
            float verticalAxis = Input.GetAxis("Vertical" + (int)CurrentPlayer);

            if(Mathf.Abs(horizontalAxis) > DeadThreshold || Mathf.Abs(verticalAxis) > DeadThreshold)
            {
                float rotateTo = (Mathf.Rad2Deg * Mathf.Atan2(horizontalAxis, -1 * verticalAxis) + 270) % 360;
                float myRotation = transform.eulerAngles.z;

                float difference = (myRotation - rotateTo + 360) % 360;
                //float nextRotation;

                if (difference < PitchRate)
                {
                    //nextRotation = rotateTo;
                    transform.eulerAngles = new Vector3(0, 0, rotateTo);
                }
                else
                {
                    if (difference < 180)
                    {
                        //nextRotation = myRotation - PitchRate;
                        transform.eulerAngles = new Vector3(0, 0, myRotation - PitchRate);
                    }
                    else
                    {
                        //nextRotation = myRotation + PitchRate;
                        transform.eulerAngles = new Vector3(0, 0, myRotation + PitchRate);
                    }
                }

                if (transform.localEulerAngles.z + 360 % 360 > 90 && transform.localEulerAngles.z + 360 % 360 < 270 &&!m_flip)
                {
                    //nextRotation = 180 - nextRotation;
                    m_flip = !m_flip;
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                }
                else if ((transform.localEulerAngles.z + 360 % 360 < 90 || transform.localEulerAngles.z + 360 % 360 > 270) && m_flip)
                {
                    m_flip = !m_flip;
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Fire()
    {
        for(;;)
        {
            if(Input.GetButton("Fire" + (int)CurrentPlayer))
            {
                float fireCooldown = 1 / FireRate;
                GameObject obj = (GameObject)Instantiate(BulletPrefab, BulletSpawnPoint.transform.position, transform.rotation);
                obj.GetComponent<IBullet>().SetTravelProperties(transform.eulerAngles.z, BulletSpeed);

                m_animator.SetTrigger("fire");

                yield return new WaitForSeconds(fireCooldown);
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }

}
