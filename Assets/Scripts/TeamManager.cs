using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public GameObject[] Players;

    private IPlayer m_player1;
    private IPlayer m_player2;

    void Start()
    {
        m_player1 = Players[0].GetComponent<IPlayer>();
        m_player2 = Players[1].GetComponent<IPlayer>();
    }

    void Update()
    {
        //if((Input.GetButton("Switch" + (int)m_player1.GetPlayer()) || Input.GetAxisRaw("Switch" + (int)m_player1.GetPlayer()) == 1) &&
        //   (Input.GetButton("Switch" + (int)m_player2.GetPlayer()) || Input.GetAxisRaw("Switch" + (int)m_player2.GetPlayer()) == 1))
        //{
        //    Debug.Log("SWAP");
        //}
    }
}
