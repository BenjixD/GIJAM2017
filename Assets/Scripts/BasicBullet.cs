using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour, IBullet
{
    public float Damage;

    public void SetTravelProperties(float angle, float speed)
    {
        float xSpeed = Mathf.Cos(angle * Mathf.Deg2Rad) * speed;
        float ySpeed = Mathf.Sin(angle * Mathf.Deg2Rad) * speed;

        GetComponent<Rigidbody2D>().velocity = new Vector3(xSpeed, ySpeed, 0);
    }

    public float GetDamage()
    {
        return Damage;
    }
}
