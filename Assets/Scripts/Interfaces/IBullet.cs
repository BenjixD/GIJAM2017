using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    bool enabled { get; set; }

    void SetTravelProperties(float angle, float speed);
    float GetDamage();
}
