using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {

    public GameObject[] planes, huds;
    bool[] existingPlanes;

	// Use this for initialization
	void Start () {
        existingPlanes = new bool[planes.Length];
        for (int i = 0; i < existingPlanes.Length; i++){
            existingPlanes[i] = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i] != null)
            {
                huds[i].GetComponentInChildren<Slider>().normalizedValue = planes[i].GetComponentInChildren<PlaneHealth>().getNormalizedHealth();
                huds[i].GetComponentInChildren<Text>().text = ("AMMO: " + planes[i].GetComponentInChildren<GunBehaviour>().GetCurrentAmmo()) ;
            }
            else
            {
                existingPlanes[i] = false;
                //check winner
            }
        }
	}

    void checkWinner()
    {
        int win = -1;
        for (int i = 0; i < existingPlanes.Length; i++){
            if (existingPlanes[i] && win < 0)
            {
                win = i;
            }
            else if (win >= 0)
            {
                return;
            }
        }
        Debug.Log("Plane " + win + " win");
    }

    public void faceswap(GameObject plane) 
    {
        int hudindex = 0;
        while (hudindex < planes.Length && planes[hudindex] != plane) ;
        if (hudindex == planes.Length)
        {
            Debug.Log("MatchManager.faceswap: no plane matched");
            return;
        }
        RectTransform face1 = huds[hudindex].transform.Find("face1").GetComponent<RectTransform>();
        RectTransform face2 = huds[hudindex].transform.Find("face2").GetComponent<RectTransform>();
        Vector3 temp = face1.localPosition;
        face1.localPosition = face2.localPosition;
        face2.localPosition = temp;
    }


}
