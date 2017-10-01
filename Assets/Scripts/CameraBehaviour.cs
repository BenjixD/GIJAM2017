using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject[] PlayerRefs;

    public float XFactor;
    public float YFactor;

    public float MinSize;
    public float MaxSize;

    public float MinY;
    public float MaxY;
    public float MinX;
    public float MaxX;

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
            bool ifUpdate = true;
            Vector3 total = Vector3.zero;
            foreach(GameObject player in PlayerRefs)
            {
                if(player != null)
                {
                    total += player.transform.position;
                }
                else
                {
                    ifUpdate = false;
                }
            }

            if(ifUpdate)
            {
                m_averageLocation = total / PlayerRefs.Length;

                //Find Camera Size
                Vector2 topRightCorner = new Vector2(1, 1);
                Vector2 edgeVector = Camera.main.ScreenToWorldPoint(topRightCorner) - transform.position;

                //Set the Position
                transform.position = new Vector3(Mathf.Clamp(m_averageLocation.x, MinX - edgeVector.x, MaxX + edgeVector.x),
                                                 Mathf.Clamp(m_averageLocation.y, MinY - edgeVector.y, MaxY + edgeVector.y), -10);
            }
            

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
