using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{

    private int totalBullets;
    public int Step = 10;
    public string direction;
    public GameObject Clouds;
    public GameObject leftBoundary;
    public GameObject rightBoundary;
    public GameObject GlobalCounter;
    public float r = 1f;
    public float g = 1f;
    public float b = 1f;
    public float a = 1f;

    private int previousAmmoUsed;

    // Use this for initialization
    void Start()
    {
        direction = "left";
        totalBullets = 0;
        StartCoroutine(DarkenSky());
        previousAmmoUsed = GlobalCounter.GetComponent<GlobalCount>().totalBullets;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GlobalCounter.GetComponent<GlobalCount>().totalBullets >= 10)
        //{
        //    //darken
        //    foreach (Transform child in Clouds.transform)
        //    {
        //        SpriteRenderer spriteColour = child.GetComponent<SpriteRenderer>();
        //        if (r > 0 && g > 0 && b > 0)
        //        {
        //            r = r - 0.01f;
        //            g = g - 0.01f;
        //            b = b - 0.01f;
        //        }
        //        spriteColour.color = new Color(r, g, b, a);
        //    }
        //    //reset
        //    GlobalCounter.GetComponent<GlobalCount>().totalBullets = 0;
        //}

        if (direction == "left")
        {
            foreach (Transform child in Clouds.transform)
            {
                if (child.GetComponentsInChildren<moveClouds>().Length > 0)
                {
                    child.GetComponentsInChildren<moveClouds>()[0].direction = -1f;
                }
            }
            leftBoundary.GetComponent<BoxCollider2D>().enabled = true;
            rightBoundary.GetComponent<BoxCollider2D>().enabled = false;

        }
        else if (direction == "right")
        {
            foreach (Transform child in Clouds.transform)
            {
                if (child.GetComponentsInChildren<moveClouds>().Length > 0)
                {
                    child.GetComponentsInChildren<moveClouds>()[0].direction = 1f;
                }
            }

            leftBoundary.GetComponent<BoxCollider2D>().enabled = false;
            rightBoundary.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    IEnumerator DarkenSky()
    {
        for (;;)
        {
            if (GlobalCounter.GetComponent<GlobalCount>().totalBullets == Step)
            {
                r = 0.8f;
                g = 0.8f;
                b = 0.8f;
            }
            else if (GlobalCounter.GetComponent<GlobalCount>().totalBullets == Step * 2)
            {
                r = 0.6f;
                g = 0.6f;
                b = 0.6f;
            }
            else if (GlobalCounter.GetComponent<GlobalCount>().totalBullets == Step * 3)
            {
                r = 0.4f;
                g = 0.4f;
                b = 0.4f;
            }
            else if (GlobalCounter.GetComponent<GlobalCount>().totalBullets == Step * 4)
            {
                r = 0.2f;
                g = 0.2f;
                b = 0.2f;
            }
            else if (GlobalCounter.GetComponent<GlobalCount>().totalBullets == Step * 5)
            {
                r = 0;
                g = 0;
                b = 0;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}

   
