using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject[] PlayerRefs;

    public float XFactor;
    public float YFactor;

    public float MinSize;
    public float MaxSize;

    public float SmoothSpeed;

    private Vector3 m_averageLocation;
    private Camera m_camera;

    // Use this for initialization
    void Start () {
        m_camera = GetComponent<Camera>();
        StartCoroutine(CalculateLocation());
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateCameraSize();

	}

    IEnumerator CalculateLocation()
    {
        for(;;)
        {
            Vector3 total = Vector3.zero;
            foreach(GameObject player in PlayerRefs)
            {
                if(player != null)
                {
                    total += player.transform.position;
                }
            }

            m_averageLocation = total / PlayerRefs.Length;

            //Set the Position
            transform.position = new Vector3(m_averageLocation.x, m_averageLocation.y, -10);

            yield return new WaitForFixedUpdate();
        }
    }

    void UpdateCameraSize()
    {
        Vector3 firstRef = PlayerRefs[0] == null ? Vector3.zero : PlayerRefs[0].transform.position;
        Vector3 secondRef = PlayerRefs[1] == null ? Vector3.zero : PlayerRefs[1].transform.position;
        Vector3 dist = firstRef - secondRef;

        float xScale = Mathf.Abs(dist.x / XFactor);
        float yScale = Mathf.Abs(dist.y / YFactor);

        float scale = Mathf.Clamp(Mathf.Max(xScale, yScale), MinSize, MaxSize);

        //m_camera.orthographicSize = Mathf.MoveTowards(m_camera.orthographicSize, scale, SmoothSpeed * Time.deltaTime);
        m_camera.orthographicSize = scale;
    }
}
