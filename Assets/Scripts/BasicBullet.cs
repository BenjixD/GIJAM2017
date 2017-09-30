﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour, IBullet
{
    public float Damage;

    private GameObject m_spawnedBy;

    public void SetSpawnedBy(GameObject spawner)
    {
        m_spawnedBy = spawner;
    }

    public GameObject GetSpawnedBy (){ return m_spawnedBy;  }

    public void SetTravelProperties(float angle, float speed)
    {
        float xSpeed = Mathf.Cos(angle * Mathf.Deg2Rad) * speed;
        float ySpeed = Mathf.Sin(angle * Mathf.Deg2Rad) * speed;

        GetComponent<Rigidbody2D>().velocity = new Vector3(xSpeed, ySpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.transform.root != m_spawnedBy.transform.root)
        {
            Destroy(gameObject);
        }
    }

public float GetDamage()
    {
        return Damage;
    }
}
