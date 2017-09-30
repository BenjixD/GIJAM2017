using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {

    public float PitchRate;
    public float DeadThreshold;

    private Rigidbody2D m_rigidbody2D;
    private bool m_flip;
    private float m_direction;


    // Use this for initialization
    void Start () {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_flip = false;

        StartCoroutine(ChangeRotation());
	}
	
	// Update is called once per frame
	void Update () {
	}

    void Flip(Vector3 actualTarget)
    {
        if ((actualTarget.z > 90 && actualTarget.z <= 270) && !m_flip)
        {
            m_flip = !m_flip;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if ((actualTarget.z % 360 <= 90 || actualTarget.z % 360 > 270) && m_flip)
        {
            m_flip = !m_flip;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    IEnumerator ChangeRotation()
    {
        for(;;)
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");
            /*
            if(horizontalAxis != Mathf.Abs(Input.GetAxis("Horizontal")))
            {
                m_flip = true;
            }
            else
            {
                m_flip = false;
            }
            */
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

                if (myRotation + 360 % 360 > 90 && myRotation + 360 % 360 < 270 &&!m_flip)
                {
                    //nextRotation = 180 - nextRotation;
                    m_flip = !m_flip;
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                }
                else if ((myRotation + 360 % 360 < 90 || myRotation + 360 % 360 > 270) && m_flip)
                {
                    m_flip = !m_flip;
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                }


            }

            yield return new WaitForFixedUpdate();
        }
    }
}
