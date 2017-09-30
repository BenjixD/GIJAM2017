using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealth : MonoBehaviour {

    public float maxHealth;
    float health;
    PlaneBehaviour plane;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        plane = GetComponent<PlaneBehaviour>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IBullet bult = collision.gameObject.GetComponent<IBullet>();
        if (bult != null && bult.GetSpawnedBy().transform.root.gameObject != transform.root.gameObject)
        {
            getHurt(bult.GetDamage());
        }
    }

    public void getHurt(float damage) {
        health -= damage;
        if (health <= 0)
        {
            plane.triggerDeath();
        }
    }

    public float getCurrentHealth()
    {
        return health;
    }

    public float getNormalizedHealth()
    {
        return health / maxHealth;
    }
}
